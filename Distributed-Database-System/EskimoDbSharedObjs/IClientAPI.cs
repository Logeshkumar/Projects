////////////////////////////////////////////////////////////////////////////////
// IClientAPI.cs - Interface between the client API and the GUI               //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Anjali Banka, Fall 2011, Syracuse University                 //
//               abanka@syr.edu                                               //
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
using System.Text;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  public  interface IClientAPI
  {
    /// <summary>
    /// Used to create a new user with the specified username and password
    /// </summary>
    /// <param name="newUser"></param>
    /// <param name="newUserPwd"></param>
    /// <param name="token"></param>
    /// <returns> true when user created, else false</returns>
    AuthResult CreateNewUser(string newUser, string newUserPwd, string token);

    /// <summary>
    /// Checks if the current is the administrator
    /// </summary>
    /// <param name="token"></param>
    /// <returns>
    /// True when user is the administrator
    /// Falso when user is not the administrator
    /// </returns>
    bool IsAdmin(string token);

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
    AuthResult AuthenticateUser(string Username, string Password, out string token);



    /// <summary>
    /// Get all the existing user names
    /// </summary>
    /// <param name="token"></param>
    /// <returns>
    /// string list containing all the existing user names
    /// </returns>
    List<string> GetAllUserNames(string token);

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
    AuthResult ChangeUserPrivilege(string userName, bool administrator,string token);

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
    AuthResult ChangePassword(string userName, string pwd,string token);


    /// <summary>
    /// Used to check if the QueryDataset contains rows or is empty
    /// </summary>
    /// <returns>
    /// True when rows are present in the QueryDataset
    /// False when QueryDataset is empty
    /// </returns>
    bool CheckIfRowsReturned();

    /// <summary>
    /// Used to get the column names of all the columns present in the QueryDataset
    /// </summary>
    /// <returns>
    /// A string list with all the column names
    /// </returns>
    List<string> GetAllColumnNames();

    /// <summary>
    /// Used to get the types of all the column names
    /// </summary>
    /// <returns>
    /// A list with all the column types
    /// </returns>
    List<Type> GetAllColumnTypes();

    /// <summary>
    /// Used to execute the eskimoDB query 
    /// </summary>
    /// <param name="query"></param>
    /// <param name="token"></param>
    /// <returns>
    /// QueryResult which contains initial the id and message associated with the query execution
    /// </returns>
    QueryResult ExecuteQuery(string query, string token);

    /// <summary>
    /// Used to iterate through the QueryDataset which is returned
    /// </summary>
    /// <returns>
    /// lsit of string with the data associated with a row
    /// </returns>
    List<string> IterateDataSet();
  }
}
