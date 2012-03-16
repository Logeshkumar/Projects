using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.ServiceModel;
using System.Reflection;

namespace DIDemo
{
  public class ServiceRefCreator
  {
    public static Object GetWcfReference(Type type, object[] info)
    {
      if (info.Length == 2)
        info = new object[] { info[0], null, info[1] };
      if (info.Length != 3)
        return null;
      Type genType;
      Type factType;
      if (info[0] == null)
      {
        genType = typeof(ChannelFactory<>);
        factType = genType.MakeGenericType(new Type[] { type });
        if (info[1] == null)
          info[1] = new WSHttpBinding();
        info = new object[] { info[1], new EndpointAddress((string)info[2]) };
      }
      else
      {
        genType = typeof(DuplexChannelFactory<>);
        factType = genType.MakeGenericType(new Type[] { type });
        info[0] = new InstanceContext(info[0]);
        info[2] = new EndpointAddress((string)info[2]);
        if (info[1] == null)
          info[1] = new WSDualHttpBinding();
      }
      object factObject = Activator.CreateInstance(factType, info);
      MethodInfo methodInfo = factType.GetMethod("CreateChannel", new Type[] { });
      return methodInfo.Invoke(factObject, null);
    }
  }
}
