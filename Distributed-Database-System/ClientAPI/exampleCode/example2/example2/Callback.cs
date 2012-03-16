using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example2
{
  class Callback
  {
    public delegate void RecieveDelegate(List<string> lst);

    private RecieveDelegate the_delegate;

    public void registerDelegate(RecieveDelegate del)
    {
      the_delegate = del;    
    }

    public void recieve(List<string> lst)
    {
      the_delegate(lst);
    }
  }
}
