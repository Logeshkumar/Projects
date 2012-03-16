using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.servicehostcreator
{
  [ServiceContract(CallbackContract = typeof(IDualTestCallback))]
  public interface IDualTestService
  {
    [OperationContract]
    string SayAndEcho(string msg);
  }

  public interface IDualTestCallback
  {
    [OperationContract]
    string Echo(string msg);
  }

  [ServiceContract]
  public interface ITestService
  {
    [OperationContract]
    string Say(string msg);
  }
}
