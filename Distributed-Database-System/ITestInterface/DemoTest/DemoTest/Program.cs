using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITestInterface;

namespace DemoTest
{
  public class BTest : ITest
  {
    private List<string> m_Msg;
    public bool Test()
    {

      m_Msg = new List<string>();
      Message m1 = new Message();
      m1.Msg = " Dummy Test 4";
      m1.TestID = 3;
      m1.Passed = true;
      string m_string1 = m1.ToString();
      Message m2 = new Message();
      m2.Msg = " Dummy Test 5";
      m2.TestID = 4;
      m2.Passed = false;
      string m_string2 = m2.ToString();
      List<Message> test = new List<Message>();
      m_Msg.Add(m_string1);
      m_Msg.Add(m_string2);
      return true;
    }

    public List<string> GetMessage()
    {
      return m_Msg;
    }

    public List<string> ConvertFromMessageToString()
    {
      List<string> ret = new List<string>();
      //foreach (Message m in m_Msg)
      //{
      //  string currmsg = "<node>";
      //  currmsg += "<Msg>" + m.Msg + "</Msg>";
      //  currmsg += "<TestID>" + m.TestID.ToString() + "</TestID>";
      //  currmsg += "<Passed>" + m.Passed.ToString() + "</Passed>";
      //  currmsg += "</node>";
      //  ret.Add(currmsg);

      //}
      return ret;
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      BTest tst = new BTest();
      List<string> displaystring = null;
      tst.Test();
      displaystring = tst.GetMessage();
      foreach (string s in displaystring)
        Console.WriteLine(s);
    }
  }
}
