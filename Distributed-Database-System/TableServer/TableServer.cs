using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.eskimodb.tableserver
{
  public class DatabaseTable
  {
    public string Table_name;
    public string Primary_Key;
    public List<string> columns = new List<string>();

    public DatabaseTable(string tablename,string primarykey,List<string> columnnames)
    {
      Table_name = tablename;
      Primary_Key = primarykey;
      foreach (string  item in columnnames)
      {
        columns.Add(item);
      }
  
    }
 }



  public class Database
  {
    string DbName;
    List<DatabaseTable> m_List = new List<DatabaseTable>();
    List<string> DatabaseList = new List<string>();

    public Database(string DBname)
    {
      DbName = DBname;

     
     }

    public void PopulateDatabase(string databasename)
    {
      DatabaseList.Add(databasename);
    }

    public void PopulateTable(DatabaseTable table)
    {
      m_List.Add(table);
     

    }

    public void deleteTable(DatabaseTable table)
    {
      m_List.Remove(table);
   
    }

    public DatabaseTable RenameTable(string OldTableName, string NewTableName,List<DatabaseTable> tablelist)
    {
      DatabaseTable d1= tablelist.Find(delegate(DatabaseTable d) { return d.Table_name == OldTableName; });
      d1.Table_name = NewTableName;
      return d1;
     }
  
  }
}
