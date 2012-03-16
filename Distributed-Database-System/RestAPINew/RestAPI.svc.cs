////////////////////////////////////////////////////////////////////////////////
// ClientAPI.cs - Implement IRestAPI interface                                //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Yang Ge, Yukan Zhang, Fall 2011, Syracuse University         //
//               {yage,yzhan158}@syr.edu                                      //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using edu.syr.cse784.eskimodb.clientapi;
using edu.syr.cse784.eskimodb.sharedobjs;


namespace edu.syr.cse784.eskimodb.restapi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class RestAPI : IRestAPI
    {
        private ClientAPI m_ClientApiInstance;

        public RestAPI()
        {
            m_ClientApiInstance = new ClientAPI();
        }

        public string CreateNewUser(UserInfo userinfo)
        {
            string ret = "{";
            AuthResult authresult;
            authresult = mockCreateNewUser(userinfo.UserName, userinfo.Password, userinfo.Token);
            // authresult = m_ClientApiInstance.CreateNewUser(userinfo.UserName, userinfo.Password, userinfo.Token);
            ret += "\"success\":\"Create new user succeeded\"";
            if (authresult.valid)
            {
                ret += ",\"AuthresultValid\":\"" + "Valid!" + "\"";
            }
            else
            {
                ret += ",\"AuthresultValid\":\"" + "Not Valid!" + "\"";
            }
            ret += ",\"AuthresultMsg\":\"" + authresult.msg + "\"}";
            return ret;
        }

        public AuthResult mockCreateNewUser(string newUser, string newUserPwd, string token)
        {
            AuthResult authresult = new AuthResult();
            authresult.valid = true;
            authresult.msg = "Successfully created users!";

            return authresult;
        }

        public string IsAdmin(string token)
        {
            bool isadmin = true;
            if (token == "abcdefg")
            {
                isadmin = true;
            }
            else
            {
                isadmin = false;
            }
            // isadmin = m_ClientApiInstance.IsAdmin(token);
            string ret = "{";
            ret += "\"success\":\"get match " + "11" + " succeeded\"";
            if (isadmin)
            {
                ret += ",\"contents\":\"" + "Yes" + "\"}";
            }
            else
            {
                ret += ",\"contents\":\"" + "No" + "\"}";
            }
            return ret;
        }

        public string GetMatchDetail(string id)
        {
            string ret = "{";
            ret += "\"success\":\"get match " + id + " succeeded\"";
            ret += ",\"home\":\"" + "AdminHome" + "\"";
            ret += ",\"away\":\"" + "AdminAway" + "\"";
            ret += ",\"score\":\"" + "100:100" + "\"}";
            // ret += ",\"contents\":\"" + "Yes" + "\"}";
            return ret;
        }

        public string AuthenticateUser(UserInfo userinfo) 
        {
            string ret = "{";
            AuthResult authresult;
            authresult = mockAuthenticateUser(userinfo.UserName, userinfo.Password, userinfo.Token);
            // authresult = m_ClientApiInstance.AuthenticateUser(userinfo.UserName, userinfo.Password, userinfo.Token);
            ret += "\"success\":\"Authenticate User succeeded\"";
            if (authresult.valid)
            {
                ret += ",\"AuthresultValid\":\"" + "Valid!" + "\"";
            }
            else
            {
                ret += ",\"AuthresultValid\":\"" + "Not Valid!" + "\"";
            }
            ret += ",\"AuthresultMsg\":\"" + authresult.msg + "\"}";
            return ret;
        }

        public AuthResult mockAuthenticateUser(string newUser, string newUserPwd, string token)
        {
            AuthResult authresult = new AuthResult();
            authresult.valid = true;
            authresult.msg = "Successfully authenticate users!";
            return authresult;
        }

        public string GetAllUserNames(string token)
        {
            string ret = "{";
            string contents = "";
            List<string> users;
            users = MockGetAllUserNames(token);
            // users =  m_ClientApiInstance.GetAllUserNames(token);
            ret += "\"success\":\"get match " + token + " succeeded\"";
            foreach (var u in users)
            {
                contents += u + " ";
            }
            ret += ",\"contents\":\"" + contents + "\"}";
            return ret;
        }

        private List<string> MockGetAllUserNames(string token)
        {
            List<string> users = new List<string>();
            users.Add("Yu Gu");
            users.Add("Yang Ge");
            users.Add("Yukan Zhang");
            users.Add("Guokang Zhu");
            return users;
        }

        public string ChangeUserPrivilege(UserInfo userinfo)
        {
            string ret = "{";
            AuthResult authresult;
            authresult = mockChangeUserPrivilege(userinfo.UserName, userinfo.Password, userinfo.Token);
            // authresult = m_ClientApiInstance.ChangeUserPrivilege(userinfo.UserName, userinfo.Password, userinfo.Token);
            ret += "\"success\":\"Change User Privilege succeeded\"";
            if (authresult.valid)
            {
                ret += ",\"AuthresultValid\":\"" + "Valid!" + "\"";
            }
            else
            {
                ret += ",\"AuthresultValid\":\"" + "Not Valid!" + "\"";
            }
            ret += ",\"AuthresultMsg\":\"" + authresult.msg + "\"}";
            return ret;
        }

        public AuthResult mockChangeUserPrivilege(string newUser, string newUserPwd, string token)
        {
            AuthResult authresult = new AuthResult();
            authresult.valid = true;
            authresult.msg = "Successfully Change User Privilege!";
            return authresult;
        }

        public string ChangePassword(UserInfo userinfo)
        {
            string ret = "{";
            AuthResult authresult;
            authresult = mockChangePassword(userinfo.UserName, userinfo.Password, userinfo.Token);
            // authresult = m_ClientApiInstance.ChangePassword(userinfo.UserName, userinfo.Password, userinfo.Token);
            ret += "\"success\":\"Change password succeeded\"";
            if (authresult.valid)
            {
                ret += ",\"AuthresultValid\":\"" + "Valid!" + "\"";
            }
            else
            {
                ret += ",\"AuthresultValid\":\"" + "Not Valid!" + "\"";
            }
            ret += ",\"AuthresultMsg\":\"" + authresult.msg + "\"}";
            return ret;
        }

        public AuthResult mockChangePassword(string newUser, string newUserPwd, string token)
        {
            AuthResult authresult = new AuthResult();
            authresult.valid = true;
            authresult.msg = "Successfully Change Password!";
            return authresult;
        }

        public bool CheckIfRowsReturned()
        {
            return m_ClientApiInstance.CheckIfRowsReturned();
        }

        public string GetAllColumnNames()
        {
            string ret = "{";
            string contents = "";
            List<string> columnNames;
            columnNames = MockGetAllColumnNames();
            // columnNames = m_ClientApiInstance.GetAllColumnNames();
            ret += "\"success\":\"get column names" + " succeeded\"";
            foreach (var u in columnNames)
            {
                contents += u + " ";
            }
            ret += ",\"contents\":\"" + contents + "\"}";
            return ret;
        }

        private List<string> MockGetAllColumnNames()
        {
            List<string> columnNames = new List<string>();
            columnNames.Add("YG");
            columnNames.Add("YZ");
            columnNames.Add("GZ");
            return columnNames;
        }

        public string GetAllColumnTypes()
        {
            string ret = "{";
            string contents = "";
            List<Type> typeNames;
            typeNames = MockGetAllColumnTypes();
            // typeNames = m_ClientApiInstance.GetAllColumnTypes();
            ret += "\"success\":\"get column names" + " succeeded\"";
            foreach (var u in typeNames)
            {
                contents += u.FullName + " ";
            }
            ret += ",\"contents\":\"" + contents + "\"}";
            return ret;
        }

        private List<Type> MockGetAllColumnTypes()
        {
            List<Type> typeNames = new List<Type>();
            typeNames.Add(Type.GetType("System.Int16"));
            typeNames.Add(Type.GetType("System.IntPtr"));
            typeNames.Add(Type.GetType("System.Char"));
            return typeNames;
        }

        public QueryResult ExecuteQuery(string query, string token)
        {
            return m_ClientApiInstance.ExecuteQuery(query, token);
        }

        public List<string> IterateDataSet()
        {
            return m_ClientApiInstance.IterateDataSet();
        }
    }
}