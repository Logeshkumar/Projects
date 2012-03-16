////////////////////////////////////////////////////////////////////////////////
// ClientAPI.cs - Test Class for ClientAPI's functionalities                  //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Hao Shen ( hshen01@syr.edu ), Anjali Banka ( abanka@syr.edu) //
//               Indranil Mitra (imitra@syr,edu)                              //
//               Fall 2011, Syracuse University                               //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

/*
 * Maintenance Info
 * ================
 * 
 * 
 * 
 * */

using System;
using System.Collections.Generic;
using edu.syr.cse784.eskimodb.depinject;
using edu.syr.cse784.eskimodb.sharedobjs;
using ITestInterface;
using edu.syr.cse784.eskimodb.executor;

namespace edu.syr.cse784.eskimodb.clientapi
{
  /// <summary>
  /// ClientAPITest class which implements the ITest interface.
  /// </summary>
  class ClientAPITest : ITestInterface.ITest
  {
    ClientAPI m_clientapi;
    int result = 0;
    string message = string.Empty;
    QueryResult m_QueryObj;
    private List<string> m_Msg;
    string m_temptoken = null;
    string m_admintoken = null;
    private string RootServerUrl = "http://localhost:8080/root";
    private string AuthServerUrl = "http://localhost:8080/IComm"; 
    string m_string1, m_string2, m_string3, m_string4, m_string5, m_string6, m_string7, m_string8, m_string9, m_string10, m_string11, m_string12, m_string13, m_string14, m_string15, m_string16, m_string17, m_string18;
    /// <summary>
    /// Constructor for initialization 
    /// </summary>
    public ClientAPITest()
    {
      DependencyInjection di = DependencyInjection.GetInstance();
      di.SetConfig("config.xml");
      m_QueryObj = new QueryResult(result, message);
      m_Msg = new List<string>();
    }

    private bool Startup()
    {
      bool ret = true;
      ret = Executor.Execute(@"../../../AuthServer/bin/Debug/AuthServer.exe", new string[] { "http://localhost:8080/IComm" });
      return ret;
    }


    /// <summary>
    /// test 1 
    /// To authenticate the user 
    /// </summary>
    /// <returns></returns>
    private string Test1()
    {
      Message m1 = new Message();
      m1.TestID = 1;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      if (m_clientapi.AuthenticateUser("team2", "clientapi", out m_temptoken).valid)
      {
        m1.Passed = false;
        m1.Msg = "m_clientapi.AuthenticateUser() test1 fails";
      }
      else
      {
        m1.Passed = true;
        m1.Msg = "m_clientapi.AuthenticateUser() test1 succeeds";
      }
      return m1.ToString();
    }



    /// <summary>
    /// test2 
    /// test to authenticate the user credentials 
    /// </summary>
    /// <returns></returns>
    private string Test2()
    {
      Message m2 = new Message();
      m2.TestID = 2;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      if (m_clientapi.AuthenticateUser("team1", "rootserver", out m_temptoken).valid)
      {
        m2.Passed = false;
        m2.Msg = "m_clientapi.AuthenticateUser() test2 fails";
      }
      else
      {
        m2.Passed = true;
        m2.Msg = "m_clientapi.AuthenticateUser() test2 succeeds";
      }
      return m2.ToString();

    }



    /// <summary>
    /// test 3 
    /// test to authenticate the user 
    /// </summary>
    /// <returns></returns>
    private string Test3()
    {

      Message m3 = new Message();
      m3.TestID = 3;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      if (!(m_clientapi.AuthenticateUser("team1", "clientapi", out m_admintoken).valid))
      {
        m3.Passed = false;
        m3.Msg = "m_clientapi.AuthenticateUser() test3 fails";
      }
      else
      {
        m3.Passed = true;
        m3.Msg = "m_clientapi.AuthenticateUser() test3 succeeds";
      }
      return m3.ToString();

    }



    /// <summary>
    /// test 4 
    /// test to create a new user 
    /// </summary>
    /// <returns></returns>
    private string Test4()
    {
      Message m4 = new Message();
      m4.TestID = 4;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      if (m_clientapi.CreateNewUser("hshen", "hshen", "hshen").valid)
      {
        m4.Passed = false;
        m4.Msg = "m_clientapi.CreateNewUser test1 fails";
      }
      else
      {
        m4.Passed = true;
        m4.Msg = "m_clientapi.CreateNewUser test1 succeeds";
      }
      return m4.ToString();
    }



    /// <summary>
    /// test 5
    /// testing creating of new user with other user credentials
    /// </summary>
    /// <returns></returns>
    private string Test5()
    {
      Message m5 = new Message();
      m5.TestID = 5;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      if ((m_clientapi.CreateNewUser("hshen1", "ewewew", m_admintoken).valid))
      {
        m5.Passed = false;
        m5.Msg = "m_clientapi.CreateNewUser test2 fails";

      }
      else
      {
        m5.Passed = true;
        m5.Msg = "m_clientapi.CreateNewUser  test2 succeeds";
      }
      return m5.ToString();

    }



