////////////////////////////////////////////////////////////////////////////////
// ClientAPI.cs - Class extending ClientAPI wrapper capabilities              //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Authors:       Indranil Mitra (imitra@syr.edu ),                           //                 
//                Anjali Banka (abanka@syr.edu), Hao Shen (  hshen01@syr.edu )// 
//                Fall 2011, Syracuse University                              //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using edu.syr.cse784.eskimodb.depinject;
using edu.syr.cse784.eskimodb.sharedobjs;
using edu.syr.eskimodb.clientapi;


namespace edu.syr.cse784.eskimodb.clientapi
{
  /// <summary>
  /// Wrapper class for the client api
  /// </summary>
  public class ClientAPI : IRootServerCallback, IClientAPI, IClientConfig
  {

    #region Properties

    public string userName { get; set; }

    public string passWord { get; set; }

    public string authHostAddress { get; set; }
    public string rootHostAddress { get; set; }


    IRootServer mockRootServer;
    IAuthServer mockAuthServer;

    // used by the callback interface of root server
    private bool m_PutDataSetCalled;
    private bool m_PutQueryInfoCalled;
    private QueryResult m_QueryResult;
    private string m_id;

    private long m_lines;

    List<string> m_ColumnNames;
    List<Type> m_ColumnTypes;

    Tables m_Table;


    private bool m_CallGetResult;
    private int m_startLine;
    private int m_RowsPerTime;
    private int m_IterateIndex;

    private QueryDataset m_QueryDataset;
    private int m_IterateToTheEnd;
    private int m_FinalLines;
    DependencyInjection di;
    #endregion Properties

    /// <summary>
    /// Constructor for initialization 
    /// </summary>
    public ClientAPI()
    {
      Logger.LogWrite("Initializing client api");

      m_PutDataSetCalled = false;
      m_PutQueryInfoCalled = false;
      m_QueryResult = new QueryResult(0, null, null);
      m_id = null;
      m_QueryDataset = new QueryDataset(new System.Collections.Generic.List<Type>(), new System.Collections.Generic.List<string>());
      m_lines = 0;

      m_IterateToTheEnd = 0;
      m_CallGetResult = true;
      m_startLine = 0;
      m_RowsPerTime = 5;
      m_IterateIndex = 0;
      m_FinalLines = 0;
      m_Table = new Tables();

    }

    /// <summary>
    /// To set the authentication server host url
    /// </summary>
    /// <param name="authServerHostUrl"></param>
    public void SetAuthHostAddress(string authServerHostUrl)
    {
      Logger.LogWrite("Setting the authentication server url to " + authServerHostUrl);
      authHostAddress = authServerHostUrl;

    }

    /// <summary>
    /// To set the root server host url
    /// </summary>
    /// <param name="rootServerUrl"></param>
    public void SetRootServer(string rootServerUrl)
    {
      Logger.LogWrite("Setting the root server url to " + rootServerUrl);
      rootHostAddress = rootServerUrl;
    }

    /// <summary>
    /// Configuring the client api by creating objects using the dependency framework
    /// </summary>
    public void ConfigClient()
    {
      Logger.LogWrite("Creating instance of DI to cinfigure client api");
      di = DependencyInjection.GetInstance();
      mockRootServer = (IRootServer)di.CreateObject("root", new object[]{
                this,new WSDualHttpBinding(),rootHostAddress});
      mockAuthServer = (IAuthServer)di.CreateObject("auth", new object[]{
                null,new BasicHttpBinding(),authHostAddress});

    }

    /// <summary>
    /// Wrapper function to get the result from the root server 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="startLine"></param>
    /// <param name="numberOfLines"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private QueryResult GetResult(string id, int startLine, int numberOfLines, string token)
    {
      Logger.LogWrite("Getting the result from the root server");
      QueryResult ret = mockRootServer.GetResult(id, startLine, numberOfLines, token);
      return ret;
    }

    private bool WaitForPutQueryInfo()
    {
      while (!m_PutQueryInfoCalled) Thread.Sleep(20);
      m_PutQueryInfoCalled = false;
      return true;
    }

    private bool WaitForPutDataset()
    {
      Logger.LogWrite("Wait for the put dataset using callback");
      while (!m_PutDataSetCalled) Thread.Sleep(20);
      m_PutDataSetCalled = false;
      return true;
    }

