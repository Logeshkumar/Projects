/*
 * RequestHandler.cs
 * RequestHandler module responsible for handling requests for the root server.
 * 
 */
/*
 * Dependent files
 * ======================
 * RequestHandler.cs
 * 
 * Maintanence
 * ======================
 * 11/10/2011 - first release.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class RequestHandler
  {
    private RequestQueue m_RequestQueue = null;
    private bool exit = false;

    public RequestHandler(RequestQueue requestQueue)
    {
      m_RequestQueue = requestQueue;      
    }

    public void startRequestHandler()
    {
      Thread requestHandlerThread = new Thread(new ThreadStart(this.getRequest));
      requestHandlerThread.Start();
    }

    void getRequest()
    {
      Request request = null;
      while (!exit)
      {
        request = m_RequestQueue.deQueueRequest();
        if (request.getRequestType() == RequestType.ROOTSERVER_SHUTDOWN)
          exit = true;
        else
          this.dispatchRequest(request);
      }           
    }

    void dispatchRequest(Request request)
    {
      switch (request.getRequestType())
      { 
        case RequestType.EXECUTE_QUERY:
          ProcessExecQuery(request);
          break;
        case RequestType.GET_RESULT:
          ProcessGetResult(request);
          break;
        case RequestType.RELEASE:
          ProcessRelease(request);
          break;
        default:
          break;
      }
        
    }

    private static void ProcessGetResult(Request request)
    {
      Object[] requestData = request.getMethodParameters();
      string id = requestData[0].ToString();
      int startLine = Convert.ToInt32(requestData[1]);
      int numberOfLines = Convert.ToInt32(requestData[2]);
      QueryResult queryResult;
      ResultStorage resultStorage = ResultStorage.Instance;
      QueryDataset queryDataset = resultStorage.GetQueryResult(id, startLine, numberOfLines);
      queryResult = new QueryResult(Convert.ToInt32(id), "Resulting rows being posted.");

      IRootServerCallback iRootServerCallback = request.getRootServerCallback();

      iRootServerCallback.PutDataset(queryResult, id, queryDataset);
    
    }

    private static void ProcessRelease(Request request)
    { }

    private static void ProcessExecQuery(Request request)
    {
      ITableServer tableServerObject = request.getTableServerObject();
      Type created = tableServerObject.GetType();

      Object resultObject = created.InvokeMember(request.getCallingMethod(),
                                                  System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.InvokeMethod,
                                                  null,
                                                  tableServerObject,
                                                  request.getMethodParameters()
                                                  );
      TableResponse tableResponse = (TableResponse)resultObject;
      IRootServerCallback iRootServerCallback = request.getRootServerCallback();
      string id = tableResponse.GetId;
      QueryResult queryResult;

      queryResult = new QueryResult(Convert.ToInt32(id), tableResponse.GetMessage);
      iRootServerCallback.PutQueryInfo(queryResult, id, 0);
    }


    
  }

}
