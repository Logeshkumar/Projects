using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Antlr.Runtime;


namespace edu.syr.cse784.eskimodb.rootserver
{
  public class QParser
  {
    private TokenProcessor m_TokenProcessor;

    public QParser()
    {
      m_TokenProcessor = new TokenProcessor();
    }
    
    public Statement ValidateQuery(string query)
    {
      Statement ret = null;
      try
      {
        ANTLRStringStream string_stream = new ANTLRStringStream(query);
        QueryLexer lexer = new QueryLexer(string_stream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        QueryParser parser = new QueryParser(tokens);

        QueryParser.statement_return obj = parser.statement();
        ret = obj.ret;

      }
      catch (Antlr.Runtime.MismatchedTokenException ex)
      {
        string token = m_TokenProcessor.GetTokenName(ex.Expecting);

        if (token == null)
          token = ".";
        else
          token = token + ".";

        string msg = "Error in processing query. Missing or invalid statement. Expecting: " + token;

        QueryParserException exception = new QueryParserException(msg);
        throw exception;
      }
      catch (Antlr.Runtime.MismatchedTreeNodeException ex)
      {
        QueryParserException exception = new QueryParserException(ex.Message);
        throw exception;
      }
      catch (Antlr.Runtime.NoViableAltException ex)
      {
        QueryParserException exception = new QueryParserException(ex.Message);
        throw exception;
      }
      catch (Antlr.Runtime.EarlyExitException ex)
      {
        QueryParserException exception = new QueryParserException(ex.Message);
        throw exception;
      }
      catch (Antlr.Runtime.FailedPredicateException ex)
      {
        QueryParserException exception = new QueryParserException(ex.Message);
        throw exception;
      }
      catch (Antlr.Runtime.MismatchedRangeException ex)
      {
        QueryParserException exception = new QueryParserException(ex.Message);
        throw exception;
      }
      catch (Antlr.Runtime.MismatchedSetException ex)
      {
        QueryParserException exception = new QueryParserException(ex.Message);
        throw exception;
      }
      catch (Antlr.Runtime.RecognitionException ex)
      {
        QueryParserException exception = new QueryParserException(ex.Message);
        throw exception;
      }
      catch (QueryParserException ex)
      {
        throw ex;
      }
        
      return ret;
    }

  
#if(TESTMAIN)
    static void Main(string[] args)
    {
      try
      {
        QParser qParser = new QParser();
        Statement statementObject = qParser.ValidateQuery("select count(col) from tablename where col = mynew and col2 = 3;");
      }
      catch (QueryParserException ex)
      {
        Console.WriteLine(ex.Message);
      }

    }
#endif
  }
}
