using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MessageExample
{
  class Program
  {
    static void Main(string[] args)
    {
      Object o = new TestCase();
      MethodInfo method = o.GetType().GetMethod("test");
      Object result = method.Invoke(o, new object[0]);
      WrappedMessageList list = new WrappedMessageList(result);
      for (int i = 0; i < list.getCount(); ++i)
      {
        Message curr = list.getMessage(i);
        Console.WriteLine(curr.Msg);
      }
    }
  }
}
