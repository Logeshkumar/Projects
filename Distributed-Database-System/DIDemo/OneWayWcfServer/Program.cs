using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DIDemo
{
  public class OneWayWcfService : IOneWayService
  {
    public string GetWord(string dumb)
    {
      Console.WriteLine("Request received");
      return "echo from one way server";
    }

    static void Main(string[] args)
    {
      string url = "http://localhost:8080/DIDemoOneWay";
      WSHttpBinding binding = new WSHttpBinding();
      Uri baseAddress = new Uri(url);
      Type service = typeof(OneWayWcfService);
      ServiceHost host = new ServiceHost(service, baseAddress);
      host.AddServiceEndpoint(typeof(IOneWayService), binding, baseAddress);

      host.Open();
      Console.WriteLine("Server started");

      Console.ReadKey();
      host.Close();
    }
  }
}