    private void ProcessDataSet()
    {
      foreach (var rows in m_QueryDataset)
      {
        List<string> m_RowData = new List<string>();

        foreach (var field in rows.Value)
        {
          m_RowData.Add(field.ToString());
        }
        m_Table.PutRowInTable(m_RowData);
      }
    }

    /// <summary>
    /// Create new user
    /// </summary>
    /// <param name="Username"></param>
    /// <param name="Password"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public AuthResult CreateNewUser(string newUser, string newUserPwd, string token)
    {
      Logger.LogWrite("Creating a new user " + newUser);
      AuthResult ret = mockAuthServer.CreateUser(newUser, newUserPwd, token);
      return ret;
    }

    /// <summary>
    /// check whether the current user is administrator or not
    /// </summary>
    /// <param name="token"></param>
    /// <returns>
    /// Returns true when the user is admin
    /// Returns false when the user is not admin 
    /// </returns>
    public bool IsAdmin(string token)
    {
      Logger.LogWrite("Checking is the current user is administrator");
      bool tempautharesult = mockAuthServer.IsAdmin(token);
      if (tempautharesult == true)
      {
        Logger.LogWrite("User logged in as admin");
        return true;
      }
      else
      {
        Logger.LogWrite("Logged in user is not admin");
        return false;
      }
    }

    /// <summary>
    /// User credentials are authenticated
    /// </summary>
    /// <param name="Username"></param>
    /// <param name="Password"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public AuthResult AuthenticateUser(string Username, string Password, out string token)
    {
      Logger.LogWrite("Authenticating the user credentials");
      AuthResult ret = mockAuthServer.Authenticate(Username, Password, out token);
      return ret;
    }

    /// <summary>
    /// Get all the exsiting users' names
    /// </summary>
    /// <param name="token"></param>
    /// <returns>
    /// list of string containing all the users' names
    /// </returns>
    public List<string> GetAllUserNames(string token)
    {
      Logger.LogWrite("Getting the list of all user's");
      List<string> ret = mockAuthServer.GetAllUserNames(token);
      return ret;
    }

    /// <summary>
    /// Change the privilege level of specific user
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="administrator"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public AuthResult ChangeUserPrivilege(string userName, bool adminstrator, string token)
    {
      Logger.LogWrite("Changing the user privilege level of user:  " + userName);
      AuthResult ret = mockAuthServer.ChangeUserPrivilege(userName, adminstrator, token);
      return ret;
    }

    /// <summary>
    /// Change the password of specific user
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="pwd"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public AuthResult ChangePassword(string userName, string pwd, string token)
    {
      AuthResult ret = new AuthResult();
      try
      {
        Logger.LogWrite("Changing the user password of " + userName);
        ret = mockAuthServer.ChangePassword(userName, pwd, token);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }

      return ret;

    }

    /// <summary>
    /// Implement the callback function PutDataset()
    /// </summary>
    /// <param name="result"></param>
    /// <param name="id"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public void PutDataset(QueryResult result, string id, QueryDataset data)
    {
      m_QueryResult = result;
      m_id = id;
      m_QueryDataset = data;
      m_PutDataSetCalled = true;
      return;
    }

    /// <summary>
    /// Implement the callback function PutQueryInfo()
    /// </summary>
    /// <param name="result"></param>
    /// <param name="id"></param>
    /// <param name="lines"></param>
    /// <returns></returns>
    public void PutQueryInfo(QueryResult result, string id, long lines)
    {
      m_QueryResult = result;
      m_id = id;
      m_lines = lines;
      m_PutQueryInfoCalled = true;
      return;
    }

