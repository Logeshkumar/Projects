///////////////////////////////////////////////////////////////////////
// ExecutiveController.cs - controls analysis flow                   //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////
/*
 * The class ExecutiveController manages all the activities of the Dependency
 * Analyzer.
 */
/*
 * Build Process:
 *   Required Files:
 *   All files in this solution
 *   Required References:
 *     FileModel Project
 *     Types Project
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo
{
  public class ExecutiveController
  {
    private FileModel fm = new FileModel();
    private TypeModel tm = new TypeModel();
    /////////////////////////////////////////////////////////////
    // exercise for student:
    // private UsingModel um = new UsingModel();  
    // private DependencyModel dm = new DependencyModel();

    //----< search directory trees rooted at each input path >---------------

    public void CollectCSharpFileReferences()
    {
      List<string> paths = new List<string>(System.Environment.GetCommandLineArgs());
      paths.RemoveAt(0);
      string[] patterns = new string[1] { "*.cs" };
      bool recurse = true;
      bool makeUnique = true;
      fm.collectFiles(paths.ToArray<string>(), patterns, recurse, makeUnique);
      FileView fv = new FileView();
      bool showArgs = true;
      fv.Display(showArgs);
    }
    //----< populate TypeModel and UsingModel using TypeController >---------
    //
    //  Assumes CollectCSharpFileReferences() has already been called
    //
    public void FindDefinedTypes()
    {
      //Console.Write("\n  --- FindDefinedTypes() shows how to integrate parser into analysis. ---");
      //Console.Write("\n  --- You will need to add rules and actions to meet requirements. ---\n");

      TypeController tc = new TypeController();
      FileModel fm = new FileModel();
      foreach (string file in fm.files())
      {
        fm.CurrentFile = file;
        tc.findDefinedTypes(file);
      }
      TypeView typev = new TypeView();
      typev.Display();

    }
    //----< match tokens and usings with TypeModel >-------------------------

    public void FindDependencies()

    {
      // Console.Write("\n  --- FindDefinedTypes() shows how to integrate parser into analysis. ---");
      //Console.Write("\n  --- You will need to add rules and actions to meet requirements. ---\n");

      DependencyController dc = new DependencyController();
      FileModel fm = new FileModel();
        List<string> file = fm.files();
        Console.WriteLine();
        dc.findDependency(file);
        DependencyView depv = new DependencyView();
        depv.Display();
        
        Displaysummary();
       
      //foreach (string file in fm.files())
      //{        fm.CurrentFile = file;
        //dc.findDependency(file);
      }
    public void Displaysummary()
    {
        FileView fvs = new FileView();
        TypeView tvs = new TypeView();
        DependencyView dvs = new DependencyView();
        fvs.displaySum();
        tvs.displaySum();
        dvs.displaySum();
    }
    }
  
}
