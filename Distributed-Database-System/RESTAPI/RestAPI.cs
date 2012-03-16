using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using edu.syr.cse784.eskimodb.depinject;
using edu.syr.cse784.eskimodb.sharedobjs;
using edu.syr.eskimodb.clientapi;


namespace edu.syr.cse784.eskimodb.restapi
{
    /// <summary>
    /// Wrapper class for the client api
    /// </summary>
    public class RestAPI //: IRootServerCallback, IRestAPI
    {
        public string userName { get; set; }

        public string passWord { get; set; }

        IRootServer mockRootServer;
        IAuthServer mockAuthServer;

        // used by the callback interface of root server
        private bool m_PutDataSetCalled;   //flag for checking whether callback function PutDataset() has been called 
        private bool m_PutQueryInfoCalled;  //flag for checking whether callback function PutQueryInfo() has been called 
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

        /// <summary>
        /// Constructor for initialization 
        /// </summary>
        public RestAPI()
        {
            // Logger.LogWrite(EskimoDBLogLevel.Verbose, "Creating");
            DependencyInjection di = DependencyInjection.GetInstance();

            mockRootServer = (IRootServer)di.CreateObject("root", new object[]{
                this,new WSDualHttpBinding(),"http://localhost:8080/root"});
            mockAuthServer = (IAuthServer)di.CreateObject("auth", new object[]{
                null,new BasicHttpBinding(),"http://149.119.196.45:8080/IComm"});

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

        private QueryResult GetResult(string id, int startLine, int numberOfLines, string token)
        {
            QueryResult tempQueryResult = mockRootServer.GetResult(id, startLine, numberOfLines, token);
            return tempQueryResult;
        }

        private bool WaitForPutQueryInfo()
        {
            while (!m_PutQueryInfoCalled) Thread.Sleep(20);  //probably we  need to implement some timeout mechanism
            m_PutQueryInfoCalled = false;
            return true;
        }

        private bool WaitForPutDataset()
        {
            while (!m_PutDataSetCalled) Thread.Sleep(20);  //probably we  need to implement some timeout mechanism
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
        /// create new user
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public AuthResult CreateNewUser(string newUser, string newUserPwd, string token)
        {
            AuthResult tempautharesult = mockAuthServer.CreateUser(newUser, newUserPwd, token);
            return tempautharesult;
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
            bool tempautharesult = mockAuthServer.IsAdmin(token);
            if (tempautharesult == true)
            {
                return true;
            }
            else
            {
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
          
            AuthResult tempautharesult = mockAuthServer.Authenticate(Username, Password, out token);
            return tempautharesult;
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

            List<string> List = mockAuthServer.GetAllUserNames(token);
            return List;
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

            AuthResult authresult = mockAuthServer.ChangeUserPrivilege(userName, adminstrator, token);
            return authresult;
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
            AuthResult authresult = mockAuthServer.ChangePassword(userName, pwd, token);
            return authresult;

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
            if (m_id == "" && m_lines == 0)
            {
                return false;
            }
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
            QueryResult tempQueryResult = mockRootServer.ExecQuery(query, token);
            WaitForPutQueryInfo();
            return tempQueryResult;
        }


        /// <summary>
        ///  Function used by the GUI to iterate the data row by row
        /// </summary>
        /// <returns>
        /// string list containing all the data in one row . Return null if it is the end
        /// </returns>
        public List<string> IterateDataSet()
        {
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
                //   Console.WriteLine(" index" + m_IterateIndex + "\n" + "startline:" +m_startLine);
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

        public string token { get; set; }

        public static void Main(string[] args)
        {
            Console.WriteLine("test begins");
            RestAPI m_TestObject = new RestAPI();
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
