////////////////////////////////////////////////////////////////////////////////
// Case07.cs - Test case for CSE784 Project1                                  //
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
  public class Case07
  {

    public Case07()
    {
    }

    public void print()
    {
      Console.WriteLine(this.process(20));
    }

    public int process(int value){
      if(value != 2 && value != 3){
        value -= 20;
        value += 30;
        value *= 10;
        value /= 10;
        value %= 10;
        value &= 10;
        value ^= 10;
        value |= 10;
        return value;
      } else if(value < 20 || value >= 10){
        value = value - 10;
        value = value + 10;
        value = value % 10;
        value = value * 10;
        value = value & 10;
        value = value / 10;
       
      } else if(value == 100){
        return 10;
      }
    }
  }
}
