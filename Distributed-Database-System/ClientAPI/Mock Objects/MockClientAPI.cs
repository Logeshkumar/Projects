////////////////////////////////////////////////////////////////////////////////
// MockClientAPI.cs - Module to mock the Client API Functionality             //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:                                                                    //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.ServiceModel;
using System.Threading;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.clientapi
{
  public class MockClientAPI
  {
    static IRootServer createProxy(string url)
    {
      WSDualHttpBinding binding = new WSDualHttpBinding();
      EndpointAddress address = new EndpointAddress(url);
      IRootServerCallback callBack = new MockCallBackHandler();
      InstanceContext instanceContext = new InstanceContext(callBack);
      DuplexChannelFactory<IRootServer> factory = new DuplexChannelFactory<IRootServer>(instanceContext, binding, address);
      return factory.CreateChannel();
    }

    bool ExecQuery(IRootServer svc)
    {
      string query = "create db dbname;", token = "demo auth token";
      QueryResult queryResult = svc.ExecQuery(query, token);
      if (queryResult != null)
        return true;
      return false;
    }

    bool getResult(IRootServer svc)
    {
      string id = "demoID", token = "demo auth token";
      int startLine = 1, numberOfLines = 10;
      QueryResult queryResult = svc.GetResult(id, startLine, numberOfLines, token);
      if (queryResult != null)
        return true;
      return false;
    }

    bool Release(IRootServer svc)
    {
      string id = "demoID", token = "demo auth token";
      QueryResult queryResult = svc.Release(id, token);
      if (queryResult != null)
        return true;
      return false;
    }


    static void Main(string[] args)
    {
      Console.Write("\n Starting mock client API ...");

      string url = "http://localhost:8080/RootServer";
      IRootServer svc = null;
      int count = 0;
      while (true)
      {
        try
        {
          svc = createProxy(url);
          break;
        }
        catch
        {
          Console.Write("\n connection to service failed {0} times - trying again", ++count);
          Thread.Sleep(100);
          continue;
        }
      }
      MockClientAPI mcapi = new MockClientAPI();
      if (mcapi.ExecQuery(svc))
        Console.WriteLine("Exec query successful...");
      if (mcapi.getResult(svc))
        Console.WriteLine("Get result successful...");
      if (mcapi.Release(svc))
        Console.WriteLine("Get result successful...");
    }

  }

  public class MockCallBackHandler : IRootServerCallback
  {
    public void PutDataset(QueryResult result, string id, QueryDataset data)
    {
      Console.WriteLine("IRootServerCallback - Put dataset called ");
    }

    public void PutQueryInfo(QueryResult result, string id, long lines)
    {
      Console.WriteLine("IRootServerCallback - put query info");
    }

  }
}
