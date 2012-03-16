////////////////////////////////////////////////////////////////////////////////
// AuthImplement.cs - The implement of the interfaces of AuthServer           //
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
  * This class is the implement of interface of AuthServer, AuthImplement inherits interface
  * IAuthServer and interface IAuthValidate
  * 
  * 
  * 
  * Public Interface
  * ================
  * public AuthImplement(AuthManager mgr)                       // constructor
  * public bool Validate(string token, out DateTime ExpTime)    // verify the token, if the token exsits, return the 
  *                                                                expire date of the token. Else return false 
  * public AuthResult CreateUser(string newUser, string newUserPwd, string token)           
  *                                                             // Create a new user account if the token is valid
  * public bool IsAdmin(string auth_token)                      // judge whether the current user is adminstrator or not
  *
  * public AuthResult Authenticate(string userName, string pwd, out string token)
  *                                                             //  judge whether the user account exsits or not,
  */
/*
  * Build Process
  * =============
  * Required Files:
  *   IAuthServer.cs
  *   IAuthValidate.cs
  * 
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 13 Oct 11
  *   - first release
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.authserver
{
    public class AuthImplement //: IAuthServer, IAuthValidate
    {
        public AuthImplement(AuthManager mgr) 
        {
            m_Mgr = mgr;     
        }

        public bool Validate(string token, out DateTime ExpTime) 
        {
            return m_Mgr.TokenVerifier(token, out ExpTime);
        }

        public AuthResult CreateUser(string newUser, string newUserPwd, string token)
        {
            AuthResult authret = new AuthResult();
            //string msg = "";
            authret.valid = m_Mgr.Register(newUser, newUserPwd, out authret.msg);
            return authret;
        }

        // Not finished, needs to be done
        public bool IsAdmin(string auth_token)
        {
            return true;
        }

        public AuthResult Authenticate(string userName, string pwd, out string token)
        {
            AuthResult authret = new AuthResult();
            //string msg = "";
            authret.valid = m_Mgr.LogIn(userName, pwd, out token, out authret.msg);
            return authret;
        }

        // Not finished, needs to be done
        public List<string> GetAllUserNames(string token)
        {
            List<string> allUserName = new List<string>();
            return allUserName;
        }

        // Not finished, needs to be done
        public AuthResult ChangeUserPrivilege(string userName, bool administrator, string token)
        {
            AuthResult authret = new AuthResult();
            return authret;
        }
        
        // Not finished, needs to be done
        public AuthResult ChangePassword(string userName, string pwd, string token)
        {
            AuthResult authret = new AuthResult();
            return authret;
        }

        private AuthManager m_Mgr;
    }
}
