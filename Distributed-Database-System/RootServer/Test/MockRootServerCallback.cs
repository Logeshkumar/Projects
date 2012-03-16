using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver.Test
{
  class MockRootServerCallback : IRootServerCallback
  {
    public void PutDataset(QueryResult result, string id, QueryDataset data)
    {
      Console.WriteLine("Mock root server PutDataset callback called.");
      Console.WriteLine("Query Result: " + result.GetMessage());
    }

    public void PutQueryInfo(QueryResult result, string id, long lines)
    {
      Console.WriteLine("Mock root server PutQueryInfo callback called.");
      Console.WriteLine("Query Result: " + result.GetMessage());
    }
  }
}
