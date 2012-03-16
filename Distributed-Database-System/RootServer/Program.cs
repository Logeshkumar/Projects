using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class Program
  {
    public void ValidateQuery(String query)
    {
      ANTLRStringStream string_stream = new ANTLRStringStream(query);
      QueryLexer lexer = new QueryLexer(string_stream);
      CommonTokenStream tokens = new CommonTokenStream(lexer);
      QueryParser parser = new QueryParser(tokens);
      QueryParser.statement_return obj = parser.statement();
      Statement StatementObject = obj.ret;
      if (StatementObject is CreateTable)
      {
        CreateTable mod = (CreateTable)StatementObject;
        
      }
    }
    /*
        static void Main(string[] args)
        {
          Program Eskimoquery = new Program();
          Eskimoquery.ValidateQuery("CREATE TABLE table1(PRIMARY KEY key1 CHAR);");
        }*/
  }
}

