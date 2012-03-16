using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.depinject;
using edu.syr.cse784.eskimodb.sharedobjs;
using System.ServiceModel;
using System.Threading;
using edu.syr.cse784.eskimodb.authserver;
using edu.syr.cse784.eskimodb.testinterface;
using edu.syr.cse784.eskimodb.executor;
using System.IO;

namespace edu.syr.cse784.eskimodb.authserver.AuthTest
{
    class TestAuthComm : testinterface.ITest
    {
        private IAuthServer channel1 = null;
        private IAuthValidate channel2 = null;
        private AuthResult authR;
        private string token = null;
        private string invalidToken = null;
        private string User1Token = null;
        private string User7Token = null;
        private List<Message> m_MsgList;
        public TestAuthComm(string url)
        {
            Startup();
            Thread.Sleep(1000);
            Console.Write("\n\n");
            DependencyInjection di = DependencyInjection.GetInstance();
            di.SetConfig("config.xml");
            Console.WriteLine("Demo AuthComm");
            Console.WriteLine("-----------------------------");
            result = new List<string>();
            authR = new AuthResult();
            m_MsgList = new List<Message>();
            // Logger.LogWrite(EskimoDBLogLevel.Verbose, "Creating");
            try
            {
                channel1 = (IAuthServer)di.CreateObject("authserv", new object[]{
                null,new BasicHttpBinding(),url});
                channel2 = (IAuthValidate)di.CreateObject("authvalid", new object[]{
                null,new BasicHttpBinding(),url});
                Console.WriteLine("Connecting to the server!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fail to connect the server!");
            }
        }

        private bool Startup()
        {
            bool ret = true;
            string dir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(@"..\..\..\AuthServer\bin\debug");
            ret = Executor.Execute(@"AuthServer.exe", new string[] { "http://localhost:8080/IComm" });
            Directory.SetCurrentDirectory(dir);
            return ret;
        }

