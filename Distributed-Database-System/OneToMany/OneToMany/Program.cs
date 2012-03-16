using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OneToMany
{
  public class Communicator<TMsg,TOne,TMany> where TMany : new()
  {
    private Queue<TMsg> m_OutQ;
    private Queue<TMsg> m_InQ;
    private TOne m_OneRef;
    private List<Thread> m_Tout;
    private List<TMany> m_Servers;

    public Communicator(TOne oneRef)
    {
      m_OneRef = oneRef;
      m_OutQ = new Queue<TMsg>();
      m_InQ = new Queue<TMsg>();
      m_Tout = new List<Thread>();
      m_Servers = new List<TMany>();
      Thread tCheck = new Thread(new ThreadStart(LoadCheck));
      m_Tout.Add(new Thread(new ThreadStart(OutThreadProc))); //start 1 server by default
    }

    public virtual void MsgProc(TMany server, TMsg msg)
    {
      //do nothing
    }

    private void OutThreadProc()
    {
      TMany server = default(TMany); //CreateInstance here
      m_Servers.Add(server);
      while(true)
        MsgProc(server,m_OutQ.Dequeue());
    }

    private void LoadCheck()
    {
      if (m_OutQ.Count > 10)
      {
        Console.WriteLine("Starting new server");
        m_Tout.Add(new Thread(new ThreadStart(OutThreadProc)));
      }
    }

    static void Main(string[] args)
    {
    }
  }
}
