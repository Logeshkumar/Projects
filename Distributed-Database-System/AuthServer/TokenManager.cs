////////////////////////////////////////////////////////////////////////////////
// TokenManager.cs - Manage the tokens for login users                        //
//                                                                            //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yang Ge                                                      //    
//               Revised by Yu Gu                                                             //
////////////////////////////////////////////////////////////////////////////////

/*
  * Module Operations
  * =================
  * 
  * This class is a part of AuthServer Package, it has the interface to generate
  * token for a log in user and interface to verify if a log in user still have valid token 
  * 
  * Class TokenManager has an inner class named AuthenticationToken, it has serveral fields.
  * 1. username, 
  * 2. the real token 
  * 3. the expiration time of the token 
  * 4. a method to examine if the current token has expired or not
  * 
  * 
  * Public Interface
  * ================
  * public TokenManager()                                 //constructor, create a token database to store all valid tokens
  * public void AddToken(string token, string username)    
  *                                                         // Add token for a login user
  * public bool VerifyUserTokenValid(string token, string username)       
  *                                                         // verify if a token for a user is valid or not
  * public void AddSynchronizedToken(string token, string username, DateTime expTime)
  *                                                         // Add a token from other instances of authserver in order for synchronization
  */
/*
  * Build Process
  * =============
  * Required Files:
  *   
  * 
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 13 Oct 11
  *   - first release
  * 
  */
//

#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace edu.syr.cse784.eskimodb.authserver
{
    class TokenManager
    {
        private static List<AuthenticationToken> m_TokenDatabase;
        private Thread m_CheckExpirationThread;
        // The class to store the information of a Token
        private class AuthenticationToken
        {
            public TimeSpan m_ExpirationPeriod = new TimeSpan(0, 5, 0);         
            public AuthenticationToken(string token, string username, DateTime currenttime)
            {
                this.m_Token = token;
                this.m_Username = username;
                this.m_StartTime = currenttime;
                this.m_ExpireTime = currenttime + m_ExpirationPeriod;
            }
            // Copy constructor
            public AuthenticationToken(AuthenticationToken at)
            {
                this.m_Token = at.m_Token;
                this.m_Username = at.m_Username;
                this.m_StartTime = at.m_StartTime;
                this.m_ExpireTime = at.m_ExpireTime;
                this.m_ExpirationPeriod = at.m_ExpirationPeriod;
            }
            public string m_Token;
            public string m_Username;
            public DateTime m_StartTime;
            public DateTime m_ExpireTime;
            public bool IsExpired()
            {
                return (m_ExpireTime < DateTime.Now);
            }
        }
        // The constructor, start the CheckExpiration thread
        public TokenManager()
        {
            m_TokenDatabase = new List<AuthenticationToken>();
            m_CheckExpirationThread = new Thread(new ThreadStart(CheckExpiration));
            m_CheckExpirationThread.Start();
            while (!m_CheckExpirationThread.IsAlive) ;
        }
        // Copy constructor
        public TokenManager(TokenManager tm)
        {
            //m_TokenDatabase = new List<AuthenticationToken>(tm.m_TokenDatabase);
            m_CheckExpirationThread = new Thread(new ThreadStart(this.CheckExpiration));
            m_CheckExpirationThread.Start();
            while (!m_CheckExpirationThread.IsAlive) ;
        }
        // Add a token for a login user
        public void AddToken(string token, string username)
        {
            lock (m_TokenDatabase)
            {
                AuthenticationToken newToken = new AuthenticationToken(token, username, DateTime.Now);
                m_TokenDatabase.Add(newToken);
#if DEBUG
              //  Console.WriteLine("Generate token: " + token + ", for user: " + username + " at time: " + DateTime.Now);
#endif
            }
        }
        // The real worker to check if there are some token expired
        private void CheckExpiration() 
        {
            while (true)
            {
                Thread.Sleep(3000);
                lock (m_TokenDatabase)
                {
                    for (int i = 0; i < m_TokenDatabase.Count; ++i)
                    {
                        if (m_TokenDatabase[i].IsExpired())
                        {
#if DEBUG
                            Console.WriteLine("Delete token: " + m_TokenDatabase[i].m_Username
                                + ", for user: " + m_TokenDatabase[i].m_Token 
                                + " at time: " + DateTime.Now);
#endif
                            m_TokenDatabase.RemoveAt(i);
                            --i;
                        }
                    }
                }           
            }
        }

        public string RetrieveUserName(string token)
        {
            lock (m_TokenDatabase)
            {
                foreach (AuthenticationToken tokenInfo in m_TokenDatabase)
                {
                    if (tokenInfo.m_Token == token)
                        return tokenInfo.m_Username;
                }
                return null;
            }
        }

        // This is a token generated by other authserver, we need to add it to synchronize the data
        // among all authservers
        public void AddSynchronizedToken(string token, string username, DateTime expTime)
        {
            AuthenticationToken authtoken = null;
            lock (m_TokenDatabase) {
                authtoken = m_TokenDatabase.Find(
                    delegate(AuthenticationToken tmptoken)
                    {
                        return tmptoken.m_Token == token;
                    }
                );
                if (authtoken != null)
                {
                    authtoken.m_ExpireTime = expTime;
                }
                else
                {
                    AuthenticationToken newtoken = new AuthenticationToken(token, username, expTime);
                    newtoken.m_ExpireTime = expTime;
                    m_TokenDatabase.Add(newtoken);
                }
#if DEBUG
                Console.WriteLine("Copy token: " + token + ", for user: " + username + " at time: " + DateTime.Now);
#endif
            }
        }
        // Verify if a token for a login user valid or not
        public bool VerifyUserTokenValid(string token, out DateTime expTime)
        {
            bool flag = false;
            expTime = DateTime.Now;
            lock (m_TokenDatabase)
            {
                for (int i = 0; i < m_TokenDatabase.Count; ++i)
                {
                    if ((m_TokenDatabase[i].m_Token == token))
                    {
#if DEBUG
                        Console.WriteLine("Token valid");
#endif
                        flag = true;
                        expTime = m_TokenDatabase[i].m_ExpireTime; 
                        break;
                    }
                }
            }
#if DEBUG
            if (!flag)
            {
                Console.WriteLine("Token not valid");
            }
#endif
            return flag;
        }
        // Do the clean up work
        public void TokenManagerExit()
        {
            while (true)
            {
                if (m_TokenDatabase.Count > 0)
                {
                    Thread.Sleep(5000);
                }
                else
                {
                    m_CheckExpirationThread.Abort();
                    m_CheckExpirationThread.Join();
#if DEBUG
                    Console.WriteLine("TokenManagerExit Done!");
#endif
                    break;
                }
            }
        }
    }
}
