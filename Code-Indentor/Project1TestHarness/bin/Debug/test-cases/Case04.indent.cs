using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.IO; 
namespace Project1TestCases {
  public class Case04 { 
    private int m_Variable1; 
    public Case01(){ 
      m_Variable1 = 10; 
    } 
    public void print(){ 
      for(int x = 0; x < 20; x += 2){ 
        Console.WriteLine(m_Variable1 + x); 
      } 
    } 
    private void longerFunction(){ 
      int x = 10; 
      if(x == 20){ 
        x += 10; 
      } else if(x > 30){
        if(x < 40){ 
          x = fun2(); 
          x -= 1; 
        } else {
          x = 2 * fun2(); 
        } 
      } else {
        x = 0; 
      } 
      Console.WriteLine(x); 
    } 
    private int fun2(){ 
      return 20; 
    } 
  } 
} 