    public string GetQueryMessage()
    {
      if (m_QueryResult != null)
      {
        Logger.LogWrite("Getting the message passed with the returned query result");
        return m_QueryResult.GetMessage();
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Checks if the result contains rows or not
    /// </summary>
    /// <returns>
    /// False when no rows returned
    /// True when Row present in the result
    /// </returns>
    public bool CheckIfRowsReturned()
    {
      Logger.LogWrite("Checking if the rows are returned ");
      if (m_id == "" && m_lines == 0)
      {
        Logger.LogWrite("No rows are returned");
        return false;
      }
      Logger.LogWrite("Rows returned in the dataset");
      return true;
    }

    /// <summary>
    /// Get all the column names
    /// </summary>
    /// <returns>
    /// string list containing all the colunm names
    /// </returns>
    public List<string> GetAllColumnNames()
    {
      Logger.LogWrite("Getting the names of all the column names ");
      m_ColumnNames = m_QueryDataset.GetColumnNames();
      return m_ColumnNames;

    }

    /// <summary>
    /// Get all the column types
    /// </summary>
    /// <returns>
    /// typs list containing all the colunm types
    /// </returns>
    public List<Type> GetAllColumnTypes()
    {
      Logger.LogWrite("Getting the types of all the returned columns");
      m_ColumnTypes = m_QueryDataset.GetColumnTypes();
      return m_ColumnTypes;

    }

    /// <summary>
    /// Function used by the GUI to execute the query and get initial information about the query
    /// </summary>
    /// <param name="query"></param>
    /// <param name="token"></param>
    /// <returns>
    /// result of the query
    /// </returns>
    public QueryResult ExecuteQuery(string query, string token)
    {
      Logger.LogWrite("Executing query : " + query + " on the root server ");
      QueryResult ret = mockRootServer.ExecQuery(query, token);
      WaitForPutQueryInfo();
      return ret;
    }


    /// <summary>
    ///  Function used by the GUI to iterate the data row by row
    /// </summary>
    /// <returns>
    /// string list containing all the data in one row . Return null if it is the end
    /// </returns>
    public List<string> IterateDataSet()
    {
      Logger.LogWrite("Iterating through the returned data set");
      List<string> m_List = new List<String>();

      if (m_IterateToTheEnd == 1)
      {
        m_FinalLines = (int)m_lines - m_startLine;
        GetResult(m_id, m_startLine, m_FinalLines, token);
        WaitForPutDataset();
        ProcessDataSet();
        m_IterateIndex = 0;
        m_IterateToTheEnd = 2;

      }
      else if (m_CallGetResult)
      {
        GetResult(m_id, m_startLine, m_RowsPerTime, token);
        WaitForPutDataset();
        ProcessDataSet();
        m_IterateIndex = 0;
        m_CallGetResult = false;
      }


      if ((m_IterateToTheEnd == 0 && m_IterateIndex < m_RowsPerTime) || (m_IterateToTheEnd == 2 && m_IterateIndex < m_FinalLines))
      {
        m_List = m_Table.GetRowFromTable(m_IterateIndex);
        m_IterateIndex++;

      }
      else if (m_IterateToTheEnd == 2)
      {
        m_CallGetResult = true;
        m_IterateToTheEnd = 0;
        m_startLine = 0;
        m_FinalLines = 0;
        m_IterateIndex = 0;
        m_Table.ClearTable();
        return null;
      }
      else
      {

        m_CallGetResult = true;
        m_Table.ClearTable();
        m_startLine += m_RowsPerTime;
        if (m_startLine + m_RowsPerTime > m_lines)   // the end of the iteration
        {
          m_IterateToTheEnd = 1;
          m_CallGetResult = false;
        }
        m_List = IterateDataSet();
        //Console.WriteLine("iterate");
      }

      return m_List;
    }

    public Dictionary<string, List<string>> GetTableInfos(string token)
    {
      Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
      ret = mockRootServer.GetDBInfo(token);
      Logger.LogWrite("Getting the structure of the database and corresponding tables");
      return ret;
    }

    public string token { get; set; }

    public static void Main(string[] args)
    {
      DependencyInjection di = DependencyInjection.GetInstance();
      di.SetConfig("config.xml");
      Console.WriteLine("test begins");

      ClientAPI m_TestObject = new ClientAPI();
      m_TestObject.SetRootServer("http://localhost:8080/root");
      m_TestObject.SetAuthHostAddress("http://localhost:8080/IComm");
      m_TestObject.ConfigClient();

      m_TestObject.ExecuteQuery("SELECT * FROM first_db.test_table", "mocktoken");
      if (m_TestObject.CheckIfRowsReturned())
      {
        List<string> string1 = m_TestObject.IterateDataSet();

        List<string> ColNames = m_TestObject.GetAllColumnNames();

        List<System.Type> ColTypes = m_TestObject.GetAllColumnTypes();
        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");
        Console.WriteLine(string1[1]);
        string1 = m_TestObject.IterateDataSet();

        if (string1 == null) Console.WriteLine("the end");

      }
      else
      {
        Console.WriteLine(" no row returned");

      }

    }
  }
}
