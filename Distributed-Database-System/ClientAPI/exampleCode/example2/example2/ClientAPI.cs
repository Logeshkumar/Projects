using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example2
{
  class ClientAPI
  {
    private MockRootServer m_RootServer;


    public ClientAPI()
    {
      m_RootServer = new MockRootServer();
    }

    public ResultSet ExecuteQuery(string query)
    {
      Callback callback = new Callback();
      int len;
      int id = m_RootServer.ExecuteQuery(query, out len);
      ResultSet ret = new ResultSet(callback, id, m_RootServer, len);
      return ret;
    }
  }
}
