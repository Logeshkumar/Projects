using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.IO; 
namespace Project1TestCases {
  public class Case07 { 
    public Case07(){ 
    } 
    public void print(){ 
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
