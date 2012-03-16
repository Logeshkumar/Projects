///////////////////////////////////////////////////////////////////////
// TypeController.cs - Manages search for defined types              //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

/*
 * The class TypeController manages activities to detect the types in the files inputted by the user.It has a method  
 * findDefinedTypes(string file) which accepts input file from the filemodel. 
 * The file is passed to the parser which in turn calls SemiExpression and which in turn calls toker.
 * The toker tokenizes the file and passes the result to SemiExpression which inturn sends sequence of tokens that have meaning for code analysis to the parser.
 * In the parser rules are written for detecting the types : ( class, Struct, enum, interface, delegate)
 * If any type is detected the typename and corresponding filename is passed to the TypeModel for Storage.
/*
 * Build Process:
 *   Required Files:
 *   FileModel.cs, TypeModel.cs, Parser.cs, Semi.cs, Toker.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{   
  public class TypeController
  {
      
    public class enterScopeRule : CodeAnalysis.ARule
    {
      public override bool test(CSsemi.CSemiExp semi)
      {
        if (semi.Contains("{") != -1)
          doActions(semi);
        return false;  // don't stop
      }
    }
    public class displayEnterScope : CodeAnalysis.AAction
    {
      public override void doAction(CSsemi.CSemiExp semi)
      {
          TypeModel tm = new TypeModel();
          FileModel fm = new FileModel();
          
       // Console.Write("\n  Entering scope: ");

        if (semi.Contains("class") != -1)
        {
            int index = semi.Contains("class");
           // Console.Write("class: ");
            tm.addType(semi[index + 1], fm.CurrentFile);
            

        }
        else if (semi.Contains("struct") != -1)
        {
            int index = semi.Contains("struct");
            //Console.Write("struct: ");
            tm.addType(semi[index + 1], fm.CurrentFile);
        }
        else if (semi.Contains("interface") != -1)
        {
            int index = semi.Contains("class");
            //Console.Write("interface: ");
            tm.addType(semi[index + 1], fm.CurrentFile);       
        }
        else if (semi.Contains("enum") != -1)
        {
            int index = semi.Contains("class");
            //Console.Write("enum: ");
            tm.addType(semi[index + 1], fm.CurrentFile);
        }
        else if (semi.Contains("delegte") != -1)
        {
            int index = semi.Contains("delegate");
            //Console.Write("delegate: ");
            tm.addType(semi[index + 2], fm.CurrentFile);
        }
        else

            Console.Write("");

        }
    }

    public void findDefinedTypes(string file)
    {
      CodeAnalysis.Parser p = new CodeAnalysis.Parser();
      enterScopeRule esr = new enterScopeRule();
      displayEnterScope des = new displayEnterScope();
      esr.add(des);
      p.add(esr);
      CSsemi.CSemiExp semi = new CSsemi.CSemiExp();
      
      if (!semi.open(file))
      {
        Console.Write("\n\n  can't open file {0} for analysis\n", file);
      }
      while (semi.getSemi())
        p.parse(semi);
    }
  }
}
