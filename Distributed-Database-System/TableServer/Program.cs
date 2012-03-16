using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.eskimodb.tableserver
{
  class Program
  {
#if(TEST)
    static void Main(string[] args)
    {
      //create a dictionary
      Dictionary<Database, List<DatabaseTable>> dictionary = new Dictionary<Database, List<DatabaseTable>>();
      List<DatabaseTable> list = new List<DatabaseTable>();

      //create a list<string> for column_names to be stored
      List<string> column_names=new List<string>();

      //Populate the list of column names
      column_names.Add("StatusID");
      column_names.Add("Status_title");
      column_names.Add("Status_description");

      //create and initialize databasetable object "table1"
      DatabaseTable table1 = new DatabaseTable("Status", "StatusID",column_names);

      //create a new database object
      Database database1 = new Database("Database");

      //populate the database object with databasetable object
      database1.PopulateTable(table1);

      DatabaseTable table2 = new DatabaseTable("Client", "ClientID", column_names);
      database1.PopulateTable(table2);

      //Add the two tables into the list
      list.Add(table1);
      list.Add(table2);
    
      //populate the dictionary with the Database name and with corresponding List<table> objects in it
      dictionary.Add(database1, list);
     


      //Rename a particular table in a database with a new name
       DatabaseTable d=database1.RenameTable("Status", "NewStatus", list);
       list.Remove(table1);
       list.Add(d);

       IBinaryFile bf = new BinaryFile();
       long getRowSize = bf.GetRowSize();
       long size = bf.GetPrimaryKeySize();
       DataTypes pkey = bf.GetPrimaryKeyType();

        AddTable add = new AddTable();
      //create a new binary file 
      add.CreateTable("Status");
      //add a node into the binary file with the Table name
      add.CreateNode("Status", 10, 19, 4, 25, 35);

      TestWriter tw = new TestWriter();
      tw.bWriter();
      tw.search("C:\\Users\\TestBinary.dat");
       
    }
#endif
  }
}