    /// <summary>
    /// test 6
    /// testing if the user is administrator by passing the current token 
    /// </summary>
    /// <returns></returns>
    private string Test6()
    {
      Message m6 = new Message();
      m6.TestID = 6;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      if (!(m_clientapi.IsAdmin(m_admintoken)))
      {
        m6.Passed = false;
        m6.Msg = "m_clientapi.IsAdmin test1 fails";
      }
      else
      {
        m6.Passed = true;
        m6.Msg = "m_clientapi.IsAdmin  test1 succeeds";
      }
      return m6.ToString();


    }


    /// <summary>
    /// test 7
    /// testing the username is admin
    /// </summary>
    /// <returns></returns>
    private string Test7()
    {
      Message m7 = new Message();
      m7.TestID = 7;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      if (!(m_clientapi.IsAdmin("hshen")))
      {
        m7.Passed = true;
        m7.Msg = "m_clientapi.IsAdmin test2 succeeds";
      }
      else
      {
        m7.Passed = false;
        m7.Msg = "m_clientapi.IsAdmin test2 fails";
      }
      return m7.ToString();

    }


    /// <summary>
    /// test 8
    /// testing the execution of the query 
    /// </summary>
    /// <returns></returns>
    private string Test8()
    {
      Message m8 = new Message();
      m8.TestID = 8;
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();
      m_QueryObj = m_clientapi.ExecuteQuery("CREATE DB first_db", m_temptoken);
      if ((m_QueryObj.GetId() == 0) && (m_QueryObj.GetMessage() == "Database is not created"))
      {
        m8.Passed = false;
        m8.Msg = "m_clientapi.ExecuteQuery fails";
      }
      else
      {
        m8.Passed = true;
        m8.Msg = "m_clientapi.ExecuteQuery succeeds";
      }
      return m8.ToString();

    }


    /// <summary>
    /// test 9
    /// testing if the rows are returned in the returned dataset 
    /// </summary>
    /// <returns></returns>
    private string Test9()
    {
      Message m9 = new Message();
      m9.TestID = 9;


      if (m_clientapi.CheckIfRowsReturned())
      {
        m9.Passed = false;
        m9.Msg = "m_clientapi.CheckIfRowsReturned fails";
      }
      else
      {
        m9.Passed = true;
        m9.Msg = "m_clientapi.CheckIfRowReturned succeeds";
      }
      return m9.ToString();

    }


    /// <summary>
    /// test 10
    /// testing to get all the current user is team1
    /// </summary>
    /// <returns></returns>
    private string Test10()
    {
      Message m10 = new Message();
      m10.TestID = 10;
      List<string> usernames = new List<string>();
      usernames = m_clientapi.GetAllUserNames(m_admintoken);
      if (usernames[0] == "team1")
      {
        m10.Passed = true;
        m10.Msg = "m_clientapi.GetAllUserNames succeeds";
      }
      else
      {
        m10.Passed = false;
        m10.Msg = "m_clientapi.GetAllUserNames fails ";
      }
      return m10.ToString();

    }

    /// <summary>
    /// test 11
    /// testing the function to get all the user names
    /// </summary>
    /// <returns></returns>
    private string Test11()
    {
      Message m11 = new Message();
      m11.TestID = 11;
      List<string> usernames = new List<string>();
      usernames = m_clientapi.GetAllUserNames(m_temptoken);
      if (usernames == null)
      {
        m11.Passed = true;
        m11.Msg = "m_clientapi.GetAllUserNames succeeds";
      }
      else
      {
        m11.Passed = false;
        m11.Msg = "m_clientapi.GetAllUserNames fails ";
      }
      return m11.ToString();

    }


    /// <summary>
    /// test 12
    /// testing the funtion to change the user privilege level by admin 
    /// </summary>
    /// <returns></returns>
    private string Test12()
    {
      Message m12 = new Message();
      m12.TestID = 12;

      AuthResult result = m_clientapi.ChangeUserPrivilege("team1", true, m_admintoken);
      if (result.valid == true)
      {
        m12.Passed = true;
        m12.Msg = "m_clientapi.ChangeUserPrivilege succeeds";
      }
      else
      {
        m12.Passed = false;
        m12.Msg = "m_clientapi.ChangeUserPrivilegefails ";
      }
      return m12.ToString();

    }

    /// <summary>
    /// test 13
    /// testing the change of user privilege by a user 
    /// </summary>
    /// <returns></returns>
    private string Test13()
    {
      Message m13 = new Message();
      m13.TestID = 13;

      AuthResult result = m_clientapi.ChangeUserPrivilege("team1", false, m_temptoken);
      if (!result.valid == true)
      {
        m13.Passed = true;
        m13.Msg = "m_clientapi.ChangeUserPrivilege succeeds";
      }
      else
      {
        m13.Passed = false;
        m13.Msg = "m_clientapi.ChangeUserPrivilege fails ";
      }
      return m13.ToString();

    }

