using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.executor
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] TestString = new string[1];
      TestString[0] = "This-is-from-executor";
      Executor.Execute(@"C:\Users\shaz\Documents\visual studio 2010\Projects\TestExe\TestExe\bin\Debug\TestExe.exe", TestString);
    }
  }
}
