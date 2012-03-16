// VerifyPasswordTest.cs - Test VerifyPassword.cs                         //
// Language:     C# 4.0                                                       //
// Platform:     Windows Vista                                                //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yukan Zhang,   Syracuse University                           //
//               yzhan158@syr.edu                                             //
////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.authserver.test
{
    class VerifyPasswordTest
    {
        static void Main(string[] args)
        {
            string test1 = "12feet";
            string test2 = "pr;ctices";
            string test3 = "absolutely";
            string test4 = "abcdefghijklmnopq";
            bool Resolve;
            string resultMsg =null;
            VerifyPassword verifypassword = new VerifyPassword();
            Resolve = verifypassword.CheckPassword(test1,out resultMsg);
            Resolve = verifypassword.CheckPassword(test2, out resultMsg);
            Resolve = verifypassword.CheckPassword(test3, out resultMsg);
            Resolve = verifypassword.CheckPassword(test4, out resultMsg);
            Resolve = verifypassword.CheckPassword("design1234", out resultMsg);

        }
    }

}
