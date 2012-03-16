/////////////////////////////////////////////////////////////////////////////////////////////
//  Storage.cs -                   Stores the processed list and returns when asked.        //
//  Language:                      Visual C# 4.0      				                             //
//  Platform:                      Windows 7								                               //
//  Application:                   Code Indentor      			                               //
//  Author:                        logeshkumar								                             //
/////////////////////////////////////////////////////////////////////////////////////////////

/*
Maintainence History:
=====================
ver 1.0 03 October 2011
- first release
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1TestHarness {
  class Storage {
    static List<string> container1 = new List<string>();
    static List<string> container2 = new List<string>();
    
    //setter for container1
    public void setContainer1(string c){
      container1.Add(c);
    }

    //getter for container1
    public List<string> getContainer1(){
      return container1;
    }
   
    //setter for container2
    public void setContainer2(List<string> lis){
      container2 = lis;
    }

    //getter for container2
    public List<string> getContainer2(){
      return container2;
    }
    
    //clearing the data in container1
    public void clear1(){
      container1.Clear();
    }

    //clearing the data in container2
    public void clear3(){
      container2.Clear();
    }
  }
}
