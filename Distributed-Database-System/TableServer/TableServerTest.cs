////////////////////////////////////////////////////////////////////////////////
// TableServerTest.cs - Test TableServer to pass Continuous Integration       //
// Server Tests                                                               //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Priya Dodwad,   Syracuse University                          //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
/*
  * Module Operations
  * =================
  * 
  * This class is a part of TableServer Package.
  * it checks whether all the Test Cases are passed by Continuous Integration Server
  * 
  * 
  * 
  * Public Interface
  * ================
  * public Test()                    //function definition
  * public List<string> GetMessage()
  *
  */
/*
  * Build Process
  * =============
  * Required Files:
  *
  * Maintenance History
  * ===================
  * 
  * ver 1.0 :  06 Dec 11
  *   - first release
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using edu.syr.cse784.eskimodb.testinterface;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.eskimodb.tableserver.Test
{
  public class TableServerTest : edu.syr.cse784.eskimodb.testinterface.ITest
  {
    List<string> m_msg = new List<string>();

   public bool Test()
    {
      bool ret = false;
      try
      {       
        TableResponse m_TResponse;
        TableManager m_TManager = new TableManager();


        //CreateDatabaseTest
        Message m_createDatabase = new Message();
        m_TResponse = m_TManager.CreateDatabase("TestDatabase");
        m_createDatabase.Passed = m_TResponse.GetResponse;
        m_createDatabase.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_createDatabase.TestID = 1;
        m_msg.Add(m_createDatabase.ToString());
        
        //Generate columns to be added to table
        Dictionary<string, bool> m_Dict = new Dictionary<string, bool>();
        m_Dict.Add("ID", true);
        m_Dict.Add("Name", false);
        m_Dict.Add("Dept", true);

        //Adding the typenames for the columns
        List<string> m_colTypelist = new List<string>();
        m_colTypelist.Add("int");
        m_colTypelist.Add("float");
        m_colTypelist.Add("varchar(10)");
        
        
        //CreateTable Test
        Message m_createTable = new Message();        
        m_TResponse = m_TManager.CreateTable("TestDatabase", "TestTable", m_Dict, m_colTypelist);
        m_createTable.Passed = m_TResponse.GetResponse;
        m_createTable.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_createTable.TestID = 2;
        m_msg.Add(m_createTable.ToString());


        //create List for the columnnames to add row
        List<string> ListColumnName = new List<string>();
        ListColumnName.Add("ID");
        ListColumnName.Add("Name");
        ListColumnName.Add("Dept");

        //generate arraylist for data to be add row        
        ArrayList AlColVal = new ArrayList();
        AlColVal.Add(11);
        AlColVal.Add(11.1f);
        AlColVal.Add("test");

        //Add Row Test
        m_TResponse = m_TManager.InsertRow("TestDatabase", "TestTable", ListColumnName, AlColVal);
        Message m_InsertRow = new Message();
        m_InsertRow.Passed = m_TResponse.GetResponse;
        m_InsertRow.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_InsertRow.TestID = 3;
        m_msg.Add(m_InsertRow.ToString());


        //AddColumn Test
        m_TResponse = m_TManager.AddColumn("TestDatabase", "TestTable", false, "str", "varchar(8)");
        Message m_AddColumn = new Message();
        m_AddColumn.Passed = m_TResponse.GetResponse;
        m_AddColumn.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_AddColumn.TestID = 4;
        m_msg.Add(m_AddColumn.ToString());
        
        //rename column Test
        m_TResponse = m_TManager.RenameColumn("TestDatabase", "TestTable", "str", "newStr");
        Message m_RenameColumn = new Message();
        m_RenameColumn.Passed = m_TResponse.GetResponse;
        m_RenameColumn.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_RenameColumn.TestID = 5;
        m_msg.Add(m_RenameColumn.ToString());
        

        //renameTable Test
        m_TResponse = m_TManager.RenameTable("TestDatabase", "TestTable", "NewTestTable");
        Message m_RenameTable = new Message();
        m_RenameTable.Passed = m_TResponse.GetResponse;
        m_RenameTable.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_RenameTable.TestID = 6;
        m_msg.Add(m_RenameTable.ToString());


        //Emptytable Test
        m_TResponse = m_TManager.EmptyTable("TestDatabase", "NewTestTable");
        Message m_EmptyTable = new Message();
        m_EmptyTable.Passed = m_TResponse.GetResponse;
        m_EmptyTable.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_EmptyTable.TestID = 7;
        m_msg.Add(m_EmptyTable.ToString());


        //deletetable Test
        m_TResponse = m_TManager.DeleteTable("TestDatabase", "NewTestTable");
        Message m_DeleteTable = new Message();
        m_DeleteTable.Passed = m_TResponse.GetResponse;
        m_DeleteTable.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_DeleteTable.TestID = 8;
        m_msg.Add(m_DeleteTable.ToString());


        //deletedatabase Test
        m_TResponse = m_TManager.DeleteDatabase("TestDatabase");
        Message m_DeleteDatabase = new Message();
        m_DeleteDatabase.Passed = m_TResponse.GetResponse;
        m_DeleteDatabase.Msg = m_TResponse.GetMessage + " for " + m_TResponse.GetId;
        m_DeleteDatabase.TestID = 9;
        m_msg.Add(m_DeleteDatabase.ToString());
        ret = true;

      }
      catch(Exception ex)
      {
        throw ex;
        
      }

      return ret;
  }
    //returns the list of messages
   public List<string> GetMessage()
    {
      return m_msg;
    }

  }
}

