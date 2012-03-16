using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace example2
{
  class ResultSet
  {
    private Callback callback;
    private int id;
    private MockRootServer m_RootServer;

    private int len;
    private int m_TotalIndex;
    private List<string> m_CurrList;
    private int m_CurrIndex;
    private volatile bool m_Callbackcalled;

    public ResultSet(Callback callback, int id, MockRootServer m_RootServer, int len)
    {
      this.callback = callback;
      this.id = id;
      this.len = len;
      this.m_RootServer = m_RootServer;
      m_TotalIndex = 0;
      callback.registerDelegate(new Callback.RecieveDelegate(delegateReciever));
    }

    public bool hasNext()
    {
      if (m_CurrList == null)
      {
        read();
      }
      if (m_CurrIndex >= m_CurrList.Count)
      {
        read();
      }
      if (m_TotalIndex < len)
      {
        return true;
      }
      return false;
    }

    private void read()
    {
      m_Callbackcalled = false;
      m_RootServer.GetSomeRows(id, m_TotalIndex, 2, callback);
      //note you can use a interrupt here
      while (m_Callbackcalled == false)
      {
        Thread.Sleep(20);
      }
    }

    private void delegateReciever(List<string> lst)
    {
      m_CurrIndex = 0;
      m_CurrList = lst;
      m_Callbackcalled = true;
    }

    public string getString()
    {
      string ret = m_CurrList[m_CurrIndex];
      //this needs to be more complicated so you can call getString twice and get the same value
      m_CurrIndex++;
      m_TotalIndex++;
      return ret;
    }
  }
}
