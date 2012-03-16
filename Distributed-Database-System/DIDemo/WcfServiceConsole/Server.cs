using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DIDemo
{
  public class WcfService : IService
  {
    public string GetWord(string dumb)
    {
      Console.WriteLine("Request received");
      ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
      if (callback != null)
        Console.WriteLine("Can get callback channel");
      return "echo from real server";
    }

    static void Main(string[] args)
    {
      string url = "http://localhost:8080/DIDemo";
      WSDualHttpSecurityMode securityMode = WSDualHttpSecurityMode.Message;
      WSDualHttpBinding binding = new WSDualHttpBinding(securityMode);
      Uri baseAddress = new Uri(url);
      Type service = typeof(WcfService);
      ServiceHost host = new ServiceHost(service, baseAddress);
      host.AddServiceEndpoint(typeof(IService), binding, baseAddress);

      host.Open();
      Console.WriteLine("Server started");
      
      Console.ReadKey();
      host.Close();
    }
  }
}
