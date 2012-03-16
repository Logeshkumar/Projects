using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Web;

namespace RESTServiceDemo
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RESTServiceImpl" in code, svc and config file together.
  public class RESTMatchService : IRESTMatchService
  {
    private static int counter;
    private static string _filePath = AppDomain.CurrentDomain.BaseDirectory + "matchDetails.xml";
    private static List<XElement> _matchDetails;

    private void LoadStoredMatches()
    {
      _matchDetails = new List<XElement>();
      XDocument data = XDocument.Load(_filePath);
      counter = int.Parse(data.Root.Attribute("counter").Value);
      var matches = from q in data.Descendants("Match") select q;
      foreach (var match in matches)
        _matchDetails.Add(match);
    }

    public RESTMatchService()
    {
      LoadStoredMatches();
    }

    public string CreateMatch(MatchData data)
    {
      string ret = "{";
      try
      {
        FileStream file = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        XDocument xDoc = XDocument.Load(file);
        counter++;
        string id = counter.ToString();
        XElement newMatch = new XElement("Match");
        newMatch.SetAttributeValue("id",id);
        XElement xHome = new XElement("Home", data.Home);
        XElement xAway = new XElement("Away", data.Away);
        XElement xScore = new XElement("Score", data.Score);
        newMatch.Add(new object[] { xHome, xAway, xScore });
        xDoc.Root.Attribute("counter").Value = id;
        xDoc.Root.Add(newMatch);
        file.SetLength(0);
        file.Flush();
        xDoc.Save(file);
        file.Flush();
        file.Close();
        ret += "\"success\":\"match " + id + " created\"";
        ret += ",\"match_url\":\"" + OperationContext.Current.EndpointDispatcher.EndpointAddress.Uri.AbsoluteUri + "/Match/" + id + "\"}";
      }
      catch (Exception ex)
      {
        ret += "\"error\":\""+ex.Message+"\"}";
      }
      return ret;
    }

    public string GetMatchDetail(string id)
    {
      string ret = "{";
      bool matchFound = false;
      foreach (var match in _matchDetails)
        if (match.Attribute("id").Value.Equals(id))
        {
          matchFound = true;
          ret += "\"success\":\"get match " + id + " succeeded\"";
          ret += ",\"home\":\"" + match.Element("Home").Value + "\"";
          ret += ",\"away\":\"" + match.Element("Away").Value + "\"";
          ret += ",\"score\":\"" + match.Element("Score").Value + "\"}";
          break;
        }
      if (!matchFound)
        ret += "\"error\":\"match not found\"}";
      return ret;
    }

    public string IsAdmin(string token)
    {
        string ret = "{";
        ret += "\"success\":\"get match " + "11" + " succeeded\"";
        ret += ",\"home\":\"" + "AdminHome" + "\"";
        ret += ",\"away\":\"" + "AdminAway" + "\"";
        ret += ",\"score\":\"" + "100:100" + "\"}";
        return ret;
    }

    public string UpdateMatch(string id, MatchData data)
    {
      string ret = "{";
      XElement foundMatch = null;
      foreach (var match in _matchDetails)
        if (match.Attribute("id").Value.Equals(id))
        {
          foundMatch = match;
          break;
        }
      if (foundMatch!=null)
      {
        XElement newMatch = new XElement("Match");
        newMatch.SetAttributeValue("id", id);
        XElement home = new XElement("Home", data.Home);
        XElement away = new XElement("Away", data.Away);
        XElement score = new XElement("Score", data.Score);
        newMatch.Add(new object[] { home, away, score });
        try
        {
          FileStream file = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          XDocument xDoc = XDocument.Load(file);
          var target = from q in xDoc.Descendants("Match") where q.Attribute("id").Value.Equals(id) select q;
          target.First().ReplaceWith(newMatch);
          file.SetLength(0);
          file.Flush();
          xDoc.Save(file);
          file.Flush();
          file.Close();
          _matchDetails[_matchDetails.IndexOf(foundMatch)] = newMatch;
          ret += "\"home\":\"" + newMatch.Element("Home").Value + "\"";
          ret += ",\"away\":\"" + newMatch.Element("Away").Value + "\"";
          ret += ",\"score\":\"" + newMatch.Element("Score").Value + "\"";
          ret += ",\"success\":\"match " + id + " updated\"}";
        }
        catch (Exception ex)
        {
          ret += "\"error\":\"" + ex.Message + "\"}";
        }
      }
      else
        ret += "\"error\":\"match not found\"}";
      return ret;
    }

    public string DeleteMatch(string id)
    {
      string ret = "{";
      XElement FoundMatch = null;
      foreach (var match in _matchDetails)
        if (match.Attribute("id").Value.Equals(id))
        {
          FoundMatch = match;
          break;
        }
      if (FoundMatch!=null)
      {
        try
        {
          FileStream file = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
          XDocument xDoc = XDocument.Load(file);
          var target = from q in xDoc.Descendants("Match") where q.Attribute("id").Value.Equals(id) select q;
          target.Remove();
          file.SetLength(0);
          file.Flush();
          xDoc.Save(file);
          file.Flush();
          file.Close();
          _matchDetails.Remove(FoundMatch);
          ret += "\"success\":\"match " + id + " removed\"}";
        }
        catch (Exception ex)
        {
          ret += "\"error\":\"" + ex.Message + "\"}";
        }
      }
      else
        ret += "\"error\":\"match not found\"}";
      return ret;
    }
  }
}
