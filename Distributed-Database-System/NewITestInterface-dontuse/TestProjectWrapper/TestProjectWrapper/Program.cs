using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageExample;

namespace TestProjectWrapper
{
  class Program :ITest
  {
   
    public List<Message> test()
    {
       List<Message> ret = new List<Message>();
      MessageExample.Message first = new MessageExample.Message();
      first.Msg = "hello earth";
      first.Passed = true;
      first.TestID = 1;
      ret.Add(first);
      Message second = new Message();
      second.Msg = "hello moon";
      second.Passed = true;
      second.TestID = 2;
      ret.Add(second);
      return ret;
    }
  }
}
