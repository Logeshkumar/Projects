///////////////////////////////////////////////////////////////////////
// TypeController.cs - Manages search for defined types              //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
    class DependencyTest
    {
        static void Main(string[] args)
        {
            DependencyModel DM = new DependencyModel();
            TypeModel TM = new TypeModel();
            TM.addType("X", "XFile");
            TM.addType("X", "YFile");
            TM.addType("Y", "ZFile");
            TypeView tv = new TypeView();
            tv.Display();
            Console.Write("\n\n");
            DM.addDependency("XFile", "YFile");
            DependencyView depv = new DependencyView();
            depv.Display();
        }
    }
}