    /// <summary>
    /// test 14
    /// testing change of password , using wrong username and pw
    /// </summary>
    /// <returns></returns>
    private string Test14()
    {
      Message m14 = new Message();
      m14.TestID = 14;

      AuthResult result = m_clientapi.ChangePassword("team1", "clientapi111", m_admintoken);
      if (!result.valid == true)
      {
        m14.Passed = true;
        m14.Msg = "m_clientapi.ChangePassword succeeds";
      }
      else
      {
        m14.Passed = false;
        m14.Msg = "m_clientapi.ChangePassword fails ";
      }
      return m14.ToString();

    }

    /// <summary>
    /// test 15
    /// testing to check the execution of query function 
    /// </summary>
    /// <returns></returns>
    private string Test15()
    {
      Message m15 = new Message();
      m15.TestID = 15;
      List<string> result = new List<string>();
      m_clientapi.ExecuteQuery("SELECT * FROM first_db.test_table", "mocktoken");
      m_clientapi.IterateDataSet();
      result = m_clientapi.GetAllColumnNames();
      if (result[0] == "GroupId" && result[1] == "Name" && result[2] == "JoinDate")
      {
        m15.Passed = true;
        m15.Msg = "m_clientapi.GetAllColumnNames succeeds";
      }
      else
      {
        m15.Passed = false;
        m15.Msg = "m_clientapi.GetAllColumnNames fails ";
      }
      return m15.ToString();

    }


    /// <summary>
    /// test 16
    /// testing the function to get the types of all the columns 
    /// </summary>
    /// <returns></returns>
    private string Test16()
    {
      Message m16 = new Message();
      m16.TestID = 16;
      List<Type> result = new List<Type>();
      result = m_clientapi.GetAllColumnTypes();
      if (result[0] == typeof(int) && result[1] == typeof(string) && result[2] == typeof(DateTime))
      {
        m16.Passed = true;
        m16.Msg = "m_clientapi.GetAllColumnTypes succeeds";
      }
      else
      {
        m16.Passed = false;
        m16.Msg = "m_clientapi.GetAllColumnTypes fails ";
      }
      return m16.ToString();

    }


    /// <summary>
    /// test 17
    /// testing iteration of the returned dataset 
    /// </summary>
    /// <returns></returns>
    private string Test17()
    {
      Message m17 = new Message();
      List<string> result = m_clientapi.IterateDataSet();

      if (result[1] == "Mary")
      {
        m17.Passed = true;
        m17.Msg = "m_clientapi.IterateDataSet succeeds";
      }
      else
      {
        m17.Passed = false;
        m17.Msg = "m_clientapi.IterateDataset fails ";
      }
      return m17.ToString();

    }


    /// <summary>
    /// test 18
    /// testing the function to get all the table info
    /// </summary>
    /// <returns></returns>
    private string Test18()
    {
      Message m18 = new Message();
      Dictionary<string, List<string>> result = m_clientapi.GetTableInfos("mocktoken");

      if (result["first_db"].Contains("test_table"))
      {
        m18.Passed = true;
        m18.Msg = "m_clientapi.GetTableInfos succeeds";
      }
      else
      {
        m18.Passed = false;
        m18.Msg = "m_clientapi.GetTableInfos fails ";
      }
      return m18.ToString();

    }
    /// <summary>
    /// Test function for the ClientAPI
    /// </summary>
    /// <returns>
    /// Returns true if all test cases pass
    /// Returns false when one of the test cases fail
    /// </returns>
    public bool Test()
    {
      Startup();
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
      m_string10 = Test10();
      m_string11 = Test11();
      m_string12 = Test12();
      m_string13 = Test13();
      // m_string14 = Test14();
      m_string15 = Test15();
      m_string16 = Test16();
      m_string17 = Test17();
      m_string18 = Test18();

      m_Msg.Add(m_string1);
      m_Msg.Add(m_string2);
      m_Msg.Add(m_string3);
      m_Msg.Add(m_string4);
      m_Msg.Add(m_string5);
      m_Msg.Add(m_string6);
      m_Msg.Add(m_string7);
      m_Msg.Add(m_string8);
      m_Msg.Add(m_string9);
      m_Msg.Add(m_string10);
      m_Msg.Add(m_string11);
      m_Msg.Add(m_string12);
      m_Msg.Add(m_string13);
      // m_Msg.Add(m_string14);
      m_Msg.Add(m_string15);
      m_Msg.Add(m_string16);
      m_Msg.Add(m_string17);
      m_Msg.Add(m_string18);
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


    /// <summary>
    /// Entry point for the test file 
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
      ClientAPITest clientapitest = new ClientAPITest();
      clientapitest.Test();

      foreach (string item in clientapitest.m_Msg)
      {
        Console.WriteLine(item);
      }


    }


  }
}
