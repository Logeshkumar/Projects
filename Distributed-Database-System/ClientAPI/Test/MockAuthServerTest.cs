////////////////////////////////////////////////////////////////////////////////
// MockAuthServerTest.cs - Module to test the Mock Auth Server Functionality  //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Hao Shen, Fall 2011, Syracuse University                     //
//               hshen01@syr.edu                                              //
////////////////////////////////////////////////////////////////////////////////

/*
Module Operations: 
==================
The module ensures that is used to mock up the auth server for the Client API. The module 
 * implements the IAuthServer. The test function will return true if the test passes.
 
Public Interface
=================
MockAuthServerTest m_MockAuthServerTestObj = new MockAuthServerTest();
 * m_MockAuthServerTestObj. test();

Build Process
================
 * 
 * 
 Required Files:
===================
 * IAuthServer.cs
 * MockAuthServer.cs

Maintenance History:
====================
ver 1.0 : 17 October 2011

*/

using System;
using System.Collections.Generic;
using edu.syr.cse784.eskimodb.authserver;
using edu.syr.cse784.eskimodb.sharedobjs;
using ITestInterface;

namespace edu.syr.cse784.eskimodb.clientapi
{


  /// <summary>
  /// Mock auth server test class which implements the ITest interface.
  /// </summary>
  class MockAuthServerTest : ITestInterface.ITest
  {
    MockAuthServer m_AuthServer;
    private List<string> m_Msg;
    string m_string1, m_string2, m_string3, m_string4, m_string5, m_string6, m_string7, m_string8, m_string9;
    /// <summary>
    /// Constructor for initialization 
    /// </summary>
    public MockAuthServerTest()
    {
      m_Msg = new List<string>();
    }

    //test1
    private string Test1()
    {
      //test1
      m_AuthServer = new MockAuthServer();
      Message m1 = new Message();
      m1.TestID = 1;
      AuthResult result0 = m_AuthServer.CreateUser("hshen", "hshen", "hshen");
      if (result0.valid)
      {
        m1.Passed = false;
        m1.Msg = "AuthServer.CreateUser() test1 fails";
      }
      else
      {
        m1.Passed = true;
        m1.Msg = "AuthServer.CreateUser() test1 succeeds";
      }
      return m1.ToString();
    }

