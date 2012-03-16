/////////////////////////////////////////////////////////////////////////////////////////////
//  ParserTest.cs:                 Contains several test cases to validate the input query //
//  Language:                      C#, .Net Framework 4.0      				                     //
//  Platform:                      Windows 7								                               //
//  Application:                   EskimoDB - RootServer                                   //
/////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Module Operations:
 * =================
 * This module implements ITest interface and is a collection of test cases
 * each test case validates specific input EskimoDb queries.
 * /
/*
Maintainence History:
=====================
ver 1.0 : 10 October 2011
- first release
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.testinterface;
using edu.syr.cse784.eskimodb.rootserver;

namespace edu.syr.cse784.eskimodb.rootserver.Test
{
  public class ParserTest : ITest
  {
    private List<string> messageList = new List<string>();
    public bool Test()
    {
      if (!Case1())
      {
        Message message = new Message();
        message.Msg = "Failure while processing CREATE DB query";
        message.TestID = 1;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case2())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing database name and semicolon in CREATE DB query";
        message.TestID = 2;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case3())
      {
        Message message = new Message();
        message.Msg = "Exceptiion was not thrown for missing semicolon in CREATE DB query";
        message.TestID = 3;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case4())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing database name in CREATE DB query";
        message.TestID = 4;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case5())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing CREATE TABLE query";
        message.TestID = 5;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case6())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in CREATE TABLE query";
        message.TestID = 6;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case7())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing table name in CREATE TABLE query";
        message.TestID = 7;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case8())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for extra space betwwen the kewords CREATE and TABLE in CREATE TABLE query";
        message.TestID = 8;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case9())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for inputting lowercase and uppercase keywords in tha same CREATE TABLE query";
        message.TestID = 9;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case10())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing SELECT DB query";
        message.TestID = 10;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case11())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in the SELECT DB query";
        message.TestID = 11;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case12())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing database name in the SELECT DB query";
        message.TestID = 12;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case13())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for additional spaces between the keywords SELECT and DB in SELECT DB query"; ;
        message.TestID = 13;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case14())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper syntax in the SELECT DB query";
        message.TestID = 14;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case15())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing DELETE DB query";
        message.TestID = 15;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case16())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in the DELETE DB query";
        message.TestID = 16;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case17())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing database name in the DELETE DB query";
        message.TestID = 17;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case18())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for additional spaces between keywords DELETE and DB in DELETE DB query";
        message.TestID = 18;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case19())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper syntax in DELETE DB query";
        message.TestID = 19;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case20())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing DELETE TABLE query";
        message.TestID = 20;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case21())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in the DELETE TABLE query";
        message.TestID = 21;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case22())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing table name in the DELETE TABLE query";
        message.TestID = 22;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case23())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for additional spaces between Keywords DELETE and TABLE in the DELETE TABLE query";
        message.TestID = 23;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case24())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper syntax in the DELETE TABLE query";
        message.TestID = 24;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case25())
      {
        Message message = new Message();
        message.Msg = "Failure in processing EMPTY TABLE query";
        message.TestID = 25;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case26())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in the EMPTY TABLE query";
        message.TestID = 26;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case27())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing table name in the EMPTY TABLE query";
        message.TestID = 27;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case28())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper spacing between Keywords EMPTY and TABLE in the EMPTY TABLE query";
        message.TestID = 28;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case29())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper syntax in the EMPTY TABLE query";
        message.TestID = 29;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case30())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing DELETE COLUMN query";
        message.TestID = 30;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case31())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in the DELETE COLUMN query";
        message.TestID = 31;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case32())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing table name in the DELETE COLUMN query";
        message.TestID = 32;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case33())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing column name in the DELETE COLUMN query";
        message.TestID = 33;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case34())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing COLUMN Keyword in the DELETE COLUMN query";
        message.TestID = 34;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case35())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper syntax in the DELETE COLUMN query";
        message.TestID = 35;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case36())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing ADD COLUMN query";
        message.TestID = 36;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case37())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in the ADD COLUMN query";
        message.TestID = 37;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case38())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing table name in the ADD COLUMN query";
        message.TestID = 38;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case39())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing column name in the ADD COLUMN query";
        message.TestID = 39;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case40())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing COLUMN Keyword in the ADD COLUMN query";
        message.TestID = 40;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case41())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper syntax in the ADD COLUMN query";
        message.TestID = 41;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case42())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing INSERT Query";
        message.TestID = 42;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case43())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing semicolon in the INSERT query";
        message.TestID = 43;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case44())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing table name in the INSERT query";
        message.TestID = 44;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case45())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing VALUES Keyword in the INSERT query";
        message.TestID = 45;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case46())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for improper spacing between Keywords INSERT and INTO in the INSERT query";
        message.TestID = 46;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case47())
      {
        Message message = new Message();
        message.Msg = "Exception was not thrown for missing comma in between the column names in the INSERT query";
        message.TestID = 47;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case48())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing basic SELECT query";
        message.TestID = 48;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case49())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with WHERE clause";
        message.TestID = 49;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case50())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with ORDER BY clause";
        message.TestID = 50;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case51())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with LIMIT range";
        message.TestID = 51;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case52())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with WHERE and ORDER BY clauses";
        message.TestID = 52;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case53())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with WHERE and LIMIT clauses";
        message.TestID = 53;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case54())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with ORDER BY and LIMIT clauses";
        message.TestID = 54;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case55())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with WHERE, ORDER BY and LIMIT clauses";
        message.TestID = 55;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case56())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query which selects specific columns";
        message.TestID = 56;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case57())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with COUNT";
        message.TestID = 57;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case58())
      {
        Message message = new Message();
        message.Msg = "Failure occurred while processing SELECT query with COUNT";
        message.TestID = 58;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
       if (!Case59())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing RENAME TABLE Query";
        message.TestID = 59;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }
      if (!Case60())
      {
        Message message = new Message();
        message.Msg = "Failure occured while processing RENAME COLUMN Query";
        message.TestID = 60;
        message.Passed = false;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return false;
      }

      return true;
    }

    public List<string> GetMessage()
    {
      return messageList;
    }
    public List<string> ConvertFromMessageToString()
    {
      List<string> ret = new List<string>();
      return ret;
    }

    private bool Case1()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("create db dbname;");
      if (statementObject.GetStatementType() != StatementType.CREATE_DB)
        return false;
      if (((CreateDB)statementObject).GetDatabaseName() != "dbname")
        return false;
      Message message = new Message();
      message.Msg = "CREATE DB query was executed sucesfully ";
      message.TestID = 1;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }

    private bool Case2()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("create db ");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing database name and semicolon in CREATE DB query";
        message.TestID = 2;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    private bool Case3()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("create db dbname");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exceptiion was thrown for missing semicolon in CREATE DB query";
        message.TestID = 3;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }    
    }

    private bool Case4()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("create db;");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exceptiion was thrown for missing database name in CREATE DB query";
        message.TestID = 4;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    private bool Case5()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("CREATE TABLE table1(PRIMARY KEY key1 VARCHAR(255));");
        if (statementObject.GetStatementType() != StatementType.CREATE_TABLE)
          return false;
        CreateTable tabObj = (CreateTable)statementObject;
        List<TableColumn> columnList = new List<TableColumn>();
        if (tabObj.GetTableName() != "table1")
          return false;
        columnList = tabObj.GetList();
        foreach (TableColumn column in columnList)
        {
          if (column.GetUniqueKey() != "PRIMARY KEY")
            return false;
          if (column.GetColumnName() != "key1")
            return false;
          if (column.GetVarType() != "VARCHAR")
            return false;
          if (column.GetVarRange() != "255")
            return false;
        }

        Message message = new Message();
        message.Msg = "CREATE TABLE query was executed successfully";
        message.TestID = 5;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }
    }

    // testcase for no semicolon at the end of the query
    // handling the exception 
    private bool Case6()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("CREATE TABLE table1(PRIMARY KEY key1 VARCHAR(255))");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing semicolon in CREATE TABLE query";
        message.TestID = 6;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    // test case for no table name in the query.. handling the exception
    private bool Case7()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("CREATE TABLE (PRIMARY KEY key1 VARCHAR(255))");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing table name in CREATE TABLE query";
        message.TestID = 7;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // checking if there is a space between tablename and open parenthesis
    // according to the sql given there shouldn be any.. so throwing error.
    private bool Case8()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("CREATE  TABLE table1 (PRIMARY KEY key1 VARCHAR(255));");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for extra space betwwen the kewords CREATE and TABLE in CREATE TABLE query";
        message.TestID = 8;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // Checking lowercase and uppercase in the query inputted(create TABLE)
    private bool Case9()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("create TABLE table1 (PRIMARY KEY key1 VARCHAR(255))");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for inputting lowercase and uppercase keywords in tha same CREATE TABLE query";
        message.TestID = 9;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    private bool Case10()
    {
      QParser qParser = new QParser();
      try
      {
        string m_SelectDb = "SELECT DB databasename1;";
        if (!m_SelectDb.Contains(";"))
          return false;
        Statement statementObject = qParser.ValidateQuery(m_SelectDb);
        if (statementObject.GetStatementType() != StatementType.SELECT_DB)
          return false;
        SelectDB dbObj = (SelectDB)statementObject;
        if (dbObj.GetDatabaseName() != "databasename1")
          return false;
        Message message = new Message();
        message.Msg = "SELECT DB query was executed successfully";
        message.TestID = 10;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false ;
      }

    }

    // testcase for no semicolon at the end of the query
    // handling the exception 
    private bool Case11()
    {
      QParser qParser = new QParser();
      try
      {
        string m_SelectDb = "SELECT DB databasename1";
        Statement statementObject = qParser.ValidateQuery(m_SelectDb);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing semicolon in the SELECT DB query";
        message.TestID = 11;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    // test case for no database name in the query.. handling the exception
    private bool Case12()
    {
      QParser qParser = new QParser();
      try
      {
        string m_SelectDb = "SELECT DB;";
        Statement statementObject = qParser.ValidateQuery(m_SelectDb);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing database name in the SELECT DB query";
        message.TestID = 12;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }


    //checking if there are extra spaces between the strings in the query
    private bool Case13()
    {
      QParser qParser = new QParser();
      try
      {
        string m_SelectDb = "SELECT  DB databasename1;";
        Statement statementObject = qParser.ValidateQuery(m_SelectDb);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for additional spaces between the keywords SELECT and DB in SELECT DB query"; ;
        message.TestID = 13;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // there is a possibility that the user can input DATABASE instead
    // of DB as .. So checking for error handling
    private bool Case14()
    {
      QParser qParser = new QParser();
      try
      {
        string m_SelectDb = "SELECT database databasename1;";
        Statement statementObject = qParser.ValidateQuery(m_SelectDb);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper syntax in the SELECT DB query";
        message.TestID = 14;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }
    private bool Case15()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteDb = "DELETE DB databasename1;";
        if (!m_DeleteDb.Contains(";"))
          return false;
        Statement statementObject = qParser.ValidateQuery(m_DeleteDb);
        if (statementObject.GetStatementType() != StatementType.DELETE_DB)
          return false;
        DeleteDB dbObj = (DeleteDB)statementObject;
        if (dbObj.GetDatabaseName() != "databasename1")
          return false;
        Message message = new Message();
        message.Msg = "DELETE DB query was executed successfully";
        message.TestID = 15;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }

    }

    // testcase for no semicolon at the end of the query
    // handling the exception 
    private bool Case16()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteDb = "DELETE DB databasename1";
        Statement statementObject = qParser.ValidateQuery(m_DeleteDb);
          return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing semicolon in the DELETE DB query";
        message.TestID = 16;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // test case for no database name in the query.. handling the exception
    private bool Case17()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteDb = "DELETE DB;";
        Statement statementObject = qParser.ValidateQuery(m_DeleteDb);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing database name in the DELETE DB query";
        message.TestID = 17;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    //checking if there are extra spaces between the strings in the query
    
    private bool Case18()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteDb = "DELETE  DB databasename1;";
        Statement statementObject = qParser.ValidateQuery(m_DeleteDb);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for additional spaces between keywords DELETE and DB in DELETE DB query";
        message.TestID = 18;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // there is a possibility that the user can input DATABASE instead
    // of DB as .. So checking for error handling
    private bool Case19()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteDb = "DELETE DATABASE databasename1;";
        Statement statementObject = qParser.ValidateQuery(m_DeleteDb);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper syntax in DELETE DB query";
        message.TestID = 19;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }
    private bool Case20()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteTab = "DELETE TABLE tablename1;";
        if (!m_DeleteTab.Contains(";"))
          return false;
        Statement statementObject = qParser.ValidateQuery(m_DeleteTab);
        if (statementObject.GetStatementType() != StatementType.DELETE_TABLE)
          return false;
        DeleteTable tabObj = (DeleteTable)statementObject;
        if (tabObj.GetTableName() != "tablename1")
          return false;
        Message message = new Message();
        message.Msg = "DELETE TABLE query was executed successfully";
        message.TestID = 20;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }

    }

    // testcase for no semicolon at the end of the query
    // handling the exception 
    private bool Case21()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteTab = "DELETE TABLE tablename1";
        Statement statementObject = qParser.ValidateQuery(m_DeleteTab);
          return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing semicolon in the DELETE TABLE query";
        message.TestID = 21;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    // test case for no table name in the query.. handling the exception
    private bool Case22()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteTab = "DELETE TABLE;";
        Statement statementObject = qParser.ValidateQuery(m_DeleteTab);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing table name in the DELETE TABLE query";
        message.TestID = 22;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    //checking if there are extra spaces between the strings in the query
    private bool Case23()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteTab = "DELETE  TABLE tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_DeleteTab);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for additional spaces between Keywords DELETE and TABLE in the DELETE TABLE query";
        message.TestID = 23;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // there is a possibility that the user can input TAB instead
    // of TABLE as given .. So checking for error handling
    private bool Case24()
    {
      QParser qParser = new QParser();
      try
      {
        string m_DeleteTab = "DELETE TAB tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_DeleteTab);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper syntax in the DELETE TABLE query";
        message.TestID = 24;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    private bool Case25()
    {
      QParser qParser = new QParser();
      try
      {
        string m_EmptyTab = "EMPTY TABLE tablename1;";
        if (!m_EmptyTab.Contains(";"))
          return false;
        Statement statementObject = qParser.ValidateQuery(m_EmptyTab);
        if (statementObject.GetStatementType() != StatementType.EMPTY_TABLE)
          return false;
        EmptyTable tabObj = (EmptyTable)statementObject;
        if (tabObj.GetTableName() != "tablename1")
          return false;
        Message message = new Message();
        message.Msg = "EMPTY TABLE query was executed sucessfully";
        message.TestID = 25;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }

    }

    // testcase for no semicolon at the end of the query
    // handling the exception 
    private bool Case26()
    {
      QParser qParser = new QParser();
      try
      {
        string m_EmptyTab = "EMPTY TABLE tablename1";
        Statement statementObject = qParser.ValidateQuery(m_EmptyTab);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing semicolon in the EMPTY TABLE query";
        message.TestID = 26;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    // test case for no table name in the query.. handling the exception
    private bool Case27()
    {
      QParser qParser = new QParser();
      try
      {
        string m_EmptyTab = "EMPTY TABLE";
        Statement statementObject = qParser.ValidateQuery(m_EmptyTab);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing table name in the EMPTY TABLE query";
        message.TestID = 27;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    //checking if there are extra spaces between the strings in the query
    private bool Case28()
    {
      QParser qParser = new QParser();
      try
      {
        string m_EmptyTab = "EMPTY  TABLE tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_EmptyTab);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper syntax in the EMPTY TABLE query";
        message.TestID = 28;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    // there is a possibility that the user can input TAB instead
    private bool Case29()
    {
      QParser qParser = new QParser();
      try
      {
        string m_EmptyTab = "EMPTY TAB tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_EmptyTab);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper syntax in the EMPTY TABLE query";
        message.TestID = 29;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }
    private bool Case30()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabD = "DELETE COLUMN columnname1 IN TABLE tablename1;";
        if (!m_ModifyTabD.Contains(";"))
          return false;
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabD);
        if (statementObject.GetStatementType() != StatementType.MOD_TABLE)
          return false;
        ModifyTab tabObj = (ModifyTab)statementObject;
        if (tabObj.GetDelcolumnData().GetTableName() != "tablename1")
          return false;
        if (tabObj.GetDelcolumnData().GetColumnData() != "columnname1")
          return false;
        if (tabObj.GetTyp() != "DELETE")
          return false;
        Message message = new Message();
        message.Msg = "DELETE COLUMN query was executed successfully";
        message.TestID = 30;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }

    }


    // testcase for no semicolon at the end of the query
    // handling the exception
    private bool Case31()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabD = "DELETE COLUMN columnname1 IN TABLE tablename1";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabD);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing semicolon in the DELETE COLUMN query";
        message.TestID = 31;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // test case for no table name in the query.. handling the exception
    private bool Case32()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabD = "DELETE COLUMN columnname1 IN TABLE;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabD);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing table name in the DELETE COLUMN query";
        message.TestID = 32;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }


    // test case for no column name in the query.. handling the exception
    private bool Case33()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabD = "DELETE COLUMN IN TABLE tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabD);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString(); 
        Message message = new Message();
        message.Msg = "Exception was thrown for missing column name in the DELETE COLUMN query";
        message.TestID = 33;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    //no COLUMN key word
    private bool Case34()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabD = "DELETE columnname1 IN TABLE tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabD);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing COLUMN Keyword in the DELETE COLUMN query";
        message.TestID = 34;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // there is a possibility that the user can input TAB instead
    // of TABLE as .. So checking for error handling
    private bool Case35()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabD = "DELETE COLUMN columnname1 IN TAB tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabD);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper syntax in the DELETE COLUMN query";
        message.TestID = 35;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }
    private bool Case36()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabA = "ADD COLUMN PRIMARY KEY key1 INT IN TABLE tablename1;";
        if (!m_ModifyTabA.Contains(";"))
          return false;
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabA);
        if (statementObject.GetStatementType() != StatementType.MOD_TABLE)
          return false;
        ModifyTab tabObj = (ModifyTab)statementObject;
        if (tabObj.GetAddColumnData().GetTableName() != "tablename1")
          return false;
        if (tabObj.GetAddColumnData().GetColumnData().GetUniqueKey() != "PRIMARY KEY")
          return false;
        if (tabObj.GetTyp() != "ADD")
          return false;
        if (tabObj.GetAddColumnData().GetColumnData().GetColumnName() != "key1")
        return false;
        if (tabObj.GetAddColumnData().GetColumnData().GetVarType() != "INT")
          return false;
        Message message = new Message();
        message.Msg = "ADD COLUMN query was executed successfully";
        message.TestID = 36;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }
    }

    // testcase for no semicolon at the end of the query
    // handling the exception
    private bool Case37()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabA = "ADD COLUMN PRIMARY KEY columnname1 CHAR IN TABLE tablename1";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabA);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing semicolon in the ADD COLUMN query";
        message.TestID = 37;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // test case for no table name in the query.. handling the exception
    private bool Case38()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabA = "ADD COLUMN PRIMARY KEY columnname1 CHAR IN TABLE;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabA);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing table name in the ADD COLUMN query";
        message.TestID = 38;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    // test case for no column name in the query.. handling the exception
    private bool Case39()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabA = "ADD COLUMN PRIMARY KEY CHAR IN TABLE tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabA);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing column name in the ADD COLUMN query";
        message.TestID = 39;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }


    //no COLUMN keyword
    private bool Case40()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabA = "ADD PRIMARY KEY columnname1 CHAR IN TABLE tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabA);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing COLUMN Keyword in the ADD COLUMN query";
        message.TestID = 40;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }


    // there is a possibility that the user can input TAB instead
    // of TABLE as .. So checking for error handling
    private bool Case41()
    {
      QParser qParser = new QParser();
      try
      {
        string m_ModifyTabA = "ADD COLUMN PRIMARY KEY columnname1 CHAR IN TAB tablename1;";
        Statement statementObject = qParser.ValidateQuery(m_ModifyTabA);
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper syntax in the ADD COLUMN query";
        message.TestID = 41;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }

    }

    private bool Case42()
    {
      QParser qParser = new QParser();
      List<string> ColumnList = new List<string>();      
      Statement statementObject = qParser.ValidateQuery("INSERT INTO c.tab1(col1,col2,col3)VALUES(val1,2,2.0);");
      if (statementObject.GetStatementType() != StatementType.INSERT_ROW)
      return false;
      InsertRow insertObj = (InsertRow)statementObject;
      if(insertObj.GetTableName() !="c.tab1")
       return false;
      ColumnList = insertObj.GetList();
      if(ColumnList[0]!="col1" && ColumnList[1] !="col2" && ColumnList[2] !="col3")
      return false;
      List<ColumnValue> lis = new List<ColumnValue>();
      lis = insertObj.GetValueList();   
      if (lis[0].GetStringColumnValue() != "val1" && lis[1].GetIntColumnValue() != 2  && lis[2].GetDoubleColumnValue() != 2.0)
      return false;
      if (lis[0].GetColumnValueType() != ColValueType.STRING && lis[1].GetColumnValueType() != ColValueType.INTEGER && lis[2].GetColumnValueType() != ColValueType.DOUBLE)
        return false;
      Message message = new Message();
      message.Msg = "INSERT Query was executed successfully";
      message.TestID = 42;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }

    //missing semicolon
    private bool Case43()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("INSERT INTO c.tab1(col1,col2,col3)VALUES(val1,val2,val3)");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception thrown for missing semicolon in the INSERT query";
        message.TestID = 43;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      } 
    }

    //missing table name
    private bool Case44()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("INSERT INTO (col1,col2,col3)VALUES(val1,val2,val3);");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing table name in the INSERT query";
        message.TestID = 44;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    //missing values
    private bool Case45()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("INSERT INTO c.tab1(col1,col2,col3)(val1,val2,val3);");
        return false;
      }
      catch (Exception ex)
      {
        Message message = new Message();
        message.Msg = "Exception was thrown for missing VALUES Keyword in the INSERT query";
        message.TestID = 45;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        ex.ToString();
        return true;
      }
    }

    //space between INSERT INTO and remaining parts
    private bool Case46()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("INSERT  INTO c.tab1(col1,col2,col3)VALUES(val1,val2,val3);");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for improper spacing between Keywords INSERT and INTO in the INSERT query";
        message.TestID = 46;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }

    //no comas between the columns
    private bool Case47()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("INSERT INTO c.tab1(col1 col2 col3)VALUES(val1,val2,val3);");
        return false;
      }
      catch (Exception ex)
      {
        ex.ToString();
        Message message = new Message();
        message.Msg = "Exception was thrown for missing comma in between the column names in the INSERT query";
        message.TestID = 47;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
    }


    /*
     *Test case for a basic select statement without the where and orderby clause.
     */
    private bool Case48()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;

      Message message = new Message();
      message.Msg = "Basic SELECT query was executed successfully";
      message.TestID = 48;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }


    /*
     * Test case for select query with where clause and three columns. 
     */ 
    private bool Case49()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename where col1=47 and col2 = testcol and col3=44.5;");

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;
      
      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
      {
        List<WhereEntry> whereEntryList = ((SelectRows)statementObject).GetWhereList().GetSubWhereList().GetWhereEntryList();
        if (whereEntryList[0].GetColumnName() != "col1")
          return false;
        if (whereEntryList[0].GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          if (whereEntryList[0].GetColumnValue().GetIntColumnValue() != 47)
            return false;

        if (whereEntryList[1].GetColumnName() != "col2")
          return false;
        if (whereEntryList[1].GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          if (whereEntryList[1].GetColumnValue().GetStringColumnValue() != "testcol")
            return false;

        if (whereEntryList[2].GetColumnName() != "col3")
          return false;
        if (whereEntryList[2].GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          if (whereEntryList[2].GetColumnValue().GetDoubleColumnValue() != 44.5)
            return false;
      }
      else
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with WHERE clause was executed successfully";
      message.TestID = 49;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);

      return true;
    }

    /*
     * Test case for select query with orderby clause 
     */ 
    private bool Case50()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename order by col1 asc, col2 dsc;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
      {
        List<OrderByEntry> orderByList = ((SelectRows)statementObject).GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();

        if (orderByList[0].GetColumnName() != "col1")
          return false;
        if (orderByList[0].GetOrderByType() != "ASC")
          return false;

        if (orderByList[1].GetColumnName() != "col2")
          return false;
        if (orderByList[1].GetOrderByType() != "DSC")
          return false;
      }
      else 
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with ORDER BY clause was executed successfully";
      message.TestID = 50;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }


    /*
     * Test case for select query with limit range 
     */
    private bool Case51()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename limit 10 , 20;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;
      
      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
      {
        if (((SelectRows)statementObject).GetLimitRange().GetStartIndex() != 10)
          return false;
        if (((SelectRows)statementObject).GetLimitRange().GetCount() != 20)
          return false;
      }
      else
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with LIMIT range was executed successfully";
      message.TestID = 51;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }

    /*
     * Test case for select query for where and order by
     */
    private bool Case52()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename where col1=47 and col2 = testcol and col3=44.5 order by col1 asc, col2 dsc;");

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
      {
        List<OrderByEntry> orderByList = ((SelectRows)statementObject).GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();

        if (orderByList[0].GetColumnName() != "col1")
          return false;
        if (orderByList[0].GetOrderByType() != "ASC")
          return false;

        if (orderByList[1].GetColumnName() != "col2")
          return false;
        if (orderByList[1].GetOrderByType() != "DSC")
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
      {
        List<WhereEntry> whereEntryList = ((SelectRows)statementObject).GetWhereList().GetSubWhereList().GetWhereEntryList();
        if (whereEntryList[0].GetColumnName() != "col1")
          return false;
        if (whereEntryList[0].GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          if (whereEntryList[0].GetColumnValue().GetIntColumnValue() != 47)
            return false;

        if (whereEntryList[1].GetColumnName() != "col2")
          return false;
        if (whereEntryList[1].GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          if (whereEntryList[1].GetColumnValue().GetStringColumnValue() != "testcol")
            return false;

        if (whereEntryList[2].GetColumnName() != "col3")
          return false;
        if (whereEntryList[2].GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          if (whereEntryList[2].GetColumnValue().GetDoubleColumnValue() != 44.5)
            return false;
      }
      else
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with WHERE and ORDER BY clauses was executed successfully";
      message.TestID = 52;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }


    /*
     * Test case for select query for where clause and limit clause
     */
    private bool Case53()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename where col1=47 and col2 = testcol and col3=44.5 limit 10 , 20;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
      {
        if (((SelectRows)statementObject).GetLimitRange().GetStartIndex() != 10)
          return false;
        if (((SelectRows)statementObject).GetLimitRange().GetCount() != 20)
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
      {
        List<WhereEntry> whereEntryList = ((SelectRows)statementObject).GetWhereList().GetSubWhereList().GetWhereEntryList();
        if (whereEntryList[0].GetColumnName() != "col1")
          return false;
        if (whereEntryList[0].GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          if (whereEntryList[0].GetColumnValue().GetIntColumnValue() != 47)
            return false;

        if (whereEntryList[1].GetColumnName() != "col2")
          return false;
        if (whereEntryList[1].GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          if (whereEntryList[1].GetColumnValue().GetStringColumnValue() != "testcol")
            return false;

        if (whereEntryList[2].GetColumnName() != "col3")
          return false;
        if (whereEntryList[2].GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          if (whereEntryList[2].GetColumnValue().GetDoubleColumnValue() != 44.5)
            return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with WHERE and LIMIT clauses was executed successfully";
      message.TestID = 53;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);

      return true;
    }


    /*
     * Test case for order by and limit clause
     */
    private bool Case54()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename order by col1 asc, col2 dsc limit 10 , 20;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
      {
        if (((SelectRows)statementObject).GetLimitRange().GetStartIndex() != 10)
          return false;
        if (((SelectRows)statementObject).GetLimitRange().GetCount() != 20)
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
      {
        List<OrderByEntry> orderByList = ((SelectRows)statementObject).GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();

        if (orderByList[0].GetColumnName() != "col1")
          return false;
        if (orderByList[0].GetOrderByType() != "ASC")
          return false;

        if (orderByList[1].GetColumnName() != "col2")
          return false;
        if (orderByList[1].GetOrderByType() != "DSC")
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with ORDER BY and LIMIT clauses was executed successfully";
      message.TestID = 54;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);

      return true;
    }


    /*
     * Test case for select query  for where, order by and limit clause
     */
    private bool Case55()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select * from tablename where col1=47 and col2 = testcol and col3=44.5 order by col1 asc, col2 dsc limit 10 , 20;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
      {
        if (((SelectRows)statementObject).GetLimitRange().GetStartIndex() != 10)
          return false;
        if (((SelectRows)statementObject).GetLimitRange().GetCount() != 20)
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
      {
        List<OrderByEntry> orderByList = ((SelectRows)statementObject).GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();

        if (orderByList[0].GetColumnName() != "col1")
          return false;
        if (orderByList[0].GetOrderByType() != "ASC")
          return false;

        if (orderByList[1].GetColumnName() != "col2")
          return false;
        if (orderByList[1].GetOrderByType() != "DSC")
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
      {
        List<WhereEntry> whereEntryList = ((SelectRows)statementObject).GetWhereList().GetSubWhereList().GetWhereEntryList();
        if (whereEntryList[0].GetColumnName() != "col1")
          return false;
        if (whereEntryList[0].GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          if (whereEntryList[0].GetColumnValue().GetIntColumnValue() != 47)
            return false;

        if (whereEntryList[1].GetColumnName() != "col2")
          return false;
        if (whereEntryList[1].GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          if (whereEntryList[1].GetColumnValue().GetStringColumnValue() != "testcol")
            return false;

        if (whereEntryList[2].GetColumnName() != "col3")
          return false;
        if (whereEntryList[2].GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          if (whereEntryList[2].GetColumnValue().GetDoubleColumnValue() != 44.5)
            return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() != SelectRowColumnType.ALL_COLUMNS)
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with WHERE, ORDER BY and LIMIT clauses was executed successfully";
      message.TestID = 55;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }

    /*
     * Test case for select query for selecting specific columns
     */
    private bool Case56()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select col1, col2 from tablename where col1=47 and col2 = testcol and col3=44.5 order by col1 asc, col2 dsc limit 10 , 20;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
      {
        if (((SelectRows)statementObject).GetLimitRange().GetStartIndex() != 10)
          return false;
        if (((SelectRows)statementObject).GetLimitRange().GetCount() != 20)
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
      {
        List<OrderByEntry> orderByList = ((SelectRows)statementObject).GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();

        if (orderByList[0].GetColumnName() != "col1")
          return false;
        if (orderByList[0].GetOrderByType() != "ASC")
          return false;

        if (orderByList[1].GetColumnName() != "col2")
          return false;
        if (orderByList[1].GetOrderByType() != "DSC")
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
      {
        List<WhereEntry> whereEntryList = ((SelectRows)statementObject).GetWhereList().GetSubWhereList().GetWhereEntryList();
        if (whereEntryList[0].GetColumnName() != "col1")
          return false;
        if (whereEntryList[0].GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          if (whereEntryList[0].GetColumnValue().GetIntColumnValue() != 47)
            return false;

        if (whereEntryList[1].GetColumnName() != "col2")
          return false;
        if (whereEntryList[1].GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          if (whereEntryList[1].GetColumnValue().GetStringColumnValue() != "testcol")
            return false;

        if (whereEntryList[2].GetColumnName() != "col3")
          return false;
        if (whereEntryList[2].GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          if (whereEntryList[2].GetColumnValue().GetDoubleColumnValue() != 44.5)
            return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() == SelectRowColumnType.SPECIFIC_COLUMNS)
      {
        List<string> columnList = ((SelectRows)statementObject).GetSelectRowTableColList().GetTableColumnList().GetList();
        if (columnList[0] != "col1")
          return false;
        if (columnList[1] != "col2")
          return false;
      }
      else
        return false;
      Message message = new Message();
      message.Msg = "SELECT query which selects specific columns was executed successfully";
      message.TestID = 56;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      
      return true;
    }


    /*
     * Test case for select query with certain count
     */
    private bool Case57()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select count(col1) from tablename where col1=47 and col2 = testcol and col3=44.5 order by col1 asc, col2 dsc limit 10 , 20;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
      {
        if (((SelectRows)statementObject).GetLimitRange().GetStartIndex() != 10)
          return false;
        if (((SelectRows)statementObject).GetLimitRange().GetCount() != 20)
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
      {
        List<OrderByEntry> orderByList = ((SelectRows)statementObject).GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();

        if (orderByList[0].GetColumnName() != "col1")
          return false;
        if (orderByList[0].GetOrderByType() != "ASC")
          return false;

        if (orderByList[1].GetColumnName() != "col2")
          return false;
        if (orderByList[1].GetOrderByType() != "DSC")
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
      {
        List<WhereEntry> whereEntryList = ((SelectRows)statementObject).GetWhereList().GetSubWhereList().GetWhereEntryList();
        if (whereEntryList[0].GetColumnName() != "col1")
          return false;
        if (whereEntryList[0].GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          if (whereEntryList[0].GetColumnValue().GetIntColumnValue() != 47)
            return false;

        if (whereEntryList[1].GetColumnName() != "col2")
          return false;
        if (whereEntryList[1].GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          if (whereEntryList[1].GetColumnValue().GetStringColumnValue() != "testcol")
            return false;

        if (whereEntryList[2].GetColumnName() != "col3")
          return false;
        if (whereEntryList[2].GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          if (whereEntryList[2].GetColumnValue().GetDoubleColumnValue() != 44.5)
            return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() == SelectRowColumnType.COUNT_ROWS)
      {
        if (((SelectRows)statementObject).GetSelectRowTableColList().GetCountRows().GetCountAllRowsFlag() == false)
        {
          if (((SelectRows)statementObject).GetSelectRowTableColList().GetCountRows().GetColumnName() != "col1")
            return false;
        }
        else
          return false;
      }
      else
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with COUNT was executed successfully";
      message.TestID = 57;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }


    /*
     * Test case for select query with certain count
     */
    private bool Case58()
    {
      QParser qParser = new QParser();
      Statement statementObject = qParser.ValidateQuery("select count(*) from tablename where col1=47 and col2 = testcol and col3=44.5 order by col1 asc, col2 dsc limit 10 , 20;");

      if (statementObject.GetStatementType() != StatementType.SELECT_ROW)
        return false;

      if (((SelectRows)statementObject).GetTableName() != "tablename")
        return false;

      if (((SelectRows)statementObject).GetLimitRangeFlag() != false)
      {
        if (((SelectRows)statementObject).GetLimitRange().GetStartIndex() != 10)
          return false;
        if (((SelectRows)statementObject).GetLimitRange().GetCount() != 20)
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetOrderByFlag() != false)
      {
        List<OrderByEntry> orderByList = ((SelectRows)statementObject).GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();

        if (orderByList[0].GetColumnName() != "col1")
          return false;
        if (orderByList[0].GetOrderByType() != "ASC")
          return false;

        if (orderByList[1].GetColumnName() != "col2")
          return false;
        if (orderByList[1].GetOrderByType() != "DSC")
          return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetWhereListFlag() != false)
      {
        List<WhereEntry> whereEntryList = ((SelectRows)statementObject).GetWhereList().GetSubWhereList().GetWhereEntryList();
        if (whereEntryList[0].GetColumnName() != "col1")
          return false;
        if (whereEntryList[0].GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          if (whereEntryList[0].GetColumnValue().GetIntColumnValue() != 47)
            return false;
        if (whereEntryList[1].GetColumnName() != "col2")
          return false;
        if (whereEntryList[1].GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          if (whereEntryList[1].GetColumnValue().GetStringColumnValue() != "testcol")
            return false;

        if (whereEntryList[2].GetColumnName() != "col3")
          return false;
        if (whereEntryList[2].GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          if (whereEntryList[2].GetColumnValue().GetDoubleColumnValue() != 44.5)
            return false;
      }
      else
        return false;

      if (((SelectRows)statementObject).GetSelectRowTableColList().GetSelectRowColumnType() == SelectRowColumnType.COUNT_ROWS)
      {
        if (((SelectRows)statementObject).GetSelectRowTableColList().GetCountRows().GetCountAllRowsFlag() != true)
          return false;
      }
      else
        return false;
      Message message = new Message();
      message.Msg = "SELECT query with COUNT was executed successfully";
      message.TestID = 58;
      message.Passed = true;
      string m_Message = message.ToString();
      messageList.Add(m_Message);
      return true;
    }


    private bool Case59()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("RENAME TABLE tab1 TO tab2;");
        RenameTable obj = (RenameTable)statementObject;
        if(obj.GetStatementType() != StatementType.RENAME_TABLE)
        return false;
        if (obj.GetOldTableName() != "tab1")
          return false;
        if (obj.GetNewTableName() != "tab2")
          return false;
        Message message = new Message();
        message.Msg = "RENAME TABLE Query was executed succesfully";
        message.TestID = 59;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }

    }

    private bool Case60()
    {
      QParser qParser = new QParser();
      try
      {
        Statement statementObject = qParser.ValidateQuery("RENAME COLUMN col1 TO col2 IN TABLE tab1;");
        RenameColumn obj = (RenameColumn)statementObject;
        if (obj.GetStatementType() != StatementType.RENAME_COLUMN)
          return false;
        if (obj.GetTableName() != "tab1")
          return false;
        if (obj.GetOldColumnName() != "col1")
          return false;
        if(obj.GetNewColumnName() != "col2")
        return false;
        Message message = new Message();
        message.Msg = "RENAME COLUMN Query was executed succesfully";
        message.TestID = 60;
        message.Passed = true;
        string m_Message = message.ToString();
        messageList.Add(m_Message);
        return true;
      }
      catch (Exception ex)
      {
        ex.ToString();
        return false;
      }

    }
  }
}
