///////////////////////////////////////////////////////////////////////
// Program.cs - uses ExecutiveController to structure program flow   //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2020   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
  class Program
  {
    static void Main(string[] args)
    {
        Console.SetBufferSize(1000, 1000);
      Console.Write("\n  Project #2 ");
      Console.Write("\n ===========\n");

      ExecutiveController ec = new ExecutiveController();
      ec.CollectCSharpFileReferences();
      ec.FindDefinedTypes();
      ec.FindDependencies();
            Console.ReadLine();
      Console.Write("\n\n");
    }
  }
}
