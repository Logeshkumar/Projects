using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.testinterface;
using edu.syr.cse784.eskimodb.executor;

namespace edu.syr.cse784.eskimodb.servicehostcreator
{
  class TestDriver : ITest
  {
    private List<Message> m_Msgs;
    private string m_Url;
    private depinject.DependencyInjection m_Di;

    public TestDriver()
    {
      m_Msgs = new List<Message>();
      m_Url = "http://localhost:8080/testserver";
      m_Di = depinject.DependencyInjection.GetInstance();
    }

    private bool TestCreateHost()
    {
      //startup server here
      bool ret = Executor.Execute(@"ServiceHostCreator.exe", new string[] { "server" });
      string msg = ret?"start server succeed":"start server fail";
      m_Msgs.Add(new Message() { TestID = 1, Msg = msg, Passed = ret });
      return ret;
    }

    private bool TestDualServer()
    {
      TestClient client = new TestClient();
      IDualTestService dualserv = (IDualTestService)m_Di.CreateObject(
                                    "dual test server",
                                    new object[]{
                                        client, //callback reference
                                        m_Url+"/dual" //service address
                                      });
      if (dualserv == null)
        return false;
      string msg = dualserv.SayAndEcho("hello from client");
      m_Msgs.Add(new Message() { TestID = 2, Msg = msg, Passed = true });
      return true;
    }

    private bool TestSingleServer()
    {
      ITestService singleserv = (ITestService)m_Di.CreateObject(
                                "single test server",
                                new object[]{
                                    null,
                                    m_Url+"/single"
                                  });
      if(singleserv == null)
        return false;
      string msg = singleserv.Say("hello from client");
      m_Msgs.Add(new Message() { TestID = 3, Msg = msg, Passed = true });
      return true;
    }

    public List<String> GetMessage()
    {
      List<String> ret = new List<string>();
      foreach(var msg in m_Msgs)
        ret.Add(msg.ToString());
      return ret;
    }

    public bool Test()
    {
      //setup DI
      depinject.DependencyInjection di = depinject.DependencyInjection.GetInstance();
      di.SetConfig("config.xml");
      bool ret = true;
      ret = TestCreateHost() && ret;
      ret = TestSingleServer() && ret;
      ret = TestDualServer() && ret;
      return ret;
    }
  }
}
