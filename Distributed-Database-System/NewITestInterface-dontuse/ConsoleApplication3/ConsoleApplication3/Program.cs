using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageExample;

namespace ConsoleApplication3
{
  class Program
  {
    static void Main(string[] args)
    {
      Loader loader = new Loader();
      loader.LoadFile(@"C:\Users\shaz\Documents\visual studio 2010\Projects\ConsoleApplication3\ConsoleApplication3\bin\Debug\TestProjectWrapper.dll");
      List<WrappedMessageList> lstLstMsg = loader.GetTestInterface();
      
      
      foreach(WrappedMessageList lm in lstLstMsg)
      {
        for (int i = 0; i < lm.getCount(); i++)
        {
          Message m = lm.getMessage(i);
          Console.WriteLine(m.Msg);
          Console.WriteLine(m.Passed.ToString());
          Console.WriteLine(m.TestID.ToString());
        }

      }
    }
  }
}
