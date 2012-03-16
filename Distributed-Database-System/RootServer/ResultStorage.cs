/*
 * ResultStorage.cs
 * Intermediate root server result storage for the results returned by the table servers.
 * 
 */
/*
 * Dependent files
 * ======================
 * ResultStorage.cs
 * 
 * Maintanence
 * ======================
 * 12/01/2011 - first release.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class ResultStorage
  {
    private static ResultStorage m_Instance;

    private Dictionary<string, QueryDataset> m_ResultCache;

    private ResultStorage()
    {
      m_ResultCache = new Dictionary<string, QueryDataset>();
    }

    public static ResultStorage Instance
    {
      get 
      {
        if (m_Instance == null)
        {
          m_Instance = new ResultStorage();
        }
        return m_Instance;
      }
    }

    public bool AddResultEntry(string id, QueryDataset queryDataSet)
    {
      try
      {
        m_ResultCache.Add(id, queryDataSet);
      }
      catch
      {
        return false;
      }
      return true;
    }

    public QueryDataset GetQueryResult(string id)
    {
      QueryDataset queryDataset = null;
      if (id == "")
        throw new Exception("Empty ID");
      if (m_ResultCache.ContainsKey(id))
      {
        queryDataset = m_ResultCache[id];
      }
      return queryDataset;
    }

    public QueryDataset GetQueryResult(string id, int startLines, int numLines)
    {
      int i = 1, k = numLines;
      QueryDataset queryDataset = null, ret = null;
      
      if (id == "")
        throw new Exception("Empty ID");
      if (m_ResultCache.ContainsKey(id))
      {
        queryDataset = m_ResultCache[id];
      }
      
      ret = new QueryDataset(queryDataset.GetColumnTypes(), queryDataset.GetColumnNames());

      if (startLines < queryDataset.count)
      {
        foreach(var row in queryDataset)
        {
          if ((i == startLines) && (k > 0))
          {
            ret.AddRow(row.Key, row.Value);
            k--;
          }
          if (k == 0)
            break;
          i++;
        }
      }
      return ret;
    }


  }
}
