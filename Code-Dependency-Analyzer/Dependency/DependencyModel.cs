///////////////////////////////////////////////////////////////////////
// TypeModel.cs - Manages defined type storage                       //
// V1.1                                                              //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////
/*
 * The class TypeModel manages a Dictionary with file name as  key.
 * The value for each key is a list of dependent files.
 * 
 * The Dictionary is declared static so that access to the Dictionary
 * is enabled whenever an instance of the DependencyModel class is created.
 * The instances all share the same Dictionary.
 * 
 * the DependencyModel uses the addDependency method to add the filename and its dependent files to the Dependency table.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
    public class DependencyModel
    {
        /*   --> A dictionary is defined to store the current filename and its dependent files. 
      Thus the structure is a string for the current file and List<string> for the dependent file. <--  */
       private static Dictionary<string, List<string>> DependencyTable = new Dictionary<string, List<string>>();

      
      /* The addDependency method receives the key filename and its dependent files from the Dependency Controller 
       * It stores these results in the Dependency TAble according to the dictionary defined
       * i.e Current Filename and its dependent filnames*/

        public void addDependency(string typename, string filename)
       {
           if (DependencyTable.ContainsKey(typename))
           {
               int flag = 0;
               foreach (string list in DependencyTable[typename])
                   if (filename == list)
                       flag = 1;
               if(flag==0)
                    DependencyTable[typename].Add(filename);
           }
           else
           {
               List<string> itemList = new List<string>();
               itemList.Add(filename);
               DependencyTable.Add(typename,itemList);
           }
       }
       
      
      
        // returns a Dictionary containing the values of the DepedencyTable .
       public Dictionary<string, List<string>> dictionary()
       {
           return DependencyTable;
       }
    }
}
