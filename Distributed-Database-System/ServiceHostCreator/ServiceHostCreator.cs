using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.servicehostcreator
{
  public class ServiceHostCreator
  {
    public static ServiceHost CreateServiceHost(Object serviceObj, string url, Type serviceType, bool hasCallback = false)
    {
      return CreateServiceHost(url, serviceObj, new string[] { url }, new Type[] { serviceType }, new bool[] { hasCallback });
    }

    public static ServiceHost CreateServiceHost(string baseAddr, Object serviceObj, string[] endpointAddrs, Type[] serviceTypes, bool[] haveCallbacks)
    {
      ServiceHost ret = null;
      ret = new ServiceHost(serviceObj, new Uri(baseAddr));
      for (int i = 0;i<serviceTypes.Length;i++)
      {
        System.ServiceModel.Channels.Binding binding;
        if (haveCallbacks[i])
          binding = new WSDualHttpBinding();
        else
          binding = new WSHttpBinding();
        ret.AddServiceEndpoint(serviceTypes[i], binding, baseAddr+endpointAddrs[i]);
      }
      return ret;
    }
  }
}
