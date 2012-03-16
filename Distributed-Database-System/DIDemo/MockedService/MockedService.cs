using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DIDemo
{
  public class MockedService : IService
  {
    private ICallback m_Callback;

    public MockedService()
    {
      Console.WriteLine("Empty constructor in mocked server called");
    }

    public MockedService(params object[] runtimeInfo)
    {
      m_Callback = (ICallback)runtimeInfo[0];
    }

    public string GetWord(string dumb)
    {
      m_Callback.PutBack("callback from mocked up");
      return "echo from mocked up";
    }
  }
}
