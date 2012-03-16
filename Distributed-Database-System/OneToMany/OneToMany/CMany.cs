using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OneToMany
{
  public class CMany : IMany
  {
    private IOne m_Callback;
    private int m_Id;

    public CMany(int id,IOne callbackRef)
    {
      m_Callback = callbackRef;
    }

    public void DoSomething(string msg)
    {
      Console.WriteLine("Do something : In server " + m_Id + " : " + msg + " received.");
      Thread.Sleep(new Random().Next(1000, 3000));
      Console.WriteLine("Processing completed");
      m_Callback.SetResponce("echo from server " + m_Id);
    }

    public void DoOtherthing(string msg)
    {
      Console.WriteLine("Do other thing : In server " + m_Id + " : " + msg + " received.");
      Thread.Sleep(new Random().Next(1000, 3000));
      Console.WriteLine("Processing completed");
      m_Callback.SetResponce("echo from server " + m_Id);
    }
  }
}