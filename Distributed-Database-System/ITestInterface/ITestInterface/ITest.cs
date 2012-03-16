using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace edu.syr.cse784.eskimodb.testinterface
{
  public class Message 
  {
    public string Msg { get; set; }
    public int TestID { get; set; }
    public bool Passed { get; set; }
    public override string ToString()
    {
        string ret = "<node>";
        ret += "<Msg>" + Msg + "</Msg>";
        ret += "<TestID>" + TestID.ToString() + "</TestID>";
        ret += "<Passed>" + Passed.ToString() + "</Passed>";
        ret += "</node>";
      return ret;
    }

    public static Message Parse(string xmlMsg)
    {
      XElement xdoc = XElement.Parse(xmlMsg);
      Message ret = new Message();
      ret.Msg = xdoc.Element("Msg").Value;
      if (xdoc.Element("Passed").Value.ToString() == "True")
        ret.Passed = true;
      else
        ret.Passed = false;
      ret.TestID = Convert.ToInt32(xdoc.Element("TestID").Value.ToString());
      return ret;
    }
  }


  public interface ITest
  {
    bool Test();
    List<string> GetMessage();
    
  }
}
