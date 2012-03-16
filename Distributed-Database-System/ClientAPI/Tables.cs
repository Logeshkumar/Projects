////////////////////////////////////////////////////////////////////////////////
// ClientAPI.cs - Helper functions for tables manipulations                   //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Authors:                                                                   //
//                Hao Shen (  hshen01@syr.edu ),Anjali Banka (abanka@syr.edu) // 
//                Fall 2011, Syracuse University                              //
////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;

namespace edu.syr.eskimodb.clientapi
{
  class Tables
  {
    private List<List<string>> m_DataTable;

    public Tables()
    {
      m_DataTable = new List<List<string>>();
    }

    public void PutRowInTable(List<string> item)
    {
      m_DataTable.Add(item);
    }

    public List<string> GetRowFromTable(int index)
    {
      return m_DataTable[index];
    }

    public int GetNoOfRows()
    {
      return m_DataTable.Count;
    }

    public void ClearTable()
    {
      m_DataTable.Clear();
    }
  }
}
