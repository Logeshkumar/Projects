//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Antlr.Runtime;
//using edu.syr.cse784.eskimodb.sharedobjs;

//namespace edu.syr.cse784.eskimodb.rootserver.Test
//{
//  class MockTableServerTest : ITest
//  {
//    QueryProcessor process = new QueryProcessor();
//    public bool test()
//    {
//      if (!case1())
//      {
//        return false;
//      }
//      if (!case2())
//      {
//        return false;
//      }
//      if (!case3())
//      {
//        return false;
//      }
//      if (!case4())
//      {
//        return false;
//      }
//      if (!case5())
//      {
//        return false;
//      }
//      if (!case6())
//      {
//        return false;
//      }
//      if (!case7())
//      {
//        return false;
//      }
//      if (!case8())
//      {
//        return false;
//      }
//      if (!case9())
//      {
//        return false;
//      }
//      if (!case10())
//      {
//        return false;
//      }
//      return true;
//    }

//    private bool case1()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("CREATE DB databaseName;");
//      string ret = process.createDb(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case2()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("CREATE TABLE table1(key1 VARCHAR(255));");
//      string ret = process.createTable(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case3()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("DELETE DB databasename1;");
//      string ret = process.deleteDb(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case4()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("DELETE TABLE tablename1;");
//      string ret = process.deleteTable(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case5()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("EMPTY TABLE tablename1;");
//      string ret = process.emptyTable(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case6()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("DELETE COLUMN columnname1 IN TABLE tablename1;");
//      string ret = process.modifyTable(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case7()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("ADD COLUMN key1 INT IN TABLE tablename1;");
//      string ret = process.modifyTable(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case8()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("RENAME TABLE tab1 TO tab2;");
//      string ret = process.renameTable(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case9()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("RENAME COLUMN col1 TO col2 IN TABLE tab1;");
//      string ret = process.renameColumn(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//    private bool case10()
//    {
//      QParser qParser = new QParser();
//      Statement statementObject = qParser.validateQuery("INSERT INTO c.tab1(col1,col2,col3)VALUES(val1,val2,val3);");
//      string ret = process.insertRow(statementObject);
//      if (ret == "success")
//        return true;
//      else
//        return false;
//    }
//  }
//}
