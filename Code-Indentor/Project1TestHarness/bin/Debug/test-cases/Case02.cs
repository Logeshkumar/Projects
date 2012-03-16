////////////////////////////////////////////////////////////////////////////////
// Case02.cs - Test case for CSE784 Project1                                  //
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
  public class Case02
  {
    private int m_Variable1;

    public Case02()
    {
      m_Variable1 = 10;
    }

    public void print()
    {
      Console.WriteLine(m_Variable1);
    }
  }
}
