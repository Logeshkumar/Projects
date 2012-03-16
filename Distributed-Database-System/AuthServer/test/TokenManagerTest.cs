using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace edu.syr.cse784.eskimodb.authserver.test
{
    class TokenManagerTest
    {
        static void Main(string[] args)
        {
            TokenManager tokenManager = new TokenManager();
            tokenManager.AddToken("yukan", "YukanZhang");
            DateTime dt = DateTime.Now;
            tokenManager.VerifyUserTokenValid("yukan", out dt);
            tokenManager.AddToken("yang", "YangGe");
            tokenManager.VerifyUserTokenValid("yukan", out dt);
            
            // Test Constructor
            TokenManager tm2 = new TokenManager(tokenManager);
            tm2.VerifyUserTokenValid("yang", out dt);
            tm2.VerifyUserTokenValid("yukan", out dt);

            Thread.Sleep(20);
            tokenManager.TokenManagerExit();
            tm2.TokenManagerExit();
        }
    }
}
