///////////////////////////////////////////////////////////////////////
// TypeModel.cs - Manages defined type storage                       //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////
/*
 * The class TypeModel manages a Dictionary with type name keys.  The
 * value for each key is a string, where each item contains a list of files.
 * 
 * The Dictionary is declared static so that access to the Dictionary
 * is enabled whenever an instance of the TypeModel class is created.
 * The instances all share the same Dictionary.
 * The TypeController passes the the detected types and corresponding filenames to the addtype method 
 * The addType adds the details to the dictionary Typtable.
 * the Typetable is then passed to FileView for displaying.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
  public class TypeModel
  {
      /*   --> A dictionary is defined to store the typename detected and the filename. 
      Thus the structure is a string for the detected type and List<string> for the filenames in which the type is present. <--  */
    private static Dictionary<string, List<string>> TypeTable = new Dictionary<string, List<string>>();

      /*   --> The addtype method receives input from the typecontroller
     * i.e the detected typename and the corresponding files and stores the result in a type table of the dictionary defined above.
     * If the typename is already present in the table the filename alone is added to the list
     * Else the new type and is file is added to the tpe table..
     * Thus in this way the typetable is populated. <--  */
    public void addType(string typename, string filename)
    {
     
      
      if (TypeTable.ContainsKey(typename))
      {
          TypeTable[typename].Add(filename);
      }
      else
      {
          List<string> itemList = new List<string>();
          itemList.Add(filename);
          TypeTable.Add(typename,itemList);
      }
    }
    // This method is used by the dependency controller for detecting the dependencies amoung the files inputted.
    public Dictionary<string, List<string>> dictionary()
    {
      return TypeTable;
    }
  }
}
