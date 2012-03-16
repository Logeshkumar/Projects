using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Xml;
using System.IO;

namespace DIDemo
{

  public interface ICallback
  {
    [OperationContract]
    bool PutBack(string dumb);
  }

  [ServiceContract(CallbackContract=typeof(ICallback))]
  public interface IService
  {
    [OperationContract]
    string GetWord(string dumb);
  }

  [ServiceContract]
  public interface IOneWayService
  {
    [OperationContract]
    string GetWord(string dumb);
  }
}
