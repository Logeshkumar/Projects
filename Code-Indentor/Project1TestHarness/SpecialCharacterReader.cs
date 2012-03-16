/////////////////////////////////////////////////////////////////////////////////////////////
//  SpecialCharacterReader.cs -    Converts escape sequences into single character         //
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

namespace Project1TestHarness {
  class SpecialCharacterReader {

    //Converts esacpe sequences into single character
    public string Special(char current, char next){
      char[] Special = { 'a', 'b', 'f', 'n', 'r', 't', 'v', '\'', '\"', '?','\\' };
      if(current.ToString() == "\\"){
        foreach (char escape in Special){
          if (next == escape){
            string specialseq = current.ToString() + next.ToString();
            return specialseq;
          }
        }
      }
      return null;
    }
  }
}