    //test2
    private string Test2()
    {
      m_AuthServer = new MockAuthServer();
      Message m2 = new Message();
      m2.TestID = 2;
      AuthResult result2 = m_AuthServer.CreateUser("hshen", "hshen", "administrator");
      if (!result2.valid)
      {
        m2.Passed = false;
        m2.Msg = "AuthServer.CreateUser() test2 fails";
      }
      else
      {
        m2.Passed = true;
        m2.Msg = "AuthServer.CreateUser() test2 succeeds";
      }
      return m2.ToString();
    }
    //test3
    private string Test3()
    {
      m_AuthServer = new MockAuthServer();
      Message m3 = new Message();
      m3.TestID = 3;
      if (m_AuthServer.IsAdmin("hshen"))
      {
        m3.Passed = false;
        m3.Msg = "AuthServer.IsAdmin() test1 fails";
      }
      else
      {
        m3.Passed = true;
        m3.Msg = "AuthServer.IsAdmin() test1 succeeds";
      }
      return m3.ToString();

    }
    //test4
    private string Test4()
    {
      m_AuthServer = new MockAuthServer();
      Message m4 = new Message();
      m4.TestID = 4;
      if (!m_AuthServer.IsAdmin("administrator"))
      {
        m4.Passed = false;
        m4.Msg = "AuthServer.IsAdmin() test2 fails";
      }
      else
      {
        m4.Passed = true;
        m4.Msg = "AuthServer.IsAdmin() test2 succeeds";
      }
      return m4.ToString();
    }
    //test5
    private string Test5()
    {
      m_AuthServer = new MockAuthServer();
      string out_token;
      Message m5 = new Message();
      m5.TestID = 5;
      AuthResult result3 = m_AuthServer.Authenticate("hshen", "hshen", out out_token);
      if (result3.valid)
      {
        m5.Passed = false;
        m5.Msg = "AuthServer.Authenticate test1 fails";
      }
      else
      {
        m5.Passed = true;
        m5.Msg = "AuthServer.Authenticate test1 succeeds";
      }
      return m5.ToString();

    }
    //test6
    private string Test6()
    {
      m_AuthServer = new MockAuthServer();
      string out_token;
      Message m6 = new Message();
      m6.TestID = 6;
      AuthResult result4 = m_AuthServer.Authenticate("team1", "clientapi", out out_token);
      if (!result4.valid || out_token != "MockToken")
      {
        m6.Passed = false;
        m6.Msg = "AuthServer.Authenticate test2 fails";
      }
      else
      {
        m6.Passed = true;
        m6.Msg = "AuthServer.Authenticate test2 succeeds";
      }
      return m6.ToString();

    }
    //test7
    private string Test7()
    {
      m_AuthServer = new MockAuthServer();
      Message m7 = new Message();
      m7.TestID = 7;
      List<string> result5 = m_AuthServer.GetAllUserNames("MockToken");
      if (result5[0] != "team1" || result5[1] != "team2")
      {
        m7.Passed = false;
        m7.Msg = "AuthServer.GetAllUserNames fails";
      }
      else
      {
        m7.Passed = true;
        m7.Msg = "AuthServer.GetAllUserNames succeeds";
      }
      return m7.ToString();

    }
    //test8
    private string Test8()
    {
      m_AuthServer = new MockAuthServer();
      Message m8 = new Message();
      m8.TestID = 8;
      AuthResult result6 = m_AuthServer.ChangeUserPrivilege("hshen", true, "MockToken");
      if (!result6.valid)
      {
        m8.Passed = false;
        m8.Msg = "AuthServer.ChangeUserPrivilege fails";
      }
      else
      {
        m8.Passed = true;
        m8.Msg = "AuthServer.ChangeUserPrivilege succeeds";
      }
      return m8.ToString();

    }

    //test9
    private string Test9()
    {
      m_AuthServer = new MockAuthServer();
      Message m9 = new Message();
      m9.TestID = 9;
      AuthResult result7 = m_AuthServer.ChangePassword("hshen", "hshen_pwd", "MockToken");
      if (!result7.valid)
      {
        m9.Passed = false;
        m9.Msg = "AuthServer.ChangeUserPrivilege fails";
      }
      else
      {
        m9.Passed = true;
        m9.Msg = "AuthServer.ChangeUserPrivilege succeeds";
      }
      return m9.ToString();

    }

    /// <summary>
    /// Test function for the MockAuthServer
    /// </summary>
    /// <returns>
    /// Returns true if all test cases pass
    /// Returns false when one of the test cases fail
    /// </returns>
    public bool Test()
    {
      bool ret = true;
      m_string1 = Test1();
      m_string2 = Test2();
      m_string3 = Test3();
      m_string4 = Test4();
      m_string5 = Test5();
      m_string6 = Test6();
      m_string7 = Test7();
      m_string8 = Test8();
      m_string9 = Test9();

      m_Msg.Add(m_string1);
      m_Msg.Add(m_string2);
      m_Msg.Add(m_string3);
      m_Msg.Add(m_string4);
      m_Msg.Add(m_string5);
      m_Msg.Add(m_string6);
      m_Msg.Add(m_string7);
      m_Msg.Add(m_string8);
      m_Msg.Add(m_string9);

      foreach (var msg in m_Msg)
        ret = Message.Parse(msg).Passed && ret;
      return ret;   //all functions work well,test pass

    }

    public List<string> GetMessage()
    {
      return null;
    }
    public List<string> ConvertFromMessageToString()
    {
      return null;
    }

    public static void Main(string[] args)
    {
      MockAuthServerTest mockauthservertest = new MockAuthServerTest();
      mockauthservertest.Test();


      foreach (string item in mockauthservertest.m_Msg)
      {
        Console.WriteLine(item);
      }



    }


  }
}