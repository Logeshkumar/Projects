using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneToMany
{
  public class COne : IOne
  {
    public void SetResponce(string msg)
    {
      Console.WriteLine("Set responce : "+msg);
    }

    public bool AnotherCallback(string msg)
    {
      Console.WriteLine("Another callback : " + msg);
      return true;
    }
  }
}
