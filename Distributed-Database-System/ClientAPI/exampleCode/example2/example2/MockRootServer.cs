using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example2
{
  class MockRootServer
  {
    private List<string> results;
    private int index;
    private int only_id = 10;

    public MockRootServer()
    {
      results = new List<string>();
      for (int i = 0; i < 100; ++i)
      {
        results.Add("Hello World: " + i);
      }
    }

    public int ExecuteQuery(string query, out int len)
    {
      index = 0;
      len = results.Count;
      return only_id;
    }

    public void GetSomeRows(int id, int start_index, int count, Callback callback)
    {
      List<string> ret = new List<string>();
      int end_index = start_index + count;
      if (end_index > results.Count)
      {
        end_index = results.Count;
      }
      for (int i = start_index; i < end_index; ++i)
      {
        ret.Add(results[i]);
      }
      callback.recieve(ret);
    }
  }
}
