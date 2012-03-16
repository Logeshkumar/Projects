/*
 * QueryDataset.cs
 * Return dataset type when a query is executed.
 * 
 * @author Yiou LI
 * @date 10/13/2011
 */
/*
 * Public Interface
 * =======================
 * QueryDataset set = new QueryDataset(colTypes,colNames);
 * set.AddRow(rowIndex,row);
 * foreach(var row in set){
 *   int rowIndex = row.Key;
 *   foreach(var field in row.Value)
 *   ...
 * }
 */
/*
 * Depend files
 * =======================
 * None
 * 
 * Maintenance
 * =======================
 * 10/13/2011 - First release.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  [DataContract]
  public class QueryDataset : IEnumerable
  {
    /*
     * DatasetEnum is the enumerator for QueryDataset
     */
    public class DatasetEnum : IEnumerator
    {
      public Dictionary<int,List<object>> m_Data;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
      int position = -1;

      public DatasetEnum(Dictionary<int, List<object>> data)
      {
        m_Data = data;
      }

      public bool MoveNext()
      {
        position++;
        return (position < m_Data.Count);
      }

      public void Reset()
      {
        position = -1;
      }

      public int count
      {
        get { return m_Data.Count; }
      }

      object IEnumerator.Current
      {
        get
        {
          return Current;
        }
      }

      public KeyValuePair<int, List<object>> Current
      {
        get
        {
          try
          {
            return new KeyValuePair<int,List<object>>(m_Data.ElementAt(position).Key,new List<object>(m_Data.ElementAt(position).Value));
          }
          catch (ArgumentOutOfRangeException)
          {
            throw new InvalidOperationException();
          }
        }
      }
    }

    [DataMember]
    private List<Type> m_ColTypes;

    [DataMember]
    private List<string> m_ColNames;

    [DataMember]
    private Dictionary<int, List<object>> m_DataTable;

    /*
     * QueryDataset(colTypes,colNames) is the constructor for QueryDataset.
     * column type count and column name count must be the same.
     * @param colTypes is the list of column types.
     * @param colNames is the list of column names.
     * @throws exception when column name count and column type count is deferent.
     */
    public QueryDataset(List<Type> colTypes, List<string> colNames)
    {
      if (colTypes.Count != colNames.Count)
        throw new Exception("Column type count and column name count not the same");
      m_ColTypes = colTypes;
      m_ColNames = colNames;
      m_DataTable = new Dictionary<int,List<object>>();
    }

    /*
     * AddRow(rowIndex,row) add a row in the dataset.
     * @param rowIndex is the row index of the row.
     * @param row is the content of the row.
     * @throws exception when the field count in the row doesn't
     *         match the column count or the row index already in the dataset.
     */
    public void AddRow(int rowIndex, List<object> row)
    {
      if (row.Count != m_ColTypes.Count)
        throw new Exception("Fields count doesn't match column count");
      if (m_DataTable.ContainsKey(rowIndex))
        throw new Exception("duplicated rows in dataset");
      m_DataTable.Add(rowIndex, new List<object>(row));
    }

   public List<string> GetColumnNames()
    {
      return new List<string>(m_ColNames);
    }

   public List<Type> GetColumnTypes()
   {
     return new List<Type>(m_ColTypes);
   }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator)GetEnumerator();
    }

    public DatasetEnum GetEnumerator()
    {
      return new DatasetEnum(m_DataTable);
    }

    public int count
    {
      get { return m_DataTable.Count; }
    }

    //----< test stub >-------------
    static void Main()
    {
      List<Type> colTypes = new List<Type>(new Type[]{typeof(int),typeof(string),typeof(DateTime)});
      List<string> colNames = new List<string>(new string[]{"GroupId","Name","JoinDate"});
      QueryDataset table = new QueryDataset(colTypes,colNames);
      List<object> entry = new List<object>();
      entry.Add(1);
      entry.Add("David");
      entry.Add(new DateTime(2010,6,3));
      table.AddRow(1, entry);
      entry.Clear();
      entry.Add(3);
      entry.Add("Mary");
      entry.Add(new DateTime(2011, 10, 12));
      table.AddRow(2, entry);
      foreach (var name in table.GetColumnNames())
        Console.Write(name + "  ");
      Console.WriteLine();
      foreach (var row in table)
      {
        foreach (var field in row.Value)
          Console.Write(field + "  ");
        Console.WriteLine();
      }
      Console.ReadKey();
    }
  }
}