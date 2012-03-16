/*
 * RootServerHost.cs
 * This module is responsible for hosting the rootserver wcf service.
 * 
 * @Author: Satyajeet N Desale
 * @Date: 11/3/2011
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 11/3/2011 - first release.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class RootServerHost
  {
    /*
     * private static function to create channel for hosting root server. 
     * @param url specifies the url on which the rootserver is to be hosted.
     * @returns ServiceHost is returned 
     */
    static ServiceHost CreateChannel(string url)
    {
      WSDualHttpBinding binding = new WSDualHttpBinding();
      Uri address = new Uri(url);
      Type service = typeof(RootServer);
      ServiceHost rootHost = new ServiceHost(service, address);
      rootHost.AddServiceEndpoint(typeof(IRootServer), binding, address);
      return rootHost;
    }

    static void Main(string[] args)
    {
      Console.Write("\n Starting service...");

      ServiceHost rootHost = null;
      try
      {
        rootHost = CreateChannel("http://localhost:8080/RootServer");
        rootHost.Open();
        Console.Write("\n Started Root server service. Press a key to exit:\n");
        Console.ReadKey();
      }
      catch (Exception ex)
      {
        Console.Write("\n\n {0} \n\n", ex.Message);
      }
      finally
      {
        rootHost.Close();
      }
    }
  }
}
