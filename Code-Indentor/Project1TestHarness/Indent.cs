////////////////////////////////////////////////////////////////////////////////
// Indent.cs     - Contains the Indent interface                              //
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

namespace edu.syr.pcpratts.cse784.project1testharness
{
  /// <summary>
  /// Interface for classes that wish to support indenting C# files.
  /// In Project 1, you must have only one class that supports this interface.
  /// </summary>
  public interface Indent
  {
    /// <summary>
    /// Execute the indentation
    /// </summary>
    /// <param name="code">the original code to indent</param>
    /// <returns>the indented code</returns>
    string indent(string code);
  }
}
