using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.servicehostcreator
{
  public class TestProgram
  {
    public static void Main(string[] args)
    {
      string url = "http://localhost:8080/testserver";
      if (args.Length>0 && args[0] == "server")
      {
         
        ServiceHost host = ServiceHostCreator.CreateServiceHost(
                              url,
                              new TestServer(), //service object
                              new string[] {"/single","/dual"},  //service addresses
                              new Type[] { typeof(ITestService), typeof(IDualTestService) },  //service contracts
                              new bool[] { false, true });  //whether contracts have callbacks
        host.Open();
        Console.WriteLine("Server** server started");
      }
      else
      {
        TestDriver driver = new TestDriver();
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
