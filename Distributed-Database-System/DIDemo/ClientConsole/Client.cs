using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
//using edu.syr.cse784.eskimodb;



namespace DIDemo
{
  public class Client : ICallback
  {
    public bool PutBack(string dumb)
    {
      Console.WriteLine(dumb);
      return true;
    }

    static void Main(string[] args)
    {
      string configPath = args[0];
      DependencyInjection di = DependencyInjection.GetInstance();
      di.SetConfig(configPath);
      {
        Client client = new Client();
        WcfInfo info = new WcfInfo();
        info.CallbackRef = client;
        info.Binding = new WSDualHttpBinding(WSDualHttpSecurityMode.Message);
        info.EndpointUri = "http://localhost:8080/DIDemo";
        
        IService server = (IService)di.CreateObject("myService", new object[]{client,"http://localhost:8080/DIDemo"});
        Console.WriteLine(server.GetWord("hello"));
        Console.ReadKey();
      }
    }
  }
}
