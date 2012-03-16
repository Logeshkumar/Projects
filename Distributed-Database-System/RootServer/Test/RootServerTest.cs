using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using edu.syr.cse784.eskimodb.servicehostcreator;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver.Test
{
  class RootServerTest
  {
    public static void Main(string[] args)
    {
      string url = "http://localhost:8080/RootServer";
      if (args.Length > 0 && args[0] == "rootserver")
      {
        depinject.DependencyInjection di = depinject.DependencyInjection.GetInstance();
        di.SetConfig("config.xml");
        ServiceHost host = ServiceHostCreator.CreateServiceHost(
                              url,
                              new RootServer(),
                              new string[] { "" },
                              new Type[] { typeof(IRootServer) },
                              new bool[] { true });
        host.Open();
        Console.WriteLine("Root Server started.");
      }
      else
      {
        RootServerTestDriver driver = new RootServerTestDriver();
        if (driver.Test())
        {
          Console.WriteLine("test passed");
        }
        else
        {
          Console.WriteLine("test failed");
        }
        List<string> msgs = driver.GetMessage();
        foreach (var msg in msgs)
          Console.WriteLine(msg);
      }
      Console.ReadKey();
    }
  }
}
