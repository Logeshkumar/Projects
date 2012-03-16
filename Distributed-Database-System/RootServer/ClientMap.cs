/*
 * ClientMap.cs
 * This module is responsible for maintaining the current clients and the their associated
 * database in use per session.
 * 
 */
/*
 * Dependent files
 * ======================
 * ClientMap.cs
 * 
 * Maintanence
 * ======================
 * 11/15/2011 - first release.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class ClientMap
  {
    Dictionary<string, KeyValuePair<string, DateTime>> m_ClientMap;

    public ClientMap()
    {
      m_ClientMap = new Dictionary<string, KeyValuePair<string, DateTime>>();
    }

    public bool GetDatabaseName(string token, out string databaseName)
    {
      cleanDictionary();
      databaseName = m_ClientMap[token].Key;
      if (databaseName != null)
        return true;
      return false;
    }

    public void setClientDatabase(string token, string dbname)
    {
      KeyValuePair<string, DateTime> valuePair = new KeyValuePair<string, DateTime>(dbname, DateTime.Now);
      m_ClientMap.Add(token, valuePair);
    }

    private void cleanDictionary()
    {
      foreach (KeyValuePair<string, KeyValuePair<string, DateTime>> entry in m_ClientMap)
      {
        TimeSpan timeOutSpan = new TimeSpan(0, 20, 0);
        TimeSpan diff = DateTime.Now.Subtract(entry.Value.Value);
        if ((TimeSpan.Compare(timeOutSpan, diff)) == -1)
        {
          m_ClientMap.Remove(entry.Key);        
        }
      }
    }

  }
}
