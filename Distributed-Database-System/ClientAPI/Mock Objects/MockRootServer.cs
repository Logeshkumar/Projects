////////////////////////////////////////////////////////////////////////////////
// MockRootServer.cs - Module to mock the Root Server Functionality           //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Anjali Banka (abanka@syr.edu )                               //
//               Indranil Mitra( imitra@syr.edu)                              //
//               Fall 2011, Syracuse University                               //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

/*
Module Operations: 
==================
The module ensures that is used to mock up the root server for the Client API. The module 
 * implements the IRootServer. The ExecQuery function is responsible to identify the query 
 * and respond accordingly. 

 
Public Interface
=================
MockRootServer m_MockRootServerObj = new MockRootServer();
 * m_MockRootServerObj. ExecQuery(string query, string token)
 
Build Process
================
 * 
 * 
 Required Files:
===================
 * IRootServer.cs


Maintenance History:
====================
ver 1.0 : 17 October 2011

*/

using System;
using System.Collections.Generic;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver
{
  /// <summary>
  /// Mock root server class to interact with the client API 
  /// </summary>
  public class MockRootServer : IRootServer
  {
    private int m_FirstDataBaseCreated, m_TableCreated, m_ValuesInserted, m_TableSelected;
    private int m_Result;
    private string m_Message;
    QueryResult m_QueryResultObj;
    IRootServerCallback m_IRootServerCallback;


    /// <summary>
    /// Mock function to get the database details from the root server
    /// </summary>
    /// <param name="token"> Pass the current token</param>
    /// <returns>
    /// Returns the name of the database as the dictionary key
    /// Returns a list of tables present in the database 
    /// </returns>
    public Dictionary<string, List<string>> GetDBInfo(string token)
    {
      Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();

      List<string> Db1Tables = new List<string>();
      Db1Tables.Add("test_table");
      Db1Tables.Add("Table2");
      Db1Tables.Add("Table3");

      List<string> Db2Tables = new List<string>();
      Db2Tables.Add("Table5");
      Db2Tables.Add("Table6");
      Db2Tables.Add("Table7");

      List<string> Db3Tables = new List<string>();
      Db3Tables.Add("Table9");
      Db3Tables.Add("Table10");
      Db3Tables.Add("Table11");

      ret.Add("first_db", Db1Tables);
      ret.Add("second_db", Db2Tables);
      ret.Add("third_db", Db3Tables);

      return ret;
    }

    /// <summary>
    /// Mock of function present in the root server interface 
    /// </summary>
    /// <param name="authServerUrl"></param>
    /// <param name="tableServerUrl"></param>
    public void configureRootServer(string authServerUrl, string tableServerUrl)
    {

    }

    /// <summary>
    /// Default constructor of the mock root server 
    /// </summary>
    public MockRootServer() { }

    /// <summary>
    /// Connstructor for initialization 
    /// </summary>
    public MockRootServer(params object[] info)
    {
      m_FirstDataBaseCreated = 1;
      m_TableCreated = 1;
      m_ValuesInserted = 1;
      m_TableSelected = 1;
      m_IRootServerCallback = (IRootServerCallback)info[0];
    }

    /// <summary>
    /// Function to create a new table
    /// </summary>
    /// <returns></returns>
    private QueryResult CreateTable()
    {
      string ret = string.Empty;
      if (m_FirstDataBaseCreated == 0)
      {
        m_TableCreated = 0;
        m_Message = "Succeed";
        m_Result = m_TableCreated;
        m_QueryResultObj = new QueryResult(m_Result, m_Message);
        m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "", 0);
        return m_QueryResultObj;
      }
      else
      {
        m_Result = m_TableCreated;
        m_Message = "Database is not created";
        m_QueryResultObj = new QueryResult(m_Result, m_Message);
        m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "", 0);
        return m_QueryResultObj;
      }
    }

    /// <summary>
    /// Function to insert items in the table , is table is created
    /// </summary>
    /// <returns></returns>
    private QueryResult InsertIntoTable()
    {
      string ret = string.Empty;
      if ((m_FirstDataBaseCreated == 0) && (m_TableCreated == 0))
      {
        m_ValuesInserted = 0;
        m_Result = m_ValuesInserted;
        m_Message = "Succeed";
        m_QueryResultObj = new QueryResult(m_Result, m_Message);
        m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "", 0);
        return m_QueryResultObj;
      }
      else
      {
        m_Result = m_TableCreated;
        m_Message = "Value cannot be inserted as the table is not created";
        m_QueryResultObj = new QueryResult(m_Result, m_Message);
        m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "", 0);
        return m_QueryResultObj;
      }
    }

    /// <summary>
    /// Function to enable select queries
    /// </summary>
    /// <returns></returns>
    private QueryResult SelectFromTable()
    {
      string ret = string.Empty;
      //if ((m_TableCreated == 0) && (m_ValuesInserted == 0))
      //{
      m_TableSelected = 0;
      m_Result = m_TableSelected;
      m_Message = "Table selected";
      m_QueryResultObj = new QueryResult(m_Result, m_Message);
      m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "1", 10);
      return m_QueryResultObj;
      //}
      //else
      //{
      //    m_Result = m_TableSelected;
      //    m_Message = "Table cannot be selected";
      //    m_QueryResultObj = new QueryResult(m_Result, m_Message);
      //    m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "", 0);
      //    return m_QueryResultObj;
      //}
    }


    /// <summary>
    /// Mock function to check that queries are executed in proper sequence
    /// Check the grammer of the query and allow operations accordingly.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="token"></param>
    /// <returns> </returns>
    public QueryResult ExecQuery(string query, string token)
    {
      try
      {
        if (query == "CREATE DB first_db")
        {
          m_FirstDataBaseCreated = 0;
          m_Result = m_FirstDataBaseCreated;
          m_Message = "Database created";
          m_QueryResultObj = new QueryResult(m_Result, m_Message);
          m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "", 0);
          return m_QueryResultObj;
        }
        else if (query == "CREATE TABLE first_db.test_table (PRIMARY KEY prim INT, name VARCHAR(32))")
        {
          return CreateTable();
        }
        else if (query == "INSERT INTO first_db.test_table (name) VALUES 'user1'")
        {
          return InsertIntoTable();
        }
        else if (query == "INSERT INTO first_db.test_table (name) VALUES 'user2")
        {
          return InsertIntoTable();
        }
        else if (query == "INSERT INTO first_db.test_table (name) VALUES 'user3'")
        {
          return InsertIntoTable();
        }
        else if (query == @"SELECT * FROM first_db.test_table")
        {
          return SelectFromTable();
        }
        else
        {
          m_IRootServerCallback.PutQueryInfo(m_QueryResultObj, "", 0);

          return new QueryResult(0, "");
          // return new QueryResult(0, string.Empty);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return null;
      }
    }

    /// <summary>
    /// Function to get the result after execution of the query 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="startLine"></param>
    /// <param name="numberOfLines"></param>
    /// <param name="token"></param>
    /// <returns> Result of the execution of the query </returns>
    public QueryResult GetResult(string id, int startLine, int numberOfLines, string token)
    {
      int m_Id = 1;
      string m_Result = string.Empty;
      QueryResult m_QueryResult = new QueryResult(m_Id, m_Result);
      QueryDataset m_QueryDataset = MockDataSet();
      m_IRootServerCallback.PutDataset(m_QueryResult, "1", m_QueryDataset);
      return m_QueryResult;
    }

    /// <summary>
    /// This function will be used to release the table object at server for garbage collection. 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="token"></param>
    /// <returns> A QueryResult object which describes info related to table  </returns>
    public QueryResult Release(string id, string token)
    {
      int m_Id = 1;
      string m_Result = string.Empty;
      QueryResult m_QueryResultObj = new QueryResult(m_Id, m_Result);
      return m_QueryResultObj;
    }

    /// <summary>
    /// Used to create a Mock dataset with values 
    /// </summary>
    /// <returns> QueryDataset object </returns>
    public QueryDataset MockDataSet()
    {
      List<Type> colTypes = new List<Type>(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
      List<string> colNames = new List<string>(new string[] { "GroupId", "Name", "JoinDate" });
      QueryDataset table = new QueryDataset(colTypes, colNames);

      List<object> entry = new List<object>();
      entry.Add(1);
      entry.Add("David");
      entry.Add(new DateTime(2010, 6, 3));
      table.AddRow(1, entry);

      entry.Clear();
      entry.Add(3);
      entry.Add("Mary");
      entry.Add(new DateTime(2011, 10, 12));
      table.AddRow(2, entry);

      entry.Clear();
      entry.Add(5);
      entry.Add("Harry");
      entry.Add(new DateTime(2011, 7, 4));
      table.AddRow(3, entry);

      entry.Clear();
      entry.Add(7);
      entry.Add("Peter");
      entry.Add(new DateTime(2011, 3, 18));
      table.AddRow(4, entry);

      entry.Clear();
      entry.Add(9);
      entry.Add("Kate");
      entry.Add(new DateTime(2011, 12, 18));
      table.AddRow(5, entry);

      return table;
    }

  }
}
