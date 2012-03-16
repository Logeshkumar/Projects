////////////////////////////////////////////////////////////////////////////////
// Case06.cs - Test case for CSE784 Project1                                  //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Project1 Test Cases                                   //
// Author:       Phil Pratt-Szeliga, CST 4-116, Syracuse University           //
//               pcpratts@syr.edu                                             //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Project1TestCases
{
  public class Case06
  {
    private string m_String1;
    private string m_String2;
    private string m_String3;
    private string m_String4;
    private string m_String5;

    public Case06()
    {
      m_String1 = "if(x == 0){ x += 1 }";
      m_String2 = "hello \"world\"\"\"";
      m_String3 = "hello \"\\\\\"world\"\"\"\n";
      m_String4 = "/* comment in string */";
      m_String5 = "/* comment in string */";
    }

    public void print()
    {
      Console.WriteLine(m_String1);
      Console.WriteLine(m_String2);
      Console.WriteLine(m_String3);
      Console.WriteLine(m_String4);
      Console.WriteLine(m_String5);
    }
  }
}
