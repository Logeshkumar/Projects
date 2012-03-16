/////////////////////////////////////////////////////////////////////////////////////////////
//  CommentTokenizer.cs -          Removes the comments from the code inputted             //
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
  class CommentTokenizer {
    string s = null;

    // Removes the comments from the input code
    public string CommentRemover(CharEnumerator c){
      int flag = 0;
      while(c.MoveNext()){
        CharEnumerator Cnum2 = (CharEnumerator)c.Clone();
        char current = c.Current;
        char next;
        if(Cnum2.MoveNext()){
          next = Cnum2.Current;
          if(current.ToString() == "\"" && next.ToString() == "/"){
            flag = 1;
          }
          if((current.ToString() == "/" && next.ToString() == "/") || (current.ToString() == "/" && next.ToString() == "*") && flag == 0){
            while (c.MoveNext()){
              s += c.Current.ToString();
            }
            if (s == null){
              return null;
            }
          }
        }
      }
      return s;
    }
  }
}
