using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.usedidemo
{
  public class AExample : IExample
  {
    private ICallback m_Callback;

    public AExample(object callback, object dumb1, object dumb2)
    {
      m_Callback = (ICallback)callback;
    }

    public string Say(string word)
    {
      string ret = "client type is" + m_Callback.func() +"\n";
      ret += "AExample says " + word;
      return ret;
    }
  }
}
