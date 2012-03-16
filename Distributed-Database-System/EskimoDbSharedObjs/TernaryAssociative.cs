using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  public class TernaryAssociative<T,U,V>
  {
    public TernaryAssociative()
    {}
    
    public TernaryAssociative(T first, U second, V third)
    {
      this.First = first;
      this.Second = second;
      this.Third = third;
    }

    public T First { get; set; }
    public U Second { get; set; }
    public V Third { get; set; }
  }
}
