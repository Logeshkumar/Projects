using System.Collections.Generic;

namespace edu.syr.eskimodb.restapi
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
