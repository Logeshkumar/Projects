////////////////////////////////////////////////////////////////////////////////
// Program.cs    - Main modules for CSE784 Project1 Test Harness              //
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
  /// Contains the entry point for the Project1TestHarness.
  /// </summary>
  class Program
  {
    /// <summary>
    /// The entry point for the test harness
    /// </summary>
    /// <param name="args">command line arguments.  (ignored)</param>
    static void Main(string[] args)
    {
      NullIndentor indentor = new NullIndentor();
      Harness harness = new Harness();
      harness.test(indentor);
      Console.ReadLine();

    }
  }
}
