////////////////////////////////////////////////////////////////////////////////
// MockRootServerTest.cs - This module runs test cases for the MockRootServer //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Anjali Banka, Fall 2011, Syracuse University                 //
//               abanka@syr.edu                                               //
////////////////////////////////////////////////////////////////////////////////

/*
Module Operations: 
==================
This module implements the ITest interface, and defines various test cases. These test 
 * cases ensure that the incoming query is according to the language grammar. 

Public Interface
=================
MockRootServerTest m_MockRootServerTestObj = new MockRootServerTest();
 * m_MockRootServerTestObj.test();
 
Build Process
================
 * 
 * 
 Required Files:
===================
 * MockRootServer.cs
 * ITest.cs

Maintenance History:
====================
ver 1.0 : 17 October 2011

*/

using System;
using System.Collections.Generic;
using edu.syr.cse784.eskimodb.rootserver;
using edu.syr.cse784.eskimodb.sharedobjs;
using ITestInterface;

namespace edu.syr.cse784.eskimodb.clientapi
{
  /// <summary>
  /// MockRootServerTest class which implements the ITest interface.
  /// </summary>
  class MockRootServerTest : ITestInterface.ITest
  {

    #region Properties & Fields
    MockRootServer m_MockRootServerTestObj;
    QueryResult m_QueryResult;
    IRootServerCallback m_IRootServerCallback;
    private int m_Id = 0;
    private string m_Content = null;
    private string m_Token = null;
    private List<string> m_Msg;
    string m_string1, m_string2, m_string3, m_string4;


    #endregion Properties & Fields
    /// <summary>
    /// Constructor for initialization 
    /// </summary>
    public MockRootServerTest()
    {
      m_Msg = new List<string>();
      m_IRootServerCallback = new ClientAPI();


      m_MockRootServerTestObj = new MockRootServer(m_IRootServerCallback, null, null);


      m_QueryResult = new QueryResult(m_Id, m_Content);
    }


    /// <summary>
    /// test 1
    /// Testing the creation of the database 
    /// </summary>
    /// <returns></returns>
    private String Test1()
    {

      Message m1 = new Message();
      m1.TestID = 1;
      m_QueryResult = m_MockRootServerTestObj.ExecQuery("CREATE DB first_db", m_Token);
      if (m_QueryResult.GetId() == 1)
      {
        m1.Passed = false;
        m1.Msg = " m_MockRootServerTestObj.ExecQuery(CREATE DB first_db) fails";
      }
      else
      {
        m1.Passed = true;
        m1.Msg = " m_MockRootServerTestObj.ExecQuery(CREATE DB first_db) succeeds";
      }
      return m1.ToString();

    }



    /// <summary>
    /// test 2
    /// Testing the creation of the table 
    /// </summary>
    /// <returns></returns>
    private String Test2()
    {

      Message m2 = new Message();
      m2.TestID = 2;
      m_QueryResult = m_MockRootServerTestObj.ExecQuery("CREATE TABLE first_db.test_table (PRIMARY KEY prim INT, name VARCHAR(32))", m_Token);
      if (m_QueryResult.GetId() == 1)
      {
        m2.Passed = false;
        m2.Msg = " m_MockRootServerTestObj.ExecQuery(CREATE TABLE first_db.test_table) fails";
      }
      else
      {
        m2.Passed = true;
        m2.Msg = " m_MockRootServerTestObj.ExecQuery(CREATE TABLE first_db.test_table) succeeds";
      }
      return m2.ToString();
    }


    /// <summary>
    /// Test 3
    /// Testing the insertion of data in the table
    /// </summary>
    /// <returns></returns>
    private String Test3()
    {
      Message m3 = new Message();
      m3.TestID = 3;
      m_QueryResult = m_MockRootServerTestObj.ExecQuery("INSERT INTO first_db.test_table (name) VALUES 'user1'", m_Token);
      if (m_QueryResult.GetId() == 1)
      {
        m3.Passed = false;
        m3.Msg = " m_MockRootServerTestObj.ExecQuery(INSERT INTO first_db.test_table ) fails";
      }
      else
      {
        m3.Passed = true;
        m3.Msg = " m_MockRootServerTestObj.ExecQuery(INSERT INTO first_db.test_table ) succeeds";
      }
      return m3.ToString();

    }

    /// <summary>
    /// test 4
    /// Testing the selection query from the database 
    /// </summary>
    /// <returns></returns>
    private String Test4()
    {
      Message m4 = new Message();
      m4.TestID = 4;
      m_QueryResult = m_MockRootServerTestObj.ExecQuery(@"SELECT * FROM first_db.test_table", m_Token);
      if (m_QueryResult.GetId() == 1)
      {
        m4.Passed = false;
        m4.Msg = " m_MockRootServerTestObj.ExecQuery(SELECT * FROM first_db.test_table) fails";
      }
      else
      {
        m4.Passed = true;
        m4.Msg = " m_MockRootServerTestObj.ExecQuery(SELECT * FROM first_db.test_table) succeeds";
      }
      return m4.ToString();
    }

    /// <summary>
    /// Test function for the MockRootServer. Checks if the incoming query is according to the language grammar.
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
      m_Msg.Add(m_string1);
      m_Msg.Add(m_string2);
      m_Msg.Add(m_string3);
      m_Msg.Add(m_string4);

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
    /// Entry point for the test 
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
      MockRootServerTest mockrootservertest = new MockRootServerTest();
      mockrootservertest.Test();


      foreach (string item in mockrootservertest.m_Msg)
      {
        Console.WriteLine(item);
      }



    }

  }
}
