using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example2
{
  class Program
  {
    static void Main(string[] args)
    {
      ClientAPI api = new ClientAPI();
      ResultSet set = api.ExecuteQuery("hello world");
      while (set.hasNext())
      {
        Console.WriteLine(set.getString());
      }
    }
  }
}
