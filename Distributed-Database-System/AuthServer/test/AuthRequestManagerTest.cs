using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.authserver;
using System.Threading;

namespace edu.syr.cse784.eskimodb.authserver.test
{
    public class AuthRequestManagerTest
    {
        static void Main(string[] args)
        {
            Request req1 = new Request("yang", "passwwwww1", "hahah", RequestType.CreateUser, "yang");
                        
            // Test 
            AuthRequestManager authrequestmanager = new AuthRequestManager();
            authrequestmanager.EnqueueRequest(req1);
            authrequestmanager.CreateAuthManager();

            // Create another AuthManager to test if they can get the contents of the first Authmanager
            authrequestmanager.CreateAuthManager();
            authrequestmanager.CreateAuthManager();

            // Push more requests to see how the two queues handle them
            Request req2 = new Request("yu", "passwwwww2", "hoho", RequestType.CreateUser, "yu");
            Request req3 = new Request("yukan", "passwwwww3", "hehe", RequestType.CreateUser, "yukan");
            Request req4 = new Request("guokang", "passwwwww4", "huhu", RequestType.CreateUser, "guokang");
            authrequestmanager.EnqueueRequest(req2);
            authrequestmanager.EnqueueRequest(req3);
            authrequestmanager.EnqueueRequest(req4);

            Thread.Sleep(5000);
            // Now let's push some login requests
            req1 = new Request("yang", "passwwwww1", "hahah", RequestType.Authenticate, "yang");
            authrequestmanager.EnqueueRequest(req1);

            Thread.Sleep(5000);
            req1 = new Request("yang", "passwwwww1", "hahah", RequestType.Validate, "yang");
            authrequestmanager.EnqueueRequest(req1);
            authrequestmanager.EnqueueRequest(req1);
            authrequestmanager.EnqueueRequest(req1);

            // req2 = new Request("yu", "passwwwww2", "hoho", RequestType.Authenticate, "yu");
            // req3 = new Request("yukan", "passwwwww3", "hehe", RequestType.Authenticate, "yukan");
            // authrequestmanager.EnqueueRequest(req2);
            // authrequestmanager.EnqueueRequest(req3);
        }
    }
}
