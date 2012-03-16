using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.testinterface;

namespace edu.syr.cse784.eskimodb.authserver.test
{
    //test class for AuthManager
    class TestProgram
    {
        private int testCounter;
        private List<string> m_Msg;
        public void testFunction(bool ispass)
        {
            if (ispass)
            {
                Message m1 = new Message();
                m1.Msg = "AuthManager Testcase successfully run";
                m1.TestID = testCounter;
                m1.Passed = true;
                string m_string = m1.ToString();
                m_Msg.Add(m_string);
                testCounter++;
            }
            else
            {
                Message m1 = new Message();
                m1.Msg = "AuthManager Testcase is failed to pass";
                m1.TestID = testCounter;
                m1.Passed = false;
                string m_string = m1.ToString();
                m_Msg.Add(m_string);
                testCounter++;
            }

        }
        public bool Test()
        {
            m_Msg = new List<string>();
            AuthManager authTest = new AuthManager();
            string message;
            string testToken;
            DateTime expireTime;
            testFunction(authTest.Register("userName2", "1234567890", out message));
            testFunction(authTest.Register("userName3", "11", out message));
            testFunction(authTest.Register("userName4", "completely", out message));
            testFunction(authTest.Register("userName5", "abcdefghijklmnopqrstuvwxyx", out message));
            testFunction(authTest.Register("userName6", "123abgccadsa", out message));
            testFunction(authTest.Register("userName6", "123abgccadsa", out message));
            testFunction(authTest.Register("userName7", "_dafgaowerd", out message));
            testFunction(authTest.Register("userName8", "_12456774", out message));
            testFunction(authTest.LogIn("userName2", "1234567890", out testToken, out message));
            testFunction(authTest.TokenVerifier(testToken, out expireTime));

            return true;
        }
        public List<string> GetMessage()
        {
            return m_Msg;
        }
        /*static void Main(string[] args) 
        {
            Console.WriteLine("Demo AuthManager");
            Console.WriteLine("-----------------------------");
            Console.ReadLine();

            //foreach (string s in m_Msg)
              //  Console.WriteLine(s);

            //Console.WriteLine("Demo Constructor of AuthManager");
            AuthManager authTest = new AuthManager();
            //AuthManager authTest1 = new AuthManager("userName1", "11111111");
            //Console.ReadLine();
            //Console.WriteLine("\n");

            
            Console.WriteLine("Demo Create new account");
            string message;
            authTest.Register("userName2","1234567890",out message);
            Console.WriteLine("Trying to Create User2");
            Console.WriteLine("The return msg is shown below:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");


            authTest.Register("userName3", "11",out message);
            Console.WriteLine("Trying to create User3");
            Console.WriteLine("The return msg is shown below:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");

            authTest.Register("userName4", "completely", out message);
            Console.WriteLine("Trying to create User4");
            Console.WriteLine("The return msg is shown below:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");

            authTest.Register("userName5", "abcdefghijklmnopqrstuvwxyx", out message);
            Console.WriteLine("Trying to create User5");
            Console.WriteLine("The return msg is shown below:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");

            authTest.Register("userName6", "123abgccadsa", out message);
            Console.WriteLine("Trying to create User6");
            Console.WriteLine("The return msg is shown below:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");

            authTest.Register("userName7", "_dafgaowerd", out message);
            Console.WriteLine("Trying to create User7");
            Console.WriteLine("The return msg is shown below:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");

            authTest.Register("userName8", "_12456774", out message);
            Console.WriteLine("Trying to create User8");
            Console.WriteLine("The return msg is shown below:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Demo the Authenticate Section");
            string testToken;
            authTest.LogIn("userName2", "1234567890", out testToken, out message);
            Console.WriteLine("Trying to authenticate User2");
            Console.WriteLine("The token belongs to this account is:");
            Console.WriteLine(testToken);
            Console.WriteLine("The return message is:");
            Console.WriteLine(message);
            Console.ReadLine();
            Console.WriteLine("\n");

            Console.WriteLine("Demo the Validate Module");
            DateTime expireTime;
            Console.WriteLine("The Mock token is:");
            Console.WriteLine(testToken);
            authTest.TokenVerifier(testToken,out expireTime);
            Console.WriteLine("The retrun exp-time is:");
            Console.WriteLine(expireTime);
            Console.ReadLine();
            Console.WriteLine("\n");

            //Console.WriteLine("Demo the IsAdmin");
            //Console.WriteLine("The Mock input token is:");
            //Console.WriteLine(testToken);

           
            Console.WriteLine("End Demo");
        }*/
    }
    class AuthManagerTest
    {
        static void Main(string[] args)
        {
            TestProgram AuthMTest = new TestProgram();
            //BTest tst = new BTest();
            List<string> displaystring = null;
            AuthMTest.Test();
            displaystring = AuthMTest.GetMessage();
            foreach (string s in displaystring)
                Console.WriteLine(s);
        }
    }
}
