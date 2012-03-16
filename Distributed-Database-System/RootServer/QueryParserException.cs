using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.rootserver
{
  [Serializable()]
  public class QueryParserException : System.Exception
  {
    public QueryParserException() : base() { }
    public QueryParserException(string message) : base(message) { }
    public QueryParserException(string message, System.Exception inner) : base(message, inner) { }
    protected QueryParserException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) { }
  }
}
