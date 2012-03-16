////////////////////////////////////////////////////////////////////////////////
// AuthManager.cs - Manager and control the whole Auth Server System          //
//                                                                            //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yu Gu,   Syracuse University                                 //
//               315-751-7158, ygu06@syr.edu                                  //
// Modified by:  Yang Ge, Syracuse Univerity, yage@syr.edu                    //
////////////////////////////////////////////////////////////////////////////////

/*
  * Module Operations
  * =================
  * 
  * This class is a part of AuthServer Package, it act as an exec part of the AuthServer,
  * it organizes each modules and call them.
  * 
  * 
  * 
  * Public Interface
  * ================
  * public AuthManager(string userName, string passWd)      //constructor
  * public void Register(string userName, string passWd)    //register module, create a new user's account
  * public void LogIn(string userName, string passWd)       //Login module, verify the username and password
  * public bool TokenVerifier(string token, out DateTime expTime)
  *                                                         // verify a token is exsited or not
  * public string RetrieveUserName(string token)            // Get the user name according to the token
  * public bool IsAdmin(string userName)                    // judge whether the user is an administrator or not
  * public List<string> GetAllUserNames()                   // get all the users' name in the Auth Server
  * public bool ChangeUserPrivilege(string userName, bool administrator, out string msg)
  *                                                         // change the privilege of a user
  * public bool ChangePwd(string userName, string pwd, out string msg)
  *                                                         // change password of a user 
  */
/*
  * Build Process
  * =============
  * Required Files:
  *   CredentialFile.cs
  *   VerifyPassword.cs
  *   TagAdder.cs
  *   ConsoleUserInterface.cs
  * 
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 13 Oct 11
  *   - first release
  * ver 2.0 : 5 Dec 11
  *   - add more method in order to implement the WCF 
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;

namespace edu.syr.cse784.eskimodb.authserver
{
    public class AuthManager
    {
        /// <summary>
        /// constructor
        /// </summary>
        public AuthManager() 
        {
            m_File = new CredentialFile();
            m_TokenMgr = new TokenManager();
        }
         //Copy Constructor
        public AuthManager(AuthManager am)
        {
            //m_File = new CredentialFile(am.m_File);
            //m_TokenMgr = new TokenManager(am.tokenMgr);
        }

        /// <summary>
        /// register for a new account
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="passWd">password</param>
        /// <param name="msg">the return message</param>
        /// <returns>registeration is successful or not</returns>
        public bool Register(string userName, string passWd, out string msg)
        {                      
            // judge the existence of the username and password
            if (m_File.CheckUserExists(userName))
            {
                msg = "User Name has already existed!";
                Console.WriteLine(msg);
                return false;
            }
            if (m_File.CheckPasswordExists(passWd))
            {
                msg = "Password has already existed!";
                Console.WriteLine(msg);
                return false;
            }
            //verify the password is valid or not here
            VerifyPassword passwdVerifier = new VerifyPassword();
            if (!passwdVerifier.CheckPassword(passWd,out msg))
            {
               
                Console.WriteLine(msg);
                return false;
            }
            //add salt to the password
            TagAdder salt = new TagAdder(passWd);
            string harshedPasswd = salt.AddSalt();
            string tag = salt.GetTag();
            //save username and password to the file
            m_File.AddUser(userName, harshedPasswd, tag);
            msg = "Successfully Create a new account!";
            //Console.WriteLine(msg);
            return true;
        }

        /// <summary>
        /// log into an account
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="passWd">password</param>
        /// <param name="token">return a token if log in action is successful</param>
        /// <param name="msg">the return msg of log in</param>
        /// <returns>log in is successful or not</returns>
        public bool LogIn(string userName, string passWd, out string token, out string msg) 
        {
            // Initial the token and msg, assume they are not valid
            token = null;
            msg = "Fail to Log in";
           
            // verify the username and password here
            if (m_File.UserAuthenticate(userName, passWd))
            {
                // Produce token for the valid user
                token = TokenProducer(userName);
                msg = "Successfully Log in";
                //Console.WriteLine(msg);
                return true;
            }
            return false;
        }

        /// <summary>
        /// verify the token is exsited or not
        /// </summary>
        /// <param name="token">the token of the current user</param>
        /// <param name="expTime">the exp time of the token</param>
        /// <returns>valid token or not</returns>
        public bool TokenVerifier(string token, out DateTime expTime)
        {
            return m_TokenMgr.VerifyUserTokenValid(token, out expTime);
        }

        /// <summary>
        /// create a new token
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>a new token</returns>
        private string TokenProducer(string userName) 
        {
            string ret;
            RandTokenGen temp = new RandTokenGen();
            ret = temp.Generator();
            m_TokenMgr.AddToken(ret, userName);   
            return ret;
        }

        public void AddSynchronizedToken(string token, string username, DateTime expTime)
        {
            m_TokenMgr.AddSynchronizedToken(token, username, expTime);
        }

        /// <summary>
        /// Retrieve the user name of the input token
        /// </summary>
        /// <param name="token">the current token</param>
        /// <returns>the user name</returns>
        public string RetrieveUserName(string token) 
        {
            return m_TokenMgr.RetrieveUserName(token);
        }

        /// <summary>
        /// judge whether the user is an administrator or not
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>is or is not an administrator</returns>
        public bool IsAdmin(string userName) 
        {
            return m_File.CheckAdmin(userName);
        }

        /// <summary>
        /// retrieve all the users' name in the auth server
        /// </summary>
        /// <returns> a list of all the users' name</returns>
        public List<string> GetAllUserNames() 
        {
            return m_File.RetrieveAllUserNames();
        }

        /// <summary>
        /// change the privilege of a user
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="administrator">is an administrator or not</param>
        /// <param name="msg">the return message</param>
        /// <returns>success or not</returns>
        public bool ChangeUserPrivilege(string userName, bool administrator, out string msg) 
        {
            return m_File.ChangePrivilege(userName, administrator, out msg);
        }

        /// <summary>
        /// Change the password of a user
        /// </summary>
        /// <param name="userName">user name </param>
        /// <param name="pwd"> new password </param>
        /// <param name="msg"> the ruturn message of this action </param>
        /// <returns>success or not</returns>
        public bool ChangePwd(string userName, string pwd, out string msg) 
        {
            //verify the password is valid or not here
            VerifyPassword passwdVerifier = new VerifyPassword();
            if (!passwdVerifier.CheckPassword(pwd, out msg))
            {
                Console.WriteLine(msg);
                return false;
            }
            //add salt to the password
            TagAdder salt = new TagAdder(pwd);
            string harshedPasswd = salt.AddSalt();
            string tag = salt.GetTag();
            //save username and password to the file
            m_File.ChangePwd(userName, pwd, tag);
            msg = "Successfully Change the Password!";
            //Console.WriteLine(msg);
            return true;
        }

        private static CredentialFile m_File;
        private static TokenManager m_TokenMgr;
    }
}