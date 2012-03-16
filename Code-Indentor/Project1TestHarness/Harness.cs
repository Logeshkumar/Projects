////////////////////////////////////////////////////////////////////////////////
// Harness.cs    - Test Harness for Project 1                                 //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Project1 Test Harness                                 //
// Author:       Phil Pratt-Szeliga, CST 4-116, Syracuse University           //
//               pcpratts@syr.edu                                             //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace edu.syr.pcpratts.cse784.project1testharness
{
  /// <summary>
  /// The test harness
  /// </summary>
  public class Harness
  {
    private IList<TestItem> m_Items;
    private IList<TestItem> m_Passing;
    private IList<TestItem> m_Failing;

    /// <summary>
    /// Create and instance
    /// </summary>
    public Harness()
    {
      m_Items = new List<TestItem>();
      m_Passing = new List<TestItem>();
      m_Failing = new List<TestItem>();
      addItem("Case01.cs", "Case01.indent.cs");
      addItem("Case02.cs", "Case02.indent.cs");
      addItem("Case03.cs", "Case03.indent.cs");
      addItem("Case04.cs", "Case04.indent.cs");
      addItem("Case05.cs", "Case05.indent.cs");
      addItem("Case06.cs", "Case06.indent.cs");
      addItem("Case07.cs", "Case07.indent.cs");
    }

    /// <summary>
    /// Add a test case
    /// </summary>
    /// <param name="orginal">the original filename</param>
    /// <param name="indented">the indented filename</param>
    private void addItem(String orginal, String indented)
    {
      m_Items.Add(new TestItem(orginal, indented));
    }

    /// <summary>
    /// Test an indentor
    /// </summary>
    /// <param name="indentor">A class implementing Indent</param>
    public void test(Indent indentor)
    {
      foreach(TestItem item in m_Items)
      {
        doTest(item, indentor);
      }
      printResults();
    }

    /// <summary>
    /// Do a test of a TestItem
    /// </summary>
    /// <param name="item">the item to test</param>
    /// <param name="indentor">the indentor to use</param>
    private void doTest(TestItem item, Indent indentor)
    {
      string contents_original = loadContents(item.getOriginal());
      string contents_indented = indentor.indent(contents_original);
      string contents_gold = loadContents(item.getIndeted());

      if (contentsEqual(contents_indented, contents_gold))
      {
        m_Passing.Add(item);
      }
      else
      {
        m_Failing.Add(item);
      }
    }

    private bool contentsEqual(string str1, string str2)
    {
      string[] lines1 = str1.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      string[] lines2 = str2.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
      if (lines1.Length != lines2.Length)
        return false;
      for (int i = 0; i < lines1.Length; ++i)
      {
        string lhs = lines1[i].TrimEnd();
        string rhs = lines2[i].TrimEnd();
        if (lhs != rhs)
        return false;
      }
      return true;
    }

    /// <summary>
    /// Load the contents of a file based on the filename
    /// </summary>
    /// <param name="filename">the filename of the file to load</param>
    /// <returns>the file's contents as a string</returns>
    private string loadContents(string filename)
    {
      TextReader reader = new StreamReader("test-cases\\"+filename);
      string ret = reader.ReadToEnd();
      reader.Close();
      return ret;
    }

    /// <summary>
    /// Print the test results.  It prints how many and which tests pass and fail.
    /// </summary>
    private void printResults()
    {
      Console.WriteLine("Passing Tests (" + m_Passing.Count + ")");
      foreach (TestItem item in m_Passing)
      {
        Console.WriteLine("  " + item.getOriginal());
      }
      Console.WriteLine("Failing Tests (" + m_Failing.Count + ")");
      foreach (TestItem item in m_Failing)
      {
        Console.WriteLine("  " + item.getOriginal());
      }
    }

    /// <summary>
    /// Data class to hold an original filename and an indented filename
    /// </summary>
    private class TestItem
    {
      private String m_OriginalFilename;
      private String m_IndentedFilename;

      /// <summary>
      /// Create an instance
      /// </summary>
      /// <param name="original">the original filename</param>
      /// <param name="indented">the indented filename</param>
      public TestItem(String original, String indented)
      {
        m_OriginalFilename = original;
        m_IndentedFilename = indented;
      }

      /// <summary>
      /// Get the original filename
      /// </summary>
      /// <returns>the original filename</returns>
      public String getOriginal()
      {
        return m_OriginalFilename;
      }

      /// <summary>
      /// Get the indented filename
      /// </summary>
      /// <returns>the indented filename</returns>
      public String getIndeted()
      {
        return m_IndentedFilename;
      }
    }
  }
}
