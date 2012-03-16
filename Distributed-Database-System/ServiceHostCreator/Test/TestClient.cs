using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.testinterface;

namespace edu.syr.cse784.eskimodb.servicehostcreator
{
  public class TestClient : IDualTestCallback
  {
    public string Echo(string msg)
    {
      return null;
    }
  }
}
