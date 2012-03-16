using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class DbTable
  {
    public string m_TableName;
    public string m_UniqueKey;
    public List<KeyValuePair<string, string>> m_column = new List<KeyValuePair<string, string>>();

    public void settableName(string tablename)
    {
      this.m_TableName = tablename;

    }
    public void setUniqueKey(string UniqueKey)
    {
      this.m_UniqueKey = UniqueKey;
    }
    public void setColumnData(string columnName, string columnType)
    {
      
      m_column.Add(new KeyValuePair<string,string>(columnName, columnType));
      
    }
    public string getUniqueKey()
    {
      return m_UniqueKey;
    }
    public string getTableName()
    {
      return m_TableName;
    }
    public List<KeyValuePair<string, string>> getColumnData()
    {
      return m_column;
    }
  }
  class DataBase
  {
    KeyValuePair<string, List<DbTable>> database = new KeyValuePair<string, List<DbTable>>();

    public void setDb(string dbname, List<DbTable> tables)
    {
      this.database = new KeyValuePair<string, List<DbTable>>(dbname, tables);
    }

    public KeyValuePair<string, List<DbTable>> getDb()
    {
      return database;
    }

  }
  class DbList
  {
    List<DataBase> m_dbList = new List<DataBase>();

    public void AddDbToList(DataBase db)
    {
      m_dbList.Add(db);
    }

    public List<DataBase> getDbList()
    {
      return m_dbList;
    }

    public void CreateTable(string database, string tablename, string UniqueKey, KeyValuePair<string, string> columnData)
    {
      int flag = 0;
      DbTable table = new DbTable();
      table.setUniqueKey(UniqueKey);
      table.settableName(tablename);
      table.setColumnData(columnData.Key.ToString(),columnData.Value.ToString());
      foreach (DataBase db in m_dbList)
      {
        if (db.getDb().Key == database)
        {
          db.getDb().Value.Add(table);
          flag = 1;
        }
      }
      if (flag == 0)
      {
        Console.WriteLine("The database {0} does not exist", database);
      }

    }


    public void DeleteColumn(string database, string column, string table)
    {
      int flag = 0;
      List<DbTable> m_tableList = new List<DbTable>();
      List<KeyValuePair<string, string>> m_column = new List<KeyValuePair<string, string>>();
      foreach (DataBase db in m_dbList)
      {
        if (db.getDb().Key == database)
        {
          m_tableList = db.getDb().Value;
        }
      }
      foreach(DbTable tab in m_tableList)
      {
        if (tab.getTableName() == table)
        {
          m_column = tab.getColumnData();
        }
      }
      foreach(KeyValuePair<string,string> col in m_column)
      {
        if (col.Key == column)
        {
          m_column.Remove(col);
          flag = 1;
        }
      }
   
      if (flag == 0)
      {
        Console.WriteLine("The column {0} does not exist", column);
      }

    }

  }


}
