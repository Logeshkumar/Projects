using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace edu.syr.cse784.eskimodb.servicehostcreator
{
  [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
  public class TestServer : IDualTestService,ITestService
  {
    public string SayAndEcho(string msg)
    {
      Console.WriteLine("Server** msg received in dual server: " + msg);
      IDualTestCallback callback = OperationContext.Current.GetCallbackChannel<IDualTestCallback>();
      if (callback == null)
      {
        Console.WriteLine("Server** can't get callback channel");
        return "can't get callback";
      }
      return "dual comm success";
    }

    public string Say(string msg)
    {
      Console.WriteLine("Server** msg received in single server: " + msg);
      return "comm success";
    }
  }
}
