using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.authserver.test
{
    class CredentialFileTest
    {
        static void Main(string[] args)
        {
            HarshCodeConverter converter = new HarshCodeConverter();
            string username = "user1";
            string password = "password1";
            string saltTag = "saltTag1";
            password = converter.Convert(password + saltTag);
            CredentialFile credentialfile = new CredentialFile();
            credentialfile.AddUser(username, password, saltTag);
            username = "user2";
            password = "password2";
            saltTag = "saltTag2";
            password = converter.Convert(password + saltTag);
            credentialfile.AddUser(username, password, saltTag);
            credentialfile.CheckPasswordExists("password");
            credentialfile.CheckPasswordExists("password1");
            credentialfile.CheckUserExists("User");
            credentialfile.CheckUserExists("user2");
            credentialfile.UserAuthenticate("user1", "password1");
            credentialfile.UserAuthenticate("user2", "password1");
            // Test Constructor
            CredentialFile cf2 = new CredentialFile(credentialfile);
        }
    }
}
