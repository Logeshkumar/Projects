///////////////////////////////////////////////////////////////////////
// Parser.cs - Parser detects code constructs defined by rules       //
// ver 1.0                                                           //
// Language:    C#, 2008, .Net Framework 3.5                         //
// Platform:    Dell Precision T7400, Vista Ultimate, SP1            //
// Application: Demonstration for CSE687, Project #1, Summer 2009    //
// Author:      Jim Fawcett, CST 4-187, Syracuse University          //
//              (315) 443-3948, jfawcett@twcny.rr.com                //
///////////////////////////////////////////////////////////////////////
/*
 * Module Operations:
 * ------------------
 * This module defines the following classes:
 *   Parser  - a collection of IRules
 *   IRule   - interface contract for Rules
 *   ARule   - abstract base class for Rules that defines some common ops
 *   IAction - interface contract for rule actions
 *   AAction - abstract base class for actions that defines common ops
 *   
 *   Four rules which each have a grammar construct detector and also
 *   a collection of IActions:
 *   - DetectNameSpace rule
 *   - DetectClass rule
 *   - DetectFunction rule
 *   - DetectScopeChange
 *   
 *   Three actions - some are specific to a parent rule:
 *   - Print
 *   - PrintFunction
 *   - PrintScope
 *   
 *   There is also a testParser class with two nested builder classes:
 *   - TestParser
 *   - BuildTypeAnal assembles parts for a type analyzer
 *   - BuildScopeAnal assembles parts for a scope analyzer
 */
