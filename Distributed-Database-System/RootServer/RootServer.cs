/*
 * RootServer.cs
 * Root Server implementation (service implementation)
 * 
 */
/*
 * Dependent files
 * ======================
 * RequestHandler.cs, RequestQueue.cs, QParser.cs, Statment.cs,
 * ClientMap.cs, QueryProcessor.cs
 * 
 * Maintanence
 * ======================
 * 10/24/2011 - first release.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using edu.syr.cse784.eskimodb.depinject;

namespace edu.syr.cse784.eskimodb.rootserver
{
  [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
  public class RootServer : IRootServer
  {
    private RequestHandler m_RequestHandler = null;
    private RequestQueue m_RequestQueue = null;
    private QParser m_QParser = null;
    private Statement m_Statement = null;
    private ClientMap m_ClientMap = null;
    private ITableServer m_ITableServer = null;
    private string m_AuthSeverUrl = null;
    private string m_TableServerUrl = null;
        
    public RootServer()
    {
      m_ClientMap = new ClientMap();
      m_QParser = new QParser();
      m_Statement = new Statement();
      m_RequestQueue = new RequestQueue();
      m_RequestHandler = new RequestHandler(m_RequestQueue);
      m_RequestHandler.startRequestHandler();
      
    }

    ~RootServer()
    {
      Request shutdownRequest = new Request();
      shutdownRequest.SetRequestType(RequestType.ROOTSERVER_SHUTDOWN);
      m_RequestQueue.enQueueRequest(shutdownRequest);
    }

    /*
     * ExecQuery(query,token) receives a request with a authentication token.
     * It does a quick check on the validity of thetoken, and the query grammar, 
     * if the check doesn't pass it will return a result telling client the 
     * failure and info associated with the failure. If check passes, it adds 
     * the request to a queue, and notify client that the request is accepted.
     * @param query is the query string.
     * @param token is the authentication token
     * @returns whether the operation is successful and info related to the result.
     */
    public QueryResult ExecQuery(string query, string token)
    {
      QueryResult queryResult;
      DateTime dateTime;
      QueryProcessor queryProcessor = null;
      try
      {  
        DependencyInjection di = DependencyInjection.GetInstance();
        IAuthValidate iAuthValidate = (IAuthValidate)di.CreateObject("validate",
                                                                      new object[]
                                                                    { null,
                                                                      m_AuthSeverUrl
                                                                      });
                                                                   
        if (!iAuthValidate.Validate(token, out dateTime))
        {
          queryResult = new QueryResult(-1, "Could not authenticate user.");
          return queryResult;
        }
        
        if (!validateQuerySyntax(query, out queryResult))
        {
          return queryResult;
        }

        if (m_Statement != null)
        {
          queryProcessor = new QueryProcessor(m_ClientMap);
          IRootServerCallback callback = OperationContext.Current.GetCallbackChannel<IRootServerCallback>();
        Request request = queryProcessor.GetRequestObject(token, m_Statement, callback);
          request.setTableServerObject(m_ITableServer);
          m_RequestQueue.enQueueRequest(request);
          queryResult = new QueryResult(0, "Query syntax correct.");
          return queryResult;
        }
        else
        {
          queryResult = new QueryResult(-1, "Error parsing query.");
          return queryResult;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("RootServer:" + ex.Message);
      }
      queryResult = new QueryResult(-1, "Error parsing query.");
      return queryResult;
    }

    /*
     * GetResult(id,startline,numberOfLines) receives a request asking for data
     * in a table stored on the root server. 
     * @param id is the identifier for the table on root server.
     * @param startLine is the first data entry that the client wants.
     * @param numberOfLines is the total number of data entries the client wants.
     * @param token is the authentication token.
     * @returns the result of operation and info related to the result.
     */
    public QueryResult GetResult(string id, int startLine, int numberOfLines, string token)
    {
      QueryResult queryResult;
      DateTime dateTime;
      DependencyInjection di = DependencyInjection.GetInstance();
      IAuthValidate iAuthValidate = (IAuthValidate)di.CreateObject("validate",new object[]
                                                                    { null,
                                                                      m_AuthSeverUrl
                                                                      });
      if (!iAuthValidate.Validate(token, out dateTime))
      {
        queryResult = new QueryResult(-1, "Could not authenticate user.");
        return queryResult;
      }
      Request request = new Request();
      request.SetRequestType(RequestType.GET_RESULT);
      request.setTableServerObject(m_ITableServer);
      Object[] requestData = new Object[3];
      requestData[0] = id;
      requestData[1] = startLine;
      requestData[2] = numberOfLines;
      request.SetMethodParameters(requestData);
      request.SetRootServerCallback(OperationContext.Current.GetCallbackChannel<IRootServerCallback>());
      
      m_RequestQueue.enQueueRequest(request);
      
      queryResult = new QueryResult(Convert.ToInt32(id), "Query result request received.");
      return queryResult;
    }

    /*
     * Release(id,token) will release the reference to a table object on root server
     * and let the table object be garbage collected.
     * @param id is the identifier for the table on root server.
     * @param token is the authentication token
     * @returns the result of operation and info related to the result.
     */
    public QueryResult Release(string id, string token)
    {
      Console.WriteLine("\n Release method.");
      QueryResult qr = new QueryResult(3, "release");
      return qr;
    }

    /*
     * @param token is the authentication token
     * @returns the DB structure.
     */
    public Dictionary<string, List<string>> GetDBInfo(string token)
    {
      DateTime dateTime;
      DependencyInjection di = DependencyInjection.GetInstance();
      IAuthValidate iAuthValidate = (IAuthValidate)di.CreateObject("validate", new object[]
                                                                    { null,
                                                                      m_AuthSeverUrl
                                                                      });
      if (!iAuthValidate.Validate(token, out dateTime))
      {
        throw new Exception("Not authenticated");
      }
      Request request = new Request();
      request.SetRequestType(RequestType.DB_QUERY);
      request.setTableServerObject(m_ITableServer);
      request.SetRootServerCallback(OperationContext.Current.GetCallbackChannel<IRootServerCallback>());

      m_RequestQueue.enQueueRequest(request);
      return new Dictionary<string, List<string>>(); 
    }

    public void configureRootServer(string authServerUrl, string tableServerUrl)
    {
      m_AuthSeverUrl = authServerUrl;
      m_TableServerUrl = tableServerUrl;

      DependencyInjection di = DependencyInjection.GetInstance();
      m_ITableServer = (ITableServer)di.CreateObject("tableserver", new object[]
                                                                    { new TableServerCallback(),
                                                                      m_TableServerUrl
                                                                      });
    }


    private bool validateQuerySyntax(string query, out QueryResult qr)
    {
      qr = null;
      try
      {
        if (query != "")
        {
          m_Statement = m_QParser.ValidateQuery(query);
          return true;
        }
        else
        {
          qr = new QueryResult(-1, "Error parsing the query.");
          return false;
        }
      }
      catch (QueryParserException qpe)
      {
        qr = new QueryResult(-1, qpe.Message);
        return false;
      }
      catch (Exception ex)
      {
        qr = new QueryResult(-1, ex.Message);
        return false;
      }
    }

    static void Main(string[] args)
    {
      try
      {
        RootServer rootserver = new RootServer();
        DependencyInjection di = DependencyInjection.GetInstance();
        di.SetConfig("config.xml");
        rootserver.configureRootServer("http://localhost:8081/MockAuthServer", "http://localhost:8083/MockTableServer");
        QueryResult qr = rootserver.ExecQuery("create db employee;", "xxxx");
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

    }
    
  }
}
