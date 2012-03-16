///////////////////////////////////////////////////////////////////////
// TypeView.cs - Displays results of defined type analysis           //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

/*
 * The class TypeView prints the contents of the Typetable.
 * The types and their associated files are printed in the console.
 * It uses TypeModel to obtain the Typetable contents and thus prints the output.
 */
/*
 * Build Process:
 *   Required Files:
 *   TypeModel.cs
 *
 * Maintenance History:
 *   V1.1 : 20 Sep 10
 *   - Added these and other comments
 *   V1.0 : 15 Sep 10
 *   - first release
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
  public class TypeView
  {
      // This method displays the contents of the TypeTable.
    public void Display()
    {
      Console.Write("\n \n \n TYPE TABLE CONTENTS");
      Console.Write("\n --------------------");

      TypeModel tm = new TypeModel();
      Dictionary<string, List<string>> TypeTable = tm.dictionary();
      foreach (string key in TypeTable.Keys)
      {
        Console.Write("\n\n\n >>>>>> Type: {0}  ", key);
        foreach (string item in TypeTable[key])
        {
          Console.Write("\n        <");
          Console.Write("File {0}", item);

          Console.Write("> <<<<<<");
        }
      }
    }
      // This method dispalys the total number of types detected.
    public void displaySum()
    {
        TypeModel tm = new TypeModel();
        Dictionary<string, List<string>> TypeTable = tm.dictionary();
        Console.WriteLine("\n Total Types found in the analyzed files are: {0}", TypeTable.Count);

    }
  }
}
