///////////////////////////////////////////////////////////////////////
// FileView.cs - displays retrieved file data                        //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
  public class FileView
  {
      static int count = 0;
    public void Display(bool showArgs)
    {
      if (showArgs)
      {
        string[] args = System.Environment.GetCommandLineArgs();
        Console.Write("\n  Command line arguments are:\n  ");
         foreach (string arg in args.Skip<string>(1))
        {
          Console.Write("{0} ", arg);
        }
        Console.WriteLine();
      }
      Console.Write("\n  Working file set:");
      Console.Write("\n -------------------");

      FileModel fm = new FileModel();
      List<string> files = fm.files();
      foreach (string file in files)
      {
          Console.Write("\n  {0}", file);
          Console.Write("\n");
          count++;
      }
      List<string> invalidPaths = fm.invalidPaths();
      foreach (string invalid in invalidPaths)
        Console.Write("\n  invalid path {0}", invalid);
    }
    public void displaySum() {
        Console.Write(" Summary\n --------\n");
        Console.Write("\n Total files processed by the Analyzer: {0}", count);
    }
  }
}
