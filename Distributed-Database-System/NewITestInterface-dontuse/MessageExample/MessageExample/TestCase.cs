using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageExample
{
  class TestCase : ITest
  {
    public List<Message> test()
    {
      List<Message> ret = new List<Message>();
      Message first = new Message();
      first.Msg = "hello earth";
      ret.Add(first);
      Message second = new Message();
      second.Msg = "hello moon";
      ret.Add(second);
      return ret;
    }
  }
}
