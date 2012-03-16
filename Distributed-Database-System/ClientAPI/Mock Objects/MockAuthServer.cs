////////////////////////////////////////////////////////////////////////////////
// MockAuthServer.cs - Module to mock the Auth Server Functionality           //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Hao Shen, Fall 2011, Syracuse University                     //
//               hshen01@syr.edu                                              //
////////////////////////////////////////////////////////////////////////////////

/*
Module Operations: 
==================
The module ensures that is used to mock up the auth server for the Client API. The module 
 * implements the IAuthServer. The CreateUser function is responsible to create new users by
 * the administrator. The Authenticate function is resposible to authenticate the username 
 * password when the user logins in.
 
Public Interface
=================
MockAuthServer m_MockAuthServerObj = new MockAuthServer();
 * m_MockAuthServerObj. CreateUser(string newUser, string newUserPwd, string userName, string pwd)
 * m_MockAuthServerObj. Authenticate(string userName, string originalPwd, out string token)
Build Process
================
 * 
 * 
 Required Files:
===================
 * IAuthServer.cs


Maintenance History:
====================
ver 1.0 : 17 October 2011

*/

using System;
using System.Collections.Generic;
using edu.syr.cse784.eskimodb.sharedobjs;


namespace edu.syr.cse784.eskimodb.authserver
{
  public class MockAuthServer : IAuthServer
  {


    /// <summary>
    /// Mock auth server class to interact with the client API 
    /// </summary>
    public MockAuthServer()
    {
    }
    /// <summary>
    /// Mock function for the administrator to create new users
    /// </summary>
    /// <param name="newUser"></param>
    /// <param name="newUserPwd"></param>
    /// <param name="userName"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public AuthResult CreateUser(string newUser, string newUserPwd, string token)
    {
      AuthResult ret = new AuthResult();
      if (token != "administrator")
      {
        ret.valid = false;
        ret.msg = "only administrator can create new users";
        return ret;
      }
      else
      {
        ret.valid = true;
        ret.msg = "new user created successfully";
        return ret;
      }
    }


    /// <summary>
    /// Mock function ro check whether current user is administrator
    /// </summary>
    /// <param name="auth_token"></param>
    /// <returns></returns>
    public bool IsAdmin(string auth_token)
    {
      if (auth_token == "administrator") return true;
      else return false;
    }

    /// <summary>
    /// Mock function to authenticate the username and password and get the token
    /// </summary>
    /// <param name="newName"></param>
    /// <param name="originalPwd"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public AuthResult Authenticate(string userName, string originalPwd, out string token)
    {
      AuthResult ret = new AuthResult();
      try
      {
        if ((userName == "team1") && (originalPwd == "clientapi"))
        {
          token = "MockToken";
          ret.valid = true;
          return ret;
        }
        else
          if ((userName == "team2") && (originalPwd == "authserver"))
          {
            token = "administrator";
            ret.valid = true;
            return ret;
          }
          else
          {
            token = null;
            ret.valid = false;
            ret.msg = "username or password wrong";
            return ret;
          }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        token = null;
        return null;
      }
    }


    /// <summary>
    /// Mock function to get all existing user names
    /// <param name="token"></param>
    /// <returns></returns>
    public List<string> GetAllUserNames(string token)
    {
      List<string> ret = new List<String>();
      ret.Add("team1");
      ret.Add("team2");
      return ret;
    }


    /// <summary>
    /// Mock function to change the user privileges
    /// <param name="userName"></param>
    /// <param name="administrator"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public AuthResult ChangeUserPrivilege(string userName, bool administrator, string token)
    {

      AuthResult ret = new AuthResult();
      ret.valid = true;
      return ret;

    }

    /// <summary>
    /// Mock function to change the password of the user
    /// <param name="userName"></param>
    /// <param name="pwd"></param>
    /// <param name="token"></param>
    /// <returns></returns> 
    public AuthResult ChangePassword(string userName, string pwd, string token)
    {
      AuthResult ret = new AuthResult();
      ret.valid = true;
      return ret;

    }

  }
}
