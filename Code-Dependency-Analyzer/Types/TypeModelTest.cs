///////////////////////////////////////////////////////////////////////
// TypeModelTest.cs - Construction test for TypeModel                //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
  class TypeModelTest
  {
    static void Main(string[] args)
       {

           TypeModel types = new TypeModel();
           types.addType("X", "XFile");
           types.addType("X", "YFile");
           types.addType("Y", "ZFile");
           TypeView tv = new TypeView();
           tv.Display();
           Console.Write("\n\n");

           
    }
  }
}
