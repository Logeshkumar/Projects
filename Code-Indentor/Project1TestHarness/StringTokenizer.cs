/////////////////////////////////////////////////////////////////////////////////////////////
//  StringTokenizer.cs -           Organizes group of character into string                //
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
  class StringTokenizer {
    char next = '\0';
    char current;

    // groups the characters into string for a given element 
    // or a line in the file
    public void stringtok(CharEnumerator c){
      string s = null;
      SpecialCharacterReader Scr = new SpecialCharacterReader();
      Storage cont = new Storage();
      while(c.MoveNext()){
        CharEnumerator Cnum2 = (CharEnumerator)c.Clone();
        current = c.Current;
        if(Cnum2.MoveNext()){
          next = Cnum2.Current;
          string sp = Scr.Special(current, next);
          if(sp != null){
            s += sp;
            c.MoveNext();
          } else {
            s += c.Current.ToString();
          }
        }
      }
      if(next == '\0'){
        s += current.ToString();
          if(s != "\0")
          cont.setContainer1(s);
      } else {
        s += next.ToString();
        if(s != "\0")
        cont.setContainer1(s);
      }
    }
  }
}
