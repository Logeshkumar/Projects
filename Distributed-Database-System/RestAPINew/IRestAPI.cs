////////////////////////////////////////////////////////////////////////////////
// IRestAPI.cs - Interface between the rest API and the GUI                   //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Yang Ge, Fall 2011, Syracuse University                      //
//               yage@syr.edu                                                 //
////////////////////////////////////////////////////////////////////////////////

/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 11/02/2011 - first
 * /
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.restapi
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Token { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestAPI
    {
        /// <summary>
        /// Used to create a new user with the specified username and password
        /// </summary>
        /// <param name="newUser"></param>
        /// <param name="newUserPwd"></param>
        /// <param name="token"></param>
        /// <returns> true when user created, else false</returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "CreateNewUser")]
        string CreateNewUser(UserInfo userinfo);

        /// <summary>
        /// Checks if the current is the administrator
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// True when user is the administrator
        /// Falso when user is not the administrator
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "IsAdmin/{token}")]
        string IsAdmin(string token);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "Match/{id}")]
        string GetMatchDetail(string id);

        /// <summary>
        /// Uses the token to check the authentication of the current user
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <param name="token"></param>
        /// <returns>
        /// true when user is authorized
        /// false when unauthorized user
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "AuthenticateUser")]
        string AuthenticateUser(UserInfo userinfo);

        /// <summary>
        /// Get all the existing user names
        /// </summary>
        /// <param name="token"></param>
        /// <returns>
        /// string list containing all the existing user names
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "GetAllUserNames/{token}")]
        string GetAllUserNames(string token);

        /// <summary>
        /// Uses the token to check the authentication of the current user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="administrator"></param>
        /// <param name="token"></param>
        /// <returns>
        /// true when the operation succeeds
        /// false when operation fails
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "ChangeUserPrivilege")]
        string ChangeUserPrivilege(UserInfo userinfo);

        /// <summary>
        /// Changes the password of specific user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <param name="token"></param>
        /// <returns>
        /// true when the operation succeeds
        /// false when operation fails
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "ChangePassword")]
        string ChangePassword(UserInfo userinfo);


        /// <summary>
        /// Used to check if the QueryDataset contains rows or is empty
        /// </summary>
        /// <returns>
        /// True when rows are present in the QueryDataset
        /// False when QueryDataset is empty
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "CheckIfRowsReturned")]
        bool CheckIfRowsReturned();

        /// <summary>
        /// Used to get the column names of all the columns present in the QueryDataset
        /// </summary>
        /// <returns>
        /// A string list with all the column names
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "GetAllColumnNames")]
        string GetAllColumnNames();

        /// <summary>
        /// Used to get the types of all the column names
        /// </summary>
        /// <returns>
        /// A list with all the column types
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "GetAllColumnTypes")]
        string GetAllColumnTypes();

        /// <summary>
        /// Used to execute the eskimoDB query 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="token"></param>
        /// <returns>
        /// QueryResult which contains initial the id and message associated with the query execution
        /// </returns>
        /*
        [OperationContract]
        [WebInvoke(Method = "POST",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "ExecuteQuery")]
        QueryResult ExecuteQuery(string query, string token);
         */

        /// <summary>
        /// Used to iterate through the QueryDataset which is returned
        /// </summary>
        /// <returns>
        /// lsit of string with the data associated with a row
        /// </returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "IterateDataSet")]
        List<string> IterateDataSet();       
    }

}
