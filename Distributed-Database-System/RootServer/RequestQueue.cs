using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWTools;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class RequestQueue
  {
    private BlockingQueue<Request> m_RequestQueue = null;

    public RequestQueue()
    {
      m_RequestQueue = new BlockingQueue<Request>();
    }

    public void enQueueRequest(Request request)
    {
      m_RequestQueue.enQ(request);    
    }

    public Request deQueueRequest()
    {
      Request ret = m_RequestQueue.deQ();
      return ret;
    }

    public int size()
    {
      int ret = m_RequestQueue.size();
      return ret;
    }
  }
}
