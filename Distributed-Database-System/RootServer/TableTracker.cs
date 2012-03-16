using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RootServer
{
  public class DatabaseTable
  {
    string TableName { get; set; }
    string IPAddress { get; set; }
   
    public DatabaseTable(string Tablename, string IP)
    {
      TableName = Tablename;
      IPAddress = IP;
    }
      
  }

  public class Database
  {
     List<DatabaseTable> m_List = new List<DatabaseTable>();
     string DatabaseName { get; set; }

     public  Database(string databasename)
     {
       DatabaseName = databasename;
     }

     public void PopulateTable(DatabaseTable table)
     {
       m_List.Add(table);
     }

     public void deleteTable(DatabaseTable table)
     {
       m_List.Remove(table);
     }
   
   }
}

