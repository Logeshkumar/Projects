///////////////////////////////////////////////////////////////////////
// FileModelTest.cs - Construction test for FileModel                //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
  class FileModelTest
  {
    public static int Main(string[] args)
    {
      
      Console.Write("\n  Testing FileModel");
      Console.Write("\n ===================\n");

      string[] patterns = new string[1] { "*.cs" };
      FileModel fm = new FileModel();
      fm.collectFiles(args, patterns, true, true);
      List<string> fileList = fm.files();
      FileView fv = new FileView();
      fv.Display(true);
      return 0;
    }
   
  }
}
