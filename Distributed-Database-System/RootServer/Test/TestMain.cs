/////////////////////////////////////////////////////////////////////////////////////////////
//  TestMain.cs:                   Main Executive which outputs test case results          //
//  Language:                      C#, .Net Framework 4.0      				                     //
//  Platform:                      Windows 7								                               //
//  Application:                   EskimoDB - RootServer                                   //
/////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Module Operations:
 * =================
 * This module is responsible for making calls to classes implementing ITest interface
 * to execute vrious test cases and output the results(Success or Failure)
 * /
/*
Maintainence History:
=====================
ver 1.0 : 03 October 2011
- first release
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.testinterface;

namespace edu.syr.cse784.eskimodb.rootserver.Test
{
  public class TestMain
  {
    public static void Main(string[] args)
    {
      List<ITest> tests = new List<ITest>();
      ParserTest parserT = new ParserTest();
      List<string> messageList = new List<string>();
      tests.Add(parserT);    
      foreach (ITest test in tests)
      {
        test.Test();
      }
      messageList= parserT.GetMessage();

      foreach (string message in messageList)
      {
        Console.WriteLine("{0}\n", message);
      }
   
    }
  }

}
