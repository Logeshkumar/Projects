////////////////////////////////////////////////////////////////////////////////
// AuthManager.cs - Manager and control the whole Auth Server System          //
//                                                                            //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yu Gu,   Syracuse University                                 //
//               315-751-7158, ygu06@syr.edu                                  //
////////////////////////////////////////////////////////////////////////////////

/*
  * Module Operations
  * =================
  * 
  * This file is a part of AuthServer, it is used for the communication between AuthServer and Client API or RootServer
  * This code is implemented by WCF(Windos Communication Foundation), the contracts are IAuthServer.cs and IAuthValidate.cs
  * 
  * 
  * Public Interface
  * ================
  * public AuthCommService()                                      //constructor
  * public static ServiceHost CreateChannel(string address)       //Create a channel, build up a host
  * public bool Validate(string token, out DateTime exptime)      //Used by the RootServer, validate the token of certain account
  *                                                                 and return a expire datetime 
  * public AuthResult CreateUser(string newUser, string newUserPwd, string token)
  *                                                               //Create a new account, only the adminstrator can create a new
  *                                                                 This function is used by Client API
  * public bool IsAdmin(string auth_token)                        //Judge whether the current user is adminstrator or not
  * public AuthResult Authenticate(string userName, string pwd, out string token)
  *                                                               //authenticate the current server, if it is valid, return a new token
  *                                                                 or return a null token.
  * public List<string> GetAllUserNames(string token)             //retrieve all the username in the AuthServer                                                                
  * public AuthResult ChangeUserPrivilege(string userName, bool administrator, string token)
  *                                                               // Change the privilege of the user 
  * public AuthResult ChangePassword(string userName, string pwd, string token)
  *                                                               // Change the password of the user
  *                                                                 
  */
