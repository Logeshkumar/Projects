///////////////////////////////////////////////////////////////////////
// TypeView.cs - Displays results of defined type analysis           //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

/*
 * The class DependencyView prints the contents of the dependency table.
 * The file and its dependent files are printed in the console.
 * It uses DependencyModel to obtain the Dependencytable contents and thus prints the output.
/*
 * Build Process:
 *   Required Files:
 *   DependencyModel.cs
 *
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
    public class DependencyView
    {
        // This method displays the contents of the Dependency Table.
        public void Display()
        {
            Console.Write("\n \n \n DEPENDENCY TABLE CONTENTS");
            Console.Write("\n --------------------------\n\n");

            DependencyModel dm = new DependencyModel();
            foreach (KeyValuePair<string, List<string>> item in dm.dictionary())
            {
                Console.WriteLine();
                Console.WriteLine(" C# FILE  -->  " + item.Key + ": is dependent on the following files \n");
                foreach (string value in item.Value)
                    Console.WriteLine("\t" + value);
                Console.WriteLine("-------------------------------------------\n\n");
            }
        }

        // This method dispalys the total number of dependencies detected.
        public void displaySum()
        { 
            DependencyModel dm = new DependencyModel();
            Dictionary<string, List<string>> DepTable = dm.dictionary();
            Console.WriteLine(" Total Dependent files found by the Analyzer: {0}", DepTable.Count);
        }
            
    }
}