/* Required Files:
 *   Parser.cs, Semi.cs, Toker.cs
 *   
 * Build command:
 *   csc /D:TEST_PARSER Parser.cs Semi.cs Toker.cs
 *   
 * Maintenance History:
 * --------------------
 *   ver 1.0 : 17 May 09
 *   - first release
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeAnalysis
{
  /////////////////////////////////////////////////////////
  // contract for actions used by parser rules

  public interface IAction
  {
    void doAction(CSsemi.CSemiExp semi);
  }
  /////////////////////////////////////////////////////////
  // abstract action base supplying common functions

  public abstract class AAction : IAction
  {
    public abstract void doAction(CSsemi.CSemiExp semi);
    public virtual void display(CSsemi.CSemiExp semi)
    {
      Console.Write("\n  ");
      for(int i=0; i<semi.count; ++i)
        Console.Write("{0,-15}",semi[i]);
    }
  }
  /////////////////////////////////////////////////////////
  // concrete printing action, used by several rules

  public class Print : AAction
  {
    public override void doAction(CSsemi.CSemiExp semi)
    {
      this.display(semi);
    }
  }
  /////////////////////////////////////////////////////////
  // contract for parser rules

  public interface IRule
  {
    bool test(CSsemi.CSemiExp semi);
    void add(IAction action);
  }
  /////////////////////////////////////////////////////////
  // abstract rule base implementing common functions

  public abstract class ARule : IRule
  {
    private ArrayList actions;
    public ARule()
    {
      actions = new ArrayList();
    }
    public void add(IAction action)
    {
      actions.Add(action);
    }
    abstract public bool test(CSsemi.CSemiExp semi);
    public void doActions(CSsemi.CSemiExp semi)
    {
      foreach(IAction action in actions)
        action.doAction(semi);
    }
    public int indexOfType(CSsemi.CSemiExp semi)
    {
      int indexCL = semi.Contains("class");
      int indexIF = semi.Contains("interface");
      int indexST = semi.Contains("struct");
      int indexEN = semi.Contains("enum");

      int index = Math.Max(indexCL, indexIF);
      index = Math.Max(index, indexST);
      index = Math.Max(index, indexEN);
      return index;
    }
  }
  /////////////////////////////////////////////////////////
  // rule to detect namespace declarations

  public class DetectNamespace : ARule
  {
    public override bool test(CSsemi.CSemiExp semi)
    {
      int index = semi.Contains("namespace");
      if (index != -1)
      {
        CSsemi.CSemiExp local = new CSsemi.CSemiExp();
        local.displayNewLines = false;
        local.Add(semi[index]).Add(semi[index + 1]);
        doActions(local);
      }
      return false;
    }
  }
  /////////////////////////////////////////////////////////
  // rule to dectect class definitions

  public class DetectClass : ARule
  {
    public override bool test(CSsemi.CSemiExp semi)
    {
      int indexCL = semi.Contains("class");
      int indexIF = semi.Contains("interface");
      int indexST = semi.Contains("struct");

      int index = Math.Max(indexCL, indexIF);
      index = Math.Max(index, indexST);
      if (index != -1)
      {
        CSsemi.CSemiExp local = new CSsemi.CSemiExp();
        local.displayNewLines = false;
        local.Add(semi[index]).Add(semi[index + 1]);
        doActions(local);
      }
      return false;
    }
  }
  /////////////////////////////////////////////////////////
  // rule to dectect function definitions

  public class DetectFunction : ARule
  {
    private Stack scope_;
    public DetectFunction(Stack scope)
    {
      scope_ = scope;
    }
    public static bool isSpecialToken(string token)
    {
      string[] SpecialToken = { "if", "for", "foreach", "while", "catch" };
      foreach (string stoken in SpecialToken)
        if (stoken == token)
          return true;
      return false;
    }
    public override bool test(CSsemi.CSemiExp semi)
    {
      if(semi[semi.count-1] != "{")
        return false;
      int index = semi.Contains("(");
      if(index != -1 && !isSpecialToken(semi[index-1]))
        doActions(semi);
      return false;
    }
  }
  /////////////////////////////////////////////////////////
  // action to print function signatures

  public class PrintFunction : AAction
  {
    public override void display(CSsemi.CSemiExp semi)
    {
      Console.Write("\n    ");
      for (int i = 0; i < semi.count-1; ++i)
        if(semi[i] != "\n")
          Console.Write("{0} ", semi[i]);
    }
    public override void doAction(CSsemi.CSemiExp semi)
    {
      this.display(semi);
    }
  }
  /////////////////////////////////////////////////////////
  // rule to detect entering and leaving a scope

  public class DetectScopeChange : ARule
  {
    private Stack scope_;

    private CSsemi.CSemiExp scopeToSemi(Stack scope)
    {
      object[] StrArr = scope.ToArray();
      CSsemi.CSemiExp local = new CSsemi.CSemiExp();
      foreach (object str in StrArr)
        local.Add((string)str);
      return local;
    }
    public DetectScopeChange(Stack scope)
    {
      scope_ = scope;
    }
    public override bool test(CSsemi.CSemiExp semi)
      {
        if (semi.count > 0 && semi[semi.count - 1] == "}")
        {
          scope_.Pop();
          semi.display();
          doActions(scopeToSemi(scope_));
        }
        else if (semi.count > 0 && semi[semi.count - 1] == "{")
        {
          int index = semi.Contains("namespace");
          if (index != -1)
          {
            string temp = "namespace:" + semi[index + 1];
            scope_.Push(temp);
          }
          else
          {
            index = indexOfType(semi);
            if (index != -1)
            {
              string temp = "type:" + semi[index + 1];
              scope_.Push(temp);
            }
            else
            {
              int jndex = semi.Contains("(");
              if (jndex != -1 && !DetectFunction.isSpecialToken(semi[jndex - 1]))
              {
                string temp = "function:" + semi[jndex - 1];
                scope_.Push(temp);
              }
              else
                scope_.Push("local");
            }
          }
          Console.WriteLine();
          semi.display();
          doActions(scopeToSemi(scope_));
        }
        return false;
      }
  }
  /////////////////////////////////////////////////////////
  // action to display scope stack contents

  public class PrintScope : AAction
  {
    public override void display(CSsemi.CSemiExp semi)
    {
      Console.Write("\n  Scope: ");
      for (int i = 0; i < semi.count; ++i)
        Console.Write("{0} ", semi[i]);
    }
    public override void doAction(CSsemi.CSemiExp semi)
    {
      this.display(semi);
    }
  }
  /////////////////////////////////////////////////////////
  // rule-based parser used for code analysis

  public class Parser
  {
    private ArrayList Rules;
    private Stack Scope;

    public Parser()
    {
      Rules = new ArrayList();
      Scope = new Stack();
    }
    public Stack ScopeStack()
    {
      return Scope;
    }
    public void add(IRule rule)
    {
      Rules.Add(rule);
    }
    public void parse(CSsemi.CSemiExp semi)
    {
      foreach(IRule rule in Rules)
        if(rule.test(semi))
          break;
    }
  }
#if(TEST_PARSER)

  class TestParser
  {
    /////////////////////////////////////////////////////////
    // nested class to build type analyzers

    class BuildTypeAnal
    {
      public virtual Parser build()
      {
        Parser parser = new Parser();
        Print print = new Print();
        DetectNamespace detectNS = new DetectNamespace();
        detectNS.add(print);
        parser.add(detectNS);
        DetectClass detectCl = new DetectClass();
        detectCl.add(print);
        parser.add(detectCl);
        ///////////////////////////////////////////////////
        // If you wanted to show member functions you 
        // might do that something like this:
        //   DetectFunction detectFN = new DetectFunction(parser.ScopeStack());
        //   PrintFunction printFunction = new PrintFunction();
        //   detectFN.add(printFunction);
        //   parser.add(detectFN);
        return parser;
      }
    }
    /////////////////////////////////////////////////////////
    // nesed class to build scope analyzers

    class BuildScopeAnal
    {
      public virtual Parser build()
      {
        Parser parser = new Parser();
        DetectScopeChange detectSC = new DetectScopeChange(parser.ScopeStack());
        IAction print = new PrintScope();
        detectSC.add(print);
        parser.add(detectSC);
        return parser;
      }
    }
    static ArrayList ProcessCommandline(string[] args)
    {
      ArrayList files = new ArrayList();
      if (args.Length < 2)
      {
        Console.Write("\n  Please enter path and one or more files to analyze\n\n");
        return files;
      }
      string path = args[0];
      path = Path.GetFullPath(path);
      Console.Write("\n  Parser will attempt to process files on this path:");
      Console.Write("\n  {0}\n", path);

      for (int i = 1; i < args.Length; ++i)
      {
        try
        {
          int count = files.Count;
          string filename = Path.GetFileName(args[i]);
          files.AddRange(Directory.GetFiles(path, filename));
          if (files.Count == count)
            Console.Write("\n  can't find file {0}", filename);
        }
        catch (Exception ex)
        {
          Console.Write("\n\n  {0}\n", ex.Message);
        }
      }
      return files;
    }
    static void Main(string[] args)
    {
      Console.Write("\n  Demonstrating Parser");
      Console.Write("\n ======================\n");

      ArrayList files = TestParser.ProcessCommandline(args);

      if (files.Count == 0)
      {
        Console.Write("\n  couldn't retrieve any files to process\n\n");
        return;
      }
      foreach (object file in files)
      {
        Console.Write("\n  Processing file {0}\n", file as string);

        CSsemi.CSemiExp semi = new CSsemi.CSemiExp();
        semi.displayNewLines = false;
        if (!semi.open(file as string))
        {
          Console.Write("\n  Can't open {0}\n\n", args[0]);
          return;
        }

        Console.Write("\n  First - Type Analysis");
        Console.Write("\n -----------------------\n");

        BuildTypeAnal TAbuilder = new BuildTypeAnal();
        Parser parser = TAbuilder.build();

        while (semi.getSemi())
          parser.parse(semi);
        Console.Write("\n\n  That's all the types folks!\n\n");
        semi.close();

        Console.Write("\n  Now - Scope Analysis");
        Console.Write("\n ----------------------");

        BuildScopeAnal SAbuilder = new BuildScopeAnal();
        parser = SAbuilder.build();

        if (!semi.open(file as string))
        {
          Console.Write("\n  Can't open {0}\n\n", file as string);
          return;
        }
        while (semi.getSemi())
          parser.parse(semi);

        Console.Write("\n\n  That's all the scopes folks!\n\n");
      }
    }
  }
#endif
}
