/////////////////////////////////////////////////////////////////////////////////////////////
//  NullIndentor.cs -              Indenter that indents the code                          //
//  Language:                      Visual C# 4.0      				                             //
//  Platform:                      Windows 7								                               //
//  Application:                   Code Indentor      			                               //
//  Author:                        logeshkumar								                             //
/////////////////////////////////////////////////////////////////////////////////////////////

/*
Maintainence History:
=====================
ver 1.0 01 October 2011
- first release
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Project1TestHarness;

namespace edu.syr.pcpratts.cse784.project1testharness
{

  public class NullIndentor : Indent
  {
    List<string> file = new List<string>();
    /// <summary>
    /// Execute the indentation
    /// </summary>
    /// <param name="code">the original code to indent</param>
    /// <returns>the indented code</returns>
    

    //Performs indentation to the inputted code
    public string indent(string code)
    {
      NullIndentor list = new NullIndentor();
      List<string> lis = new List<string>();
      lis = list.convertToList(code);      
      List<string> fileList = new List<string>();
      Storage container = new Storage();
      Layers layer = new Layers();
      foreach (string line in lis)
      {
        Regex r = new Regex(@"\s+");         // regular expression which removes extra spaces
        string lin = r.Replace(line, @" ");  //and replaces it with single space
        CharEnumerator Cnum = lin.GetEnumerator();
        CharEnumerator Cnum2 = (CharEnumerator)Cnum.Clone();
        CommentTokenizer CommentTok = new CommentTokenizer();
        string s = CommentTok.CommentRemover(Cnum);
        if (s == null)
        {
          StringTokenizer Stok = new StringTokenizer();
          Stok.stringtok(Cnum2);
        }
      }      
      file = container.getContainer1();      
      fileList = layer.setList(file);
      code = null;
      foreach (string line in fileList)
      {
        code += line;
      }
      return code;
    }

    // Convertin th inputted code from string to a list
    public List<string> convertToList(string code)
    {
      List<string> fileList = new List<string>();
      TextReader reader = new StringReader(code);
      while (true)
      {
        string line = reader.ReadLine();
        if (line == null)
          break;
        fileList.Add(line);
      }
      reader.Close();
      return fileList;

    }
  }
}
