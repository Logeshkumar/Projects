using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.testinterface;
using edu.syr.cse784.eskimodb.executor;
using edu.syr.cse784.eskimodb.rootserver;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver.Test
{
  class RootServerTestDriver : ITest
  {
    private List<Message> m_Messages;
    private string m_Url;
    private depinject.DependencyInjection m_DI;

    public RootServerTestDriver()
    {
      m_Messages = new List<Message>();
      m_Url = "http://localhost:8080/RootServer";
      m_DI = depinject.DependencyInjection.GetInstance();
    }

    public bool CreateRootServerHost()
    {
      bool ret = Executor.Execute(@"RootServer.exe", new string[] { "rootserver" });
      string msg = ret ? "Success in starting rootserver." : "Failed to start rootserver";
      m_Messages.Add(new Message() { TestID = 1, Msg = msg, Passed = ret });
      return ret;
    }

    private bool RootServerTest()
    {
      IRootServerCallback callback = new MockRootServerCallback();
      IRootServer rootServer = (IRootServer)m_DI.CreateObject("rootserver test",
                                                              new object[]{
                                                              callback, 
                                                              m_Url
                                                              });
      if (rootServer == null)
        return false;
      rootServer.configureRootServer("http://localhost:8081/MockAuthServer", "http://localhost:8083/MockTableServer");
      QueryResult qr = rootServer.ExecQuery("create db tempname;", "xxxx");
      m_Messages.Add(new Message() { TestID = 2, Msg = qr.GetMessage(), Passed = true });
      return true;
    }

    public List<string> GetMessage()
    {
      List<String> ret = new List<string>();
      foreach (var msg in m_Messages)
        ret.Add(msg.ToString());
      return ret;  
    }

    public bool Test()
    {
      depinject.DependencyInjection di = depinject.DependencyInjection.GetInstance();
      di.SetConfig("config.xml");
      bool ret = true, ret1 = true;
      if (!CreateRootServerHost())
        ret = false;
      if (!RootServerTest())
        ret1 = false;
      return ret && ret1;
    }
  }
}
