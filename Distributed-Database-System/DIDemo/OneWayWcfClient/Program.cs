using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DIDemo
{
  public class OneWayClient
  {

    static void Main(string[] args)
    {
      string configPath = args[0];
      DependencyInjection di = DependencyInjection.GetInstance();
      di.SetConfig(configPath);
      {
        OneWayClient client = new OneWayClient();

        IOneWayService server = (IOneWayService)di.CreateObject("myService", new object[]{
                              null,"http://localhost:8080/DIDemoOneWay"});
        Console.WriteLine(server.GetWord("hello from one way client"));
        Console.ReadKey();
      }
    }
  }
}