        private bool test1()
        {
            Message test1 = new Message();
            test1.TestID = 1;
            test1.Passed = false;
            Console.WriteLine("Demo WCF Using Authenticate!");
            try
            {
                authR = channel1.Authenticate("team1", "clientapi", out token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (authR.valid)
                test1.Msg = "The Authenticate is passed!";
            else
                test1.Msg = "The Authenticate is failed!";
            Console.WriteLine(test1.Msg);
            test1.Passed = authR.valid;
            m_MsgList.Add(test1);
            return test1.Passed;
        }

        private bool test2()
        {
            Message test2 = new Message();
            test2.TestID = 2;
            test2.Passed = false;
            Console.WriteLine("Demo WCF Using Authenticate!");
            try
            {
                authR = channel1.Authenticate("team1", "123456789", out invalidToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test2.Msg = "The Authenticate is passed!";
            else
                test2.Msg = "The Authenticate is failed!";
            Console.WriteLine(test2.Msg);
            if (authR.valid == false)
                test2.Passed = true;
            m_MsgList.Add(test2);
            return test2.Passed;
        }

        private bool test3()
        {
            Message test3 = new Message();
            test3.TestID = 3;
            test3.Passed = false;
            Console.WriteLine("Demo WCF using IsAdmin");
            try
            {
                test3.Passed = channel1.IsAdmin(token);
                if (test3.Passed)
                    test3.Msg = "The IsAdmin is passed!";
                else
                    test3.Msg = "The IsAdmin is failed!";
                Console.WriteLine(test3.Msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            m_MsgList.Add(test3);
            return test3.Passed;
        }

        private bool test4()
        {
            Message test4 = new Message();
            test4.TestID = 4;
            test4.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User1", "123412341234", token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (authR.valid)
                test4.Msg = "Create User1 Case has been passed!";
            else
                test4.Msg = "Create User1 Case has been failed!";
            Console.WriteLine(test4.Msg);
            test4.Passed = authR.valid;
            m_MsgList.Add(test4);
            return test4.Passed;
        }

        private bool test5()
        {
            Message test5 = new Message();
            test5.TestID = 5;
            test5.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User2", "123123321321", token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (authR.valid)
                test5.Msg = "Create User2 Case has been passed!";
            else
                test5.Msg = "Create User2 Case has been failed!";
            Console.WriteLine(test5.Msg);
            test5.Passed = authR.valid;
            m_MsgList.Add(test5);
            return test5.Passed;
        }

        private bool test6()
        {
            Message test6 = new Message();
            test6.TestID = 6;
            test6.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User3", "123456", token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test6.Msg = "Create User3 Case has been passed!";
            else
                test6.Msg = "Create User3 Case has been failed!";
            Console.WriteLine(test6.Msg);
            if (authR.valid == false)
                test6.Passed = true;
            m_MsgList.Add(test6);
            return test6.Passed;
        }

        private bool test7()
        {
            Message test7 = new Message();
            test7.TestID = 7;
            test7.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User4", "completely", invalidToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test7.Msg = "Create User4 Case has been passed!";
            else
                test7.Msg = "Create User3 Case has been failed!";
            Console.WriteLine(test7.Msg);
            if (authR.valid == false)
                test7.Passed = true;
            m_MsgList.Add(test7);
            return test7.Passed;
        }

        private bool test8()
        {
            Message test8 = new Message();
            test8.TestID = 8;
            test8.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User5", "completely", invalidToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test8.Msg = "Create User5 Case has been passed!";
            else
                test8.Msg = "Create User5 Case has been failed!";
            Console.WriteLine(test8.Msg);
            if (authR.valid == false)
                test8.Passed = true;
            m_MsgList.Add(test8);
            return test8.Passed;
        }

        private bool test9()
        {
            Message test9 = new Message();
            test9.TestID = 9;
            test9.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User6", "abcdefghijklmnopqrstuvwxyx", invalidToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test9.Msg = "Create User6 Case has been passed!";
            else
                test9.Msg = "Create User6 Case has been failed!";
            Console.WriteLine(test9.Msg);
            if (authR.valid == false)
                test9.Passed = true;
            m_MsgList.Add(test9);
            return test9.Passed;
        }

        private bool test10()
        {
            Message test10 = new Message();
            test10.TestID = 10;
            test10.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User7", "_12456774", token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (authR.valid)
                test10.Msg = "Create User7 Case has been passed!";
            else
                test10.Msg = "Create User7 Case has been failed!";
            Console.WriteLine(test10.Msg);
            test10.Passed = authR.valid;
            m_MsgList.Add(test10);
            return test10.Passed;
        }

        private bool test11()
        {
            Message test11 = new Message();
            test11.TestID = 11;
            test11.Passed = false;
            Console.WriteLine("Demo WCF using Create user");
            try
            {
                authR = channel1.CreateUser("User8", "_12456774", invalidToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test11.Msg = "Create User8 Case has been passed!";
            else
                test11.Msg = "Create User8 Case has been failed!";
            Console.WriteLine(test11.Msg);
            if (authR.valid == false)
                test11.Passed = true;
            m_MsgList.Add(test11);
            return test11.Passed;
        }

        private bool test12()
        {
            Console.WriteLine("Demo the privilege changing function");
            Message test12 = new Message();
            test12.TestID = 12;
            test12.Passed = false;
            try
            {
                authR = channel1.ChangeUserPrivilege("User7", true, token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (authR.valid)
                test12.Msg = "Changing Privilege of User7 Case is passed!";
            else
                test12.Msg = "Changing Privilege of User7 Case is failed!";
            Console.WriteLine(test12.Msg);
            test12.Passed = authR.valid;
            m_MsgList.Add(test12);
            return test12.Passed;
        }

        private bool test13()
        {
            Console.WriteLine("Demo the privilege changing function");
            Message test13 = new Message();
            test13.TestID = 13;
            test13.Passed = false;
            try
            {
                channel1.Authenticate("User1", "123412341234", out User1Token);
                authR = channel1.ChangeUserPrivilege("User1", true, User1Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test13.Msg = "Changing Privilege of User1 Case is passed!";
            else
                test13.Msg = "Changing Privilege of User1 Case is failed!";
            Console.WriteLine(test13.Msg);
            if (authR.valid == false)
                test13.Passed = true;
            m_MsgList.Add(test13);
            return test13.Passed;
        }

        private bool test14()
        {
            Console.WriteLine("Demo the Validate Module");
            Message test14 = new Message();
            test14.TestID = 14;
            test14.Passed = false;
            List<string> users = new List<string>();
            try
            {
                users = channel1.GetAllUserNames(token);
                test14.Passed = true;
                test14.Msg = "Get all the user name and Case is Passed!";
                Console.WriteLine(test14.Msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                test14.Passed = false;
            }
            foreach (string user in users)
            {
                Console.WriteLine(user);
            }
            m_MsgList.Add(test14);
            return test14.Passed;
        }

        private bool test15()
        {
            Console.WriteLine("Demo Change password");
            Message test15 = new Message();
            test15.TestID = 15;
            test15.Passed = false;

            try
            {
                channel1.Authenticate("User7", "_12456774", out User7Token);
                authR = channel1.ChangePassword("User7", "123123123123", User7Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (authR.valid)
                test15.Msg = "The Change password Case is passed!";
            else
                test15.Msg = "The Change password Case is failed!";
            Console.WriteLine(test15.Msg);
            test15.Passed = authR.valid;
            m_MsgList.Add(test15);
            return test15.Passed;
        }

        private bool test16()
        {
            Console.WriteLine("Demo Change password");
            Message test16 = new Message();
            test16.TestID = 16;
            test16.Passed = false;
            try
            {
                channel1.Authenticate("User1", "123412341234", out User1Token);
                authR = channel1.ChangePassword("User1", "123", User1Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (!authR.valid)
                test16.Msg = "The change password Case is passed!";
            else
                test16.Msg = "The change password Case is failed!";
            Console.WriteLine(test16.Msg);
            if (authR.valid == false)
                test16.Passed = true;
            m_MsgList.Add(test16);
            return test16.Passed;
        }
        private bool test17()
        {
            Console.WriteLine("Demo validate!");
            Message test17 = new Message();
            test17.TestID = 17;
            test17.Passed = false;
            DateTime dT = new DateTime();
            try
            {
                test17.Passed = channel2.Validate(token, out dT);
                Console.WriteLine("\nThe expire time is:");
                Console.WriteLine(dT.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            if (test17.Passed)
                test17.Msg = "The Validate Case is passed!";
            else
                test17.Msg = "The Validate Case is Failed";
            Console.WriteLine(test17.Msg);
            m_MsgList.Add(test17);
            return test17.Passed;
        }

        public bool Test()
        {
            bool ret = true;
            test1();
            test2();
            test3();
            test4();
            test5();
            test6();
            test7();
            test8();
            test9();
            test10();
            test11();
            test12();
            test13();
            test14();
            test15();
            test16();
            test17();
            foreach (Message msg in m_MsgList)
            {
                ret = ret & msg.Passed;
                if (msg.Passed == false)
                    Console.WriteLine("Fail to pass " + msg.TestID);
            }
            return ret;
        }

        public List<string> GetMessage()
        {
            foreach (Message msg in m_MsgList)
            {
                result.Add(msg.ToString());
            }
            return result;
        }

        private List<string> result;
        static void Main(string[] args)
        {
            TestAuthComm ts = new TestAuthComm(args[1]);

            if (ts.Test())
            {
                Console.WriteLine("\n\nThe Result:");
                Console.WriteLine("Test Cases are all passed!\n\n");
            }
            List<string> temp = new List<string>();
            temp = ts.GetMessage();
            foreach (string msg in temp)
            {
                Console.WriteLine(msg);
            }
            Console.WriteLine("End Demo");
        }
    }
}
