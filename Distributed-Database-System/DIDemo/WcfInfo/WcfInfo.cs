using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace DIDemo
{
  public class WcfInfo
  {
    //public InstanceContext Context { get; set; }
    //public System.ServiceModel.Channels.Binding Binding { get; set; }
    //public EndpointAddress Address { get; set; }
    public object CallbackRef { get; set; }
    public System.ServiceModel.Channels.Binding Binding { get; set; }
    public string EndpointUri { get; set; }

    public object[] ToObjects()
    {
      object[] ret = new object[3];
      ret[0] = CallbackRef;
      ret[1] = Binding;
      ret[2] = EndpointUri;
      return ret;
    }
    public static WcfInfo Parse(object[] info)
    {
      WcfInfo ret = new WcfInfo();
      ret.CallbackRef = info[0];
      ret.Binding = (System.ServiceModel.Channels.Binding)info[1];
      ret.EndpointUri = (string)info[2];
      return ret;
    }
  }
}