/*
  * Build Process
  * =============
  * Required Files:
  *   AuthManger.cs
  *   IAuthServer.cs
  *   IAuthValidate.cs
  * 
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 5 Dec 11
  *   - first release
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.authserver
{
    /// <summary>
    /// This class implement the Service Contract IAuthServer and IAuthValidate
    /// </summary>
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    class AuthCommService:  sharedobjs.IAuthServer, sharedobjs.IAuthValidate
    {
        private AuthManager AuthMgr;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        public AuthCommService() 
        {
            AuthMgr = new AuthManager();
        }
        
        /// <summary>
        /// build up a host
        /// </summary>
        /// <param name="address">the address of the local host</param>
        /// <returns></returns>
        public static ServiceHost CreateChannel(string address)
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            Uri baseAddress = new Uri(address);
            ServiceHost ret = new ServiceHost(typeof(AuthCommService), baseAddress);
            ret.AddServiceEndpoint(typeof(IAuthServer), binding, baseAddress);
            ret.AddServiceEndpoint(typeof(IAuthValidate), binding, baseAddress);
            return ret;
        }

        /// <summary>
        /// Validate the current user, if it exists, return the expired time
        /// </summary>
        /// <param name="token">the token of the current user</param>
        /// <param name="exptime">the expire time of the token</param>
        /// <returns>if the token exists, return true, else return false</returns>
        public bool Validate(string token, out DateTime exptime) 
        {
            Console.Write("\n");
            Console.WriteLine("Verify the token...");
            Console.Write("\n");
            //call AuthMgr to verify the token
            return AuthMgr.TokenVerifier(token, out exptime); 
        }

        /// <summary>
        /// Create a new user, the input token should indicate an adminstrator
        /// </summary>
        /// <param name="newUser">new user name</param>
        /// <param name="newUserPwd">new password</param>
        /// <param name="token">the adminstrator's token</param>
        /// <returns>the result of createUser</returns>
        public AuthResult CreateUser(string newUser, string newUserPwd, string token) 
        {
            Console.Write("\n");
            Console.WriteLine("Create a new user...");
            Console.Write("\n");
            string tempMsg = null;
            AuthResult ret = new AuthResult();
            string tempUser = AuthMgr.RetrieveUserName(token);
            if (tempUser == null)
            {
                ret.msg = "Token expired or not existed!";
                ret.valid = false;
                Console.WriteLine(ret.msg);
                return ret;
            }
            // judge whether the current user is an adminstrator or not
            if (AuthMgr.IsAdmin(tempUser))
            {
                // call AuthMgr's function "Register" to create a new account
                ret.valid = AuthMgr.Register(newUser, newUserPwd, out tempMsg);
                ret.msg = tempMsg;
                Console.WriteLine(ret.msg);
                return ret;
            }
            else 
            {
                ret.msg = "Only the adminstrator can create a new user!";
                ret.valid = false;
                Console.WriteLine(ret.msg);
                return ret;
            }
        }

        /// <summary>
        /// Judge whether the current user is an adminstrator or not
        /// </summary>
        /// <param name="auth_token">input token</param>
        /// <returns></returns>
        public bool IsAdmin(string auth_token) 
        {
            Console.Write("\n");
            Console.WriteLine("Judge is adminstrator or not...");
            Console.Write("\n");
            bool ret = AuthMgr.IsAdmin(AuthMgr.RetrieveUserName(auth_token));
            if (ret == true)
                Console.WriteLine("The User is Admin!");
            else
                Console.WriteLine("The User is not Admin!");
            return ret;
        }


        /// <summary>
        /// authenticate whether the user is exsited
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="pwd">user's password</param>
        /// <param name="token">if the user exsited, return a token</param>
        /// <returns>the result of Authentication</returns>
        public AuthResult Authenticate(string userName, string pwd, out string token) 
        {
            Console.Write("\n");
            Console.WriteLine("Authenticate the userName and password...");
            Console.Write("\n");
            AuthResult ret = new AuthResult();
            string temp = null;
            // call the method in AuthMgr to authenticate the account
            ret.valid =AuthMgr.LogIn(userName, pwd, out token, out temp);            
            ret.msg = temp;
            return ret;
        }

        /// <summary>
        /// Retrieve all the user name in the authServer
        /// </summary>
        /// <param name="token">the token should indicate an adminstrator</param>
        /// <returns>a list of all the users, if the token is not valid, return a null list</returns>
        public List<string> GetAllUserNames(string token) 
        {
            Console.Write("\n");
            Console.WriteLine("Retrieve all the user name in the AuthServer...");
            Console.Write("\n");
            //Judge whether the token is an adminstrator or not
            if (AuthMgr.IsAdmin(AuthMgr.RetrieveUserName(token)))
                return AuthMgr.GetAllUserNames();
            else
                return null;
        }

        /// <summary>
        /// Change the privilege of a user
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="administrator">is an administrator or not</param>
        /// <param name="token"> the token of current user</param>
        /// <returns>the result of changing the privilege</returns>
        public AuthResult ChangeUserPrivilege(string userName, bool administrator, string token) 
        {
            Console.Write("\n");
            Console.WriteLine("Try to change the privilege of " +userName + " ...");
            Console.Write("\n");
            AuthResult ret = new AuthResult();
            // judge whether the token is a administrator or not
            if (AuthMgr.IsAdmin(AuthMgr.RetrieveUserName(token)))
                ret.valid = AuthMgr.ChangeUserPrivilege(userName, administrator, out ret.msg);
            else 
            {
                ret.valid = false;
                ret.msg = "Token is not valid";
            }
            Console.Write("\n");
            Console.WriteLine(ret.msg + "\n");
            return ret; 
        }

        /// <summary>
        /// Change password of a user
        /// </summary>
        /// <param name="userName">user name</param>
        /// <param name="pwd">new password</param>
        /// <param name="token">the token of the user</param>
        /// <returns>the result of changing password</returns>
        public AuthResult ChangePassword(string userName, string pwd, string token) 
        {
            Console.Write("\n");
            Console.WriteLine("Try to change the password of " + userName + " ...");
            Console.Write("\n");
            AuthResult ret = new AuthResult();
            // judge whether the token is an administrator or not, administrator can change anybody's password
            if (AuthMgr.IsAdmin(AuthMgr.RetrieveUserName(token)))
            {
                ret.valid = AuthMgr.ChangePwd(userName, pwd, out ret.msg);
                Console.WriteLine("\nChange password of " + userName + "\n");
                return ret; 
            }
            // judge whether the token match the userName, the current user can change its password
            else if (AuthMgr.RetrieveUserName(token) == userName)
            {
                ret.valid = AuthMgr.ChangePwd(userName, pwd, out ret.msg);
                Console.WriteLine("\n"+ret.msg+"\n");
                return ret;
            }
            else
            {
                ret.valid = false;
                ret.msg = "Token is not valid!";
                Console.WriteLine("\n"+ret.msg+"\n");
                return ret;
            } 
        }

        public static void Main(string[] args)
        {
            Console.Write("\n  Auth Server Starting up");
            Console.Write("\n ==================================\n");
            
            try
            {
                //build up a new host
                //Uri address = new Uri("http://localhost:8080/IComm");
                Uri address = new Uri(args[0]);
                ServiceHost host = CreateChannel(address.ToString());
                host.Open();
                Console.WriteLine("Service host has successfully built");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Cannot build the host");
            }
            string line = null;
            while (line != "quit")
            {
                line = Console.ReadLine();
            }
        }

    }
}
