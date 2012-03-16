////////////////////////////////////////////////////////////////////////////////
// Node.cs - Performs TableServer/Rowserver functions                          //
//                                                                            //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yu Chi Jen / Priya Dodwad,   Syracuse University             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////
/*
  * Module Operations
  * =================
  * 
  * This class is a part of TableServer Package.
  * 
  * 
  * 
  * 
  * Public Interface
  * ================
  *  Class TableServer
  *  public TableManager() //constructor               
  *  public TableResponse CreateDatabase(string databaseName) //create database
  *  public TableResponse DeleteDatabase(string databaseName) //delete database
  *  public TableResponse CreateTable(string databaseName, string tableName, Dictionary<string, bool> columnName, List<string> columnType) //create table
  *  public TableResponse RenameTable(string databaseName, string oldTableName, string newTableName)  //rename table
  *  public TableResponse DeleteTable(string databaseName, string tableName)   //delete table
  *  public TableResponse EmptyTable(string databaseName, string tableName)    //empty table
  *  public TableResponse AddColumn(string databaseName, string tableName, bool uniqueKey, string columnName, string columnType) //add column
  *  public TableResponse RenameColumn(string databaseName, string tableName, string oldColumnName, string newColumnName)  //rename column
  *  public TableResponse DeleteColumn(string databaseName, string tableName, string columnName) //delete column
  *  public TableResponse InsertRow(string databaseName, string tableName, List<string> columnName, ArrayList columnValue)  //insert row
  *  public TableResponse SelectRow(string database, string tableName, List<string> selectColumns, string countColumn, List<TernaryAssociative<string, string, string>> whereList, List<KeyValuePair<string, string>> orderByColumns, int limitStart, int limitCount) //select row 
  *  public Dictionary<string, List<string>> GetDBInfo()  //get database info
  *  
  * 
  *  class InsertTypeValueObj
  *  
  *  public InsertTypeValueObj(string colType, object colValue)
  *  public string ColumnType
  *  public object ColumnValue
  * 
  *  class BinaryManager
  *  
  *  public static long SizeCalculator(string inputType)   // calculate input type size
  *  public static long GetFreeLease(string activeDir, string databaseName, string tableName)    //get FreeLease
  *  private static int GetRowColumnNameOffset(string filePath, string columnName)           //get row table's column name's offset indexb
  *  public static int GetColumnNumber(string metaPath)    //get column number in a Table
  *  public static List<InsertTypeValueObj> ReadRow(string rowPath, string metaPath)  //read row.dat row by row
  *  public static void AddRow(long freeLease, string rowPath, List<InsertTypeValueObj> listTypeValue)  //add a new row to row.dat
  *  public static void AddPkRow(long freeLease, string metaPath, Dictionary<string, string> dicNamePk, List<InsertTypeValueObj> listTypeValue)  //add a new row to Pk.dat
  *  public static long GetNewPkNumber(string rowPath, string pkType)  //get Pk.dat new Pk Index
  *  public static void MetaChangeFreeLease(string metaPath, string rowPath)  //update meta's FreeLease
  *  public static void MetaAddColumn(string metaPath, bool uniqueKey, string columnName, string columnType)  //add a new column into meta 
  *  public static void RowAddColumn(string rowPath, string metaPath, bool uniqueKey, string columnName, string columnType)  //add column in row.dat 
  *  public static byte[] ByteColVal(string columnType, string colVal)   // get byte of string value 
  *  public static void MetaGenerator(string fileName, List<string> columnType, Dictionary<string, bool> columnName)  //generate metadata xml for a table
  *  public static bool RenameColumn(string filePath, string oldName, string newName) // rename row table column 
  *  public void GeneratePkFile(string fileName, string pkType, long rootOffset, long freeChunk, long padding)   //generate pk binary file with header 
  *  public void GenerateRowFile(string fileName, List<string> columnType, Dictionary<string, bool> columnName)    //generate row table binary file
  *  
  * public class AddHeader
  * 
  *  public void ReadNode(string tablename, long primarykey, long rowindex, int color, long leftchild, long rightchild) //Read the node
  *  private void AppendData(string tablename, long primarykey, long rowindex, int color, long leftchild, long rightchild) //Append Data
  *
  * 
  */
/*
  * Build Process
  * =============
  * Required Files:
  *
  * Maintenance History
  * ===================
  * 
  * ver 1.0 :  01 Dec 11
  *   - first release
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using edu.syr.cse784.eskimodb.sharedobjs;
using System.Collections;
using System.Xml.Linq;

using edu.syr.eskimodb.tableserver.Test;

namespace edu.syr.eskimodb.tableserver
{
  public class TableManager : ITableServer
  {
    private static string activeDir = "C:\\Temp\\";

    public TableManager()
    {
      if (!File.Exists(activeDir))
      {//create folder
        Directory.CreateDirectory(activeDir);
      }
    }

    //create Database
    public TableResponse CreateDatabase(string databaseName)
    {
      // Specify a "currently active folder"
      //string activeDir = @"C:\\Temp\\";
      //Create a new subfolder under the current active folder
      try
      {
        string newPath = System.IO.Path.Combine(activeDir, databaseName);
        // Create the subfolder
        if (Directory.Exists(newPath))
        {
          return new TableResponse(true, "Database exist already", "Database present");
        }
        System.IO.Directory.CreateDirectory(newPath);
        return new TableResponse(true, "Database Created Successfully", "Database created");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error: create Table error", "Table Not Created");
      }
    }

    //delete database 
    public TableResponse DeleteDatabase(string databaseName)
    {
     
      try
      {
        string fileName = activeDir + databaseName;

        string[] dirs = Directory.GetDirectories(fileName);
        foreach (string dir in dirs)
        {
          if (System.IO.Directory.Exists(dir))
          {

            System.IO.Directory.Delete(dir, true);

          }
        }

        System.IO.Directory.Delete(fileName);
        return new TableResponse(true, "Database Deleted Successfully", "Database Deleted");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error: Database Delete error", "Database not deleted" + e.Message.ToString());
      }
    }

    //column key type: string : "int" , "float", "VarChar(10)";
    public TableResponse CreateTable(string databaseName, string tableName, Dictionary<string, bool> columnName, List<string> columnType)
    {
      try
      {
        // Specify a "currently active folder"
        string activeDir_ = activeDir + databaseName + "\\";
        string newPath = System.IO.Path.Combine(activeDir_, tableName);
        if (Directory.Exists(newPath))
        { return new TableResponse(false, "Table exist already", "TableResponse"); }
        // Create the subfolder
        System.IO.Directory.CreateDirectory(newPath);
        //generate the corresponding PK files under the Folder Names: File Name= tableName_columnName.dat
        int dicIndex = 0;
        foreach (var i in columnName)
        {
          if (i.Value == true)
          {
            string path = newPath + "\\" + i.Key + ".dat";
            BinaryManager h = new BinaryManager();
            h.GeneratePkFile(path, columnType[dicIndex], 32, -1, 0);
          }
          dicIndex++;
        }
        //generate Row Table file 
        string rowTbPath = newPath + "\\row.dat";
        BinaryManager rowTbHeader = new BinaryManager();
        rowTbHeader.GenerateRowFile(rowTbPath, columnType, columnName);
        //generate metadata XML file 
        string metaPath = newPath + "\\" + tableName;
        BinaryManager.MetaGenerator(metaPath, columnType, columnName);

        return new TableResponse(true, "Table Created Successfully", "Table created");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error: Create Table error", "Table not created");
      }
    }

    //move contents of one table folder into another folder with new table name
    public TableResponse RenameTable(string databaseName, string oldTableName, string newTableName)
    {
      try
      {
        string path = activeDir + databaseName + "\\" + oldTableName;
        string newPath = activeDir + databaseName + "\\" + newTableName;
        //check repeat new folder name
        if (Directory.Exists(newPath))
        { return new TableResponse(true, "The new Table name exists already", "Table present"); }

        //check original Table exist
        if (Directory.Exists(path) == true)
        { Directory.Move(path, newPath); }
        else
        { return new TableResponse(false, "The original Table is not exist", "Table not present"); }

        return new TableResponse(true, "Rename Table Successful", "Table is renamed");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error: Rename Table error", "Table cannot be renamed");
      }
    }

    //delete the table
    public TableResponse DeleteTable(string databaseName, string tableName)
    {
      try
      {
        string fileName = activeDir + databaseName + "\\" + tableName;


        string[] files = Directory.GetFiles(fileName);
        foreach (string dir in files)
        {

          System.IO.File.Delete(dir);


        }
        System.IO.Directory.Delete(fileName);

        return new TableResponse(true, "Table Deleted Successfully", "Table Deleted");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error: Delete Table error", "Table cannot be deleted" + e.Message.ToString());
      }
    }


    //rename a column 
    public TableResponse RenameColumn(string databaseName, string tableName, string oldColumnName, string newColumnName)
    {
      try
      {
        string path = activeDir + databaseName + "\\" + tableName;
        string oldPkFilePath = Path.Combine(path, oldColumnName);
        string newPkFilePath = Path.Combine(path, newColumnName);

        //check Table name exist
        if (!Directory.Exists(path))
        { return new TableResponse(false, "Table name doesn't exist", "Table does not exist"); }

        //======check Pk Binary files and try to rename======        
        string[] files = Directory.GetFiles(path);
        foreach (string file in files)
        {
          if (oldColumnName == file.Substring(file.LastIndexOf('\\') + 1).Split('.')[0].ToString())
          { File.Move(oldPkFilePath + ".dat", newPkFilePath + ".dat"); }
        }
        //=========rename row table's column in XML meta file===========
        if (BinaryManager.RenameColumn(Path.Combine(path, tableName + ".xml"), oldColumnName, newColumnName))
          return new TableResponse(true, "Column name rename successfully", "Rename Successful");
        else
          return new TableResponse(false, "Error: Column name in Row Table rename fail", "Column Rename Fail");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error: Rename Column error", "Column cannot be renamed");
      }
    }

    //empty a table
    public TableResponse EmptyTable(string databaseName, string tableName)
    {
      try
      {
        long PKtype;
        long rootoffset;
        long freechunk;
        long padding;
        // Specify a "currently active folder"
        string activeDir_ = activeDir + databaseName + "\\";
        //Create a new subfolder under the current active folder
        string newPath = System.IO.Path.Combine(activeDir_, tableName);
        // Create the subfolder
        string[] files = Directory.GetFiles(newPath);
        List<string> filelist = new List<string>();
        foreach (string f in files)
        {
          filelist.Add(f);
        }

        for (int i = 0; i < files.Count(); i++)
        {

          string filename = files[i];
          int pos = filename.LastIndexOf('\\');
          int end_pos = filename.IndexOf('.');
          string name = filename.Substring((pos + 1), (end_pos - pos) - 1);
          //code to empty the file named row.dat//
          if (name == "row")
          {

            // Delete the file if it exists.
            if (File.Exists(filename))
            {
              File.Delete(filename);
            }

            using (Stream filestream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
              filestream.Close();
            }

            filelist.Remove(files[i]);

          }
        }

        for (int i = 0; i < filelist.Count(); i++)
        {
          BinaryReader binReader = new BinaryReader(File.Open(filelist[i], FileMode.Open));
          byte[] testArray = new byte[31];
          int count = binReader.Read(testArray, 0, 31);

          // Reset the position in the stream to zero.
          binReader.BaseStream.Seek(0, SeekOrigin.Begin);
          //create objects of BinaryReader and BinaryWriter classes
          PKtype = binReader.ReadInt64();
          rootoffset = binReader.ReadInt64();
          freechunk = binReader.ReadInt64();
          padding = binReader.ReadInt64();
          binReader.Close();
          System.IO.File.Delete(filelist[i]);
          // System.IO.File.Create(files[i]);
          using (BinaryWriter binWriter =
               new BinaryWriter(File.Open(filelist[i], FileMode.OpenOrCreate)))
          {
            binWriter.Write(PKtype);
            binWriter.Write(rootoffset);
            binWriter.Write(freechunk);
            binWriter.Write(padding);
            binWriter.Close();
          }


        }
        return new TableResponse(true, "Table Emptied successfully", "Empty table");
      }

      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error:Cannot Empty the table", "Table Not Empty " + e.Message.ToString());
      }
    }

    //add a new column to row server
    public TableResponse AddColumn(string databaseName, string tableName, bool uniqueKey, string columnName, string columnType)
    {
      try
      {
        string activeDir_ = activeDir + databaseName + "\\";
        string newPath = System.IO.Path.Combine(activeDir_, tableName);
        string pkPath = newPath + "\\" + columnName + ".dat";
        string metaPath = newPath + "\\" + tableName + ".xml";
        string rowPath = newPath + "\\row.dat";

        // if new column is key, then generate new Pk binary file
        if (uniqueKey)
        {
          BinaryManager h = new BinaryManager();
          h.GeneratePkFile(pkPath, columnType, 32, -1, 0);
        }
        BinaryManager.RowAddColumn(rowPath, metaPath, uniqueKey, columnName, columnType);

        BinaryManager.MetaAddColumn(metaPath, uniqueKey, columnName, columnType);

        return new TableResponse(true, "add column successfully", "add column");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "Error: add column error", "add column failed");
      }
    }

    //delete column in row server
    public TableResponse DeleteColumn(string databaseName, string tableName, string columnName)
    {
      throw new NotImplementedException();
    }

    //insert a new row into table
    public TableResponse InsertRow(string databaseName, string tableName, List<string> columnName, ArrayList columnValue)
    {
      try
      { //read the Table.xml to read currentRI, FreeLease and each type to know which index to add, if meets Pk column, add to Pk.dat
        string activeDir_ = activeDir + databaseName + "\\";
        string newPath = System.IO.Path.Combine(activeDir_, tableName);
        string metaPath = newPath + "\\" + tableName + ".xml";
        string rowPath = newPath + "\\row.dat";
        Dictionary<string, string> metaDicNameType = new Dictionary<string, string>();
        Dictionary<string, string> metaDicNamePk = new Dictionary<string, string>();
        XDocument doc = XDocument.Load(metaPath);
        var q = from x in
                  doc.Descendants()
                select x;
        long freeLease = BinaryManager.GetFreeLease(activeDir, databaseName, tableName);
        //calculate order of columeName, extract xml column names in List      
        foreach (var xele in q.Elements("col"))
        { metaDicNameType.Add(xele.Element("name").Value, xele.Element("type").Value); }
        foreach (var xele in q.Elements("col"))
        { metaDicNamePk.Add(xele.Element("name").Value, xele.Element("PK").Value); }
        if (metaDicNameType.Count != columnName.Count)
        { return new TableResponse(false, "row item numbers doesn't match", "InsertRow"); }
        //Dictionary<string, InsertTypeValueObj> insertDicNameTypeVal = new Dictionary<string, InsertTypeValueObj>();
        List<InsertTypeValueObj> listTypeValue = new List<InsertTypeValueObj>();
        foreach (var dic in metaDicNameType)
        {
          for (int i = 0; i < columnName.Count; i++)
          {
            if (columnName[i] == dic.Key) // input to another dictionary 
            {
              InsertTypeValueObj itvObj = new InsertTypeValueObj(dic.Value, columnValue[i]);
              listTypeValue.Add(itvObj);
            }
          }
        }
        BinaryManager.AddRow(freeLease, rowPath, listTypeValue);
        // recalculate new FreeLease position and write back to table.xml then write to pk.dat
        BinaryManager.MetaChangeFreeLease(metaPath, rowPath);
        long newFreeLease = BinaryManager.GetFreeLease(activeDir, databaseName, tableName);
        BinaryManager.AddPkRow(newFreeLease, metaPath, metaDicNamePk, listTypeValue);
        return new TableResponse(true, "add row data successfully", "add row");
      }
      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
        return new TableResponse(false, "add row fail", "Row not added");
      }
    }

    //select Row and return row data
    public TableResponse SelectRow(string database, string tableName, List<string> selectColumns, string countColumn, List<TernaryAssociative<string, string, string>> whereList, List<KeyValuePair<string, string>> orderByColumns, int limitStart, int limitCount)
    {
      throw new NotImplementedException();
    }


    public Dictionary<string, List<string>> GetDBInfo()
    {
      throw new NotImplementedException();
    }
  }

  // value object for containing Type and Value of one data entry
  public class InsertTypeValueObj
  {
    public InsertTypeValueObj(string colType, object colValue)
    {
      ColumnType = colType;
      ColumnValue = colValue;
    }
    public string ColumnType
    {
      get;
      set;
    }
    public object ColumnValue
    {
      get;
      set;
    }
  }


  public class BinaryManager
  {
    // calculate input type size
    public static long SizeCalculator(string inputType)
    {
      long size = 0;
      long varcharSize = 0;

      switch (inputType)
      {
        case "int":
          size = 4;
          break;
        case "float":
          size = 4;
          break;
        default:
          string tem = inputType.Substring(8).Split(')')[0].ToString();
          Int64.TryParse(tem, out varcharSize);
          size = varcharSize;
          //Console.WriteLine("padding:{0},{1}", m_PKType.Substring(8).Split(')')[0].ToString(),VarcharSizePadding);
          break;
      }
      return size;
    }

    //get FreeLease
    public static long GetFreeLease(string activeDir, string databaseName, string tableName)
    {
      //read the Table.xml to read currentRI, FreeLease and each type to know which index to add, if meets Pk column, add to Pk.dat
      string activeDir_ = activeDir + databaseName + "\\";
      string newPath = System.IO.Path.Combine(activeDir_, tableName);
      string metaPath = newPath + "\\" + tableName + ".xml";
      long freeLease = -1;
      Dictionary<string, string> metaDicNameType = new Dictionary<string, string>();
      XDocument doc = XDocument.Load(metaPath);
      var q = from x in
                doc.Descendants()
              select x;
      Int64.TryParse(q.Elements("FreeLease").First().Value, out freeLease);
      return freeLease;
    }

    //get row table's column name's offset index
    private static int GetRowColumnNameOffset(string filePath, string columnName)
    {
      BinaryReader binReader = new BinaryReader(File.Open(filePath, FileMode.Open));
      binReader.BaseStream.Seek(16, SeekOrigin.Begin);
      long rootOffset = binReader.ReadInt64();
      long colNameNumber = (rootOffset - 33) / 10;
      binReader.BaseStream.Seek(33, SeekOrigin.Begin);
      int index = 0;
      for (int i = 0; i < colNameNumber; i++)
      {
        char[] colName = binReader.ReadChars(10);
        string colNameString = "";
        foreach (char col in colName)
        { colNameString += col.ToString(); }
        //Console.WriteLine(ColNameString);
        if (colNameString.Trim() == columnName)
        { index = 33 + i * 10; }
      }
      binReader.Close();
      return index;
    }

    //get column number in a Table
    public static int GetColumnNumber(string metaPath)
    {
      XDocument doc = XDocument.Load(metaPath);
      var q = from x in
                doc.Descendants()
              select x;
      //calculate order of columeName, extract xml column names in List      
      int typeIndex = 0;
      foreach (var xele in q.Elements("col"))
      {
        typeIndex++;
      }
      return typeIndex;
    }

    //read row.dat row by row
    public static List<InsertTypeValueObj> ReadRow(string rowPath, string metaPath)
    {
      Dictionary<int, string> metaDicNoType = new Dictionary<int, string>();
      List<InsertTypeValueObj> listTypeValue = new List<InsertTypeValueObj>();
      XDocument doc = XDocument.Load(metaPath);
      var q = from x in
                doc.Descendants()
              select x;
      int typeIndex = 0;
      foreach (var xele in q.Elements("col"))
      {
        metaDicNoType.Add(typeIndex, xele.Element("type").Value);
        typeIndex++;
      }
      BinaryReader br = new BinaryReader(File.Open(rowPath, FileMode.Open));
      int pos = 0;
      int trackX = 0;
      while (pos < (int)br.BaseStream.Length)
      {
        int typePt = trackX % typeIndex;
        foreach (var meta in metaDicNoType)
        {
          if (typePt == meta.Key) // match type read that type
          {
            switch (meta.Value)
            {
              case "int":
                listTypeValue.Add(new InsertTypeValueObj(meta.Value, br.ReadInt32()));
                pos += sizeof(int);
                trackX++;
                break;
              case "float":
                listTypeValue.Add(new InsertTypeValueObj(meta.Value, br.ReadSingle()));
                pos += sizeof(float);
                trackX++;
                break;
              default:
                long varcharSize = 0;
                string varcharLength = meta.Value.Substring(8).Split(')')[0].ToString();
                Int64.TryParse(varcharLength, out varcharSize);
                listTypeValue.Add(new InsertTypeValueObj(meta.Value, br.ReadBytes((int)varcharSize)));
                pos += (int)varcharSize;
                trackX++;
                break;
            }
          }
        }
      }
      br.Close();
      return listTypeValue;
    }

    //add a new row to row.dat
    public static void AddRow(long freeLease, string rowPath, List<InsertTypeValueObj> listTypeValue)
    {
      long offset = freeLease;
      long rowLength = 0;
      using (Stream filestream = new FileStream(rowPath, FileMode.Open, FileAccess.Write, FileShare.None))
      {
        BinaryWriter writer = new BinaryWriter(filestream);
        {
          writer.BaseStream.Seek(offset, SeekOrigin.Begin);
          foreach (var typeVal in listTypeValue)
          {
            rowLength += BinaryManager.SizeCalculator(typeVal.ColumnType);
            switch (typeVal.ColumnType)
            {
              case "int":
                writer.Write((int)typeVal.ColumnValue);
                break;
              case "float":
                writer.Write((float)typeVal.ColumnValue);
                break;
              default:
                long varcharSize = 0;
                string varcharLength = typeVal.ColumnType.Substring(8).Split(')')[0].ToString();
                Int64.TryParse(varcharLength, out varcharSize);
                string ColVal = (string)typeVal.ColumnValue;
                int lengthOfColVal = ColVal.Length;
                for (int i = 0; i < varcharSize - lengthOfColVal; i++)
                { ColVal += " "; }
                byte[] byteColVal = System.Text.Encoding.ASCII.GetBytes(ColVal);
                writer.Write(byteColVal);
                //Console.WriteLine("padding:{0},{1}", m_PKType.Substring(8).Split(')')[0].ToString(),VarcharSizePadding);
                break;
            }
          }
          writer.Close();
        }
        filestream.Close();
      }
    }

    //add a new row to Pk.dat
    public static void AddPkRow(long freeLease, string metaPath, Dictionary<string, string> dicNamePk, List<InsertTypeValueObj> listTypeValue)
    { // calculate Row Index from meta, freeChunk / row length
      long rowLength = 0;
      long rowIndex = 0;
      foreach (var typeVal in listTypeValue)
      { rowLength += BinaryManager.SizeCalculator(typeVal.ColumnType); }
      rowIndex = freeLease / rowLength;
      int colIndex = 0;
      foreach (var namePk in dicNamePk)
      {
        if (namePk.Value == "True") //add Pk file row
        {// find that name Pk file and open it 
          string rowPath = metaPath.Substring(0, metaPath.LastIndexOf("\\")) + "\\" + namePk.Key + ".dat";
          long pkIndex = GetNewPkNumber(rowPath, listTypeValue[colIndex].ColumnType);
          using (Stream filestream = new FileStream(rowPath, FileMode.Append, FileAccess.Write, FileShare.None))
          {
            BinaryWriter writer = new BinaryWriter(filestream);
            {
              switch (listTypeValue[colIndex].ColumnType)
              {
                case "int":
                  writer.Write((int)listTypeValue[colIndex].ColumnValue);
                  writer.Write(rowIndex);
                  break;
                case "float":
                  writer.Write((float)listTypeValue[colIndex].ColumnValue);
                  writer.Write(rowIndex);
                  break;
                default:
                  long varcharSize = 0;
                  string varcharLength = listTypeValue[colIndex].ColumnType.Substring(8).Split(')')[0].ToString();
                  Int64.TryParse(varcharLength, out varcharSize);
                  string ColVal = (string)listTypeValue[colIndex].ColumnValue;
                  int lengthOfColVal = ColVal.Length;
                  for (int i = 0; i < varcharSize - lengthOfColVal; i++)
                  { ColVal += " "; }
                  byte[] byteColVal = System.Text.Encoding.ASCII.GetBytes(ColVal);
                  writer.Write(byteColVal);
                  writer.Write(rowIndex);
                  break;
              }
            }
            writer.Close();
            filestream.Close();
          }
        }
        colIndex++;
      }
    }

    //get Pk.dat new Pk Index
    public static long GetNewPkNumber(string rowPath, string pkType)
    {
      long ret = 0;
      using (BinaryReader b = new BinaryReader(File.Open(rowPath, FileMode.Open)))
      {
        long length = (long)b.BaseStream.Length;
        long dataLength = length - 32;
        switch (pkType)
        {
          case "int":
            ret = dataLength / 12;
            break;
          case "float":
            ret = dataLength / 12;
            break;
          default:
            long varcharSize = 0;
            string varcharLength = pkType.Substring(8).Split(')')[0].ToString();
            Int64.TryParse(varcharLength, out varcharSize);
            ret = dataLength / (8 + varcharSize);
            break;
        }
        b.Close();
      }
      return ret + 1;
    }

    //update meta's FreeLease
    public static void MetaChangeFreeLease(string metaPath, string rowPath)
    {
      long newFreeLease;
      using (BinaryReader b = new BinaryReader(File.Open(rowPath, FileMode.Open)))
      {
        long length = (long)b.BaseStream.Length;
        newFreeLease = length;
        b.Close();
      }

      StringBuilder sb_source = new StringBuilder();
      StreamReader sr = new StreamReader(metaPath);
      String line;
      while ((line = sr.ReadLine()) != null)
      {
        if (line.Trim().Contains("<FreeLease>"))
        { sb_source.Append("<FreeLease>" + newFreeLease + "</FreeLease> \n"); }
        else
        { sb_source.Append(line).Append("\n"); }
      }
      sr.Close();

      StreamWriter sw = new StreamWriter(metaPath);
      sw.Write(sb_source.ToString()); //write a line of text to the file               
      sw.Close();

    }

    //add a new column into meta 
    public static void MetaAddColumn(string metaPath, bool uniqueKey, string columnName, string columnType)
    {
      StringBuilder sb_source = new StringBuilder();
      StreamReader sr = new StreamReader(metaPath);
      String line;
      while ((line = sr.ReadLine()) != null)
      {
        if (line.Trim().Contains("<cols>"))
        {
          sb_source.Append("<cols>\n");
          sb_source.Append("<col>\n");
          sb_source.Append("<name>" + columnName + "</name>\n");
          sb_source.Append("<PK>" + uniqueKey + "</PK>\n");
          sb_source.Append("<type>" + columnType + "</type>\n");
          sb_source.Append("<Length>" + SizeCalculator(columnType) + "</Length>\n");
          sb_source.Append("</col>\n");
        }
        else
        { sb_source.Append(line).Append("\n"); }
      }
      sr.Close();

      StreamWriter sw = new StreamWriter(metaPath);
      sw.Write(sb_source.ToString()); //write a line of text to the file               
      sw.Close();
      // renew the FreeLease in meta
      string rowPath = metaPath.Substring(0, metaPath.LastIndexOf("\\")) + "\\row.dat";
      MetaChangeFreeLease(metaPath, rowPath);
    }

    //add column in row.dat 
    public static void RowAddColumn(string rowPath, string metaPath, bool uniqueKey, string columnName, string columnType)
    {
      BinaryReader binReader = new BinaryReader(File.Open(rowPath, FileMode.Open));
      byte[] testArray = new byte[4];
      int count = binReader.Read(testArray, 0, 4);
      binReader.Close();
      // if the row.dat is not empty, then we add new column 
      if (count != 0)
      { // extract all current data and insert new column in the front of row
        List<InsertTypeValueObj> curAllRowData = ReadRow(rowPath, metaPath);
        long curColNumber = GetColumnNumber(metaPath);
        int trackX = 0;
        //string tempRowPath = RowPath.Substring(0, RowPath.LastIndexOf("\\")) + "\\TempRow.bat";
        using (Stream filestream = new FileStream(rowPath, FileMode.Create, FileAccess.Write, FileShare.None))
        {
          BinaryWriter writer = new BinaryWriter(filestream);
          {
            for (int i = 0; i < curAllRowData.Count; i++)
            {
              int typePt = trackX % ((int)curColNumber);
              if (typePt == 0)  // add new column and original first column
              {
                switch (columnType)  // add new column
                {
                  case "int":
                    int intVal = 0;
                    writer.Write(intVal);
                    break;
                  case "float":
                    float FlVal = 0f;
                    writer.Write(FlVal);
                    break;
                  default:
                    writer.Write(ByteColVal(columnType, ""));
                    break;
                }
                switch (curAllRowData[i].ColumnType)
                {
                  case "int":
                    writer.Write((int)curAllRowData[i].ColumnValue);
                    break;
                  case "float":
                    writer.Write((float)curAllRowData[i].ColumnValue);
                    break;
                  default:
                    writer.Write((byte[])curAllRowData[i].ColumnValue);
                    break;
                }
              }
              else  // add original rest column back
              {
                switch (curAllRowData[i].ColumnType)
                {
                  case "int":
                    writer.Write((int)curAllRowData[i].ColumnValue);
                    break;
                  case "float":
                    writer.Write((float)curAllRowData[i].ColumnValue);
                    break;
                  default:
                    writer.Write((byte[])curAllRowData[i].ColumnValue);
                    break;
                }
              }
              trackX++;
            }
            writer.Close();
          }
          filestream.Close();
        }
      }
    }

    // get byte of string value 
    public static byte[] ByteColVal(string columnType, string colVal)
    {
      long varcharSize = 0;
      string varcharLength = columnType.Substring(8).Split(')')[0].ToString();
      Int64.TryParse(varcharLength, out varcharSize);
      int lengthOfColVal = colVal.Length;
      for (int j = 0; j < varcharSize - lengthOfColVal; j++)
      { colVal += " "; }
      byte[] byteColVal = System.Text.Encoding.ASCII.GetBytes(colVal);

      return byteColVal;
    }

    //generate metadata xml for a table
    public static void MetaGenerator(string fileName, List<string> columnType, Dictionary<string, bool> columnName)
    {
      StringBuilder sb_Col = new StringBuilder();
      int dicIndex = 0;
      long totalLength = 0;
      foreach (var i in columnName)
      {
        sb_Col.Append("<col>\n");
        sb_Col.Append("<name>" + i.Key + "</name>\n");
        sb_Col.Append("<PK>" + i.Value + "</PK>\n");
        sb_Col.Append("<type>" + columnType[dicIndex] + "</type>\n");
        sb_Col.Append("<Length>" + SizeCalculator(columnType[dicIndex]) + "</Length>\n");
        sb_Col.Append("</col>\n");
        totalLength += SizeCalculator(columnType[dicIndex]);
        dicIndex++;
      }
      StringBuilder sb = new StringBuilder();
      sb.Append("<?xml version=\"1.0\" ?>\n");
      sb.Append("<table>\n");
      sb.Append("<CurrentRI>0</CurrentRI> \n");
      sb.Append("<FreeLease>0</FreeLease> \n");
      sb.Append("<cols>\n");
      sb.Append(sb_Col.ToString());
      sb.Append("</cols>\n");
      sb.Append("</table>\n");

      StreamWriter sw = new StreamWriter(fileName + ".xml");
      sw.Write(sb.ToString()); //write a line of text to the file               
      sw.Close();

    }

    // rename row table column 
    public static bool RenameColumn(string filePath, string oldName, string newName)
    {
      if (File.Exists(filePath))
      {
        try
        {
          StringBuilder sb_source = new StringBuilder();
          StreamReader sr = new StreamReader(filePath);
          String line;
          while ((line = sr.ReadLine()) != null)
          {
            if (line.Trim().Contains("<name>" + oldName + "</name>"))
            { sb_source.Append("<name>" + newName + "</name>").Append("\n"); }
            else
            { sb_source.Append(line).Append("\n"); }
          }
          sr.Close();

          StreamWriter sw = new StreamWriter(filePath);
          sw.Write(sb_source.ToString()); //write a line of text to the file               
          sw.Close();
          return true;
        }
        catch (Exception e)
        {
          Console.WriteLine("Error:" + e.Message.ToString());
          return false;
        }
      }
      else
        return false;
    }

    //generate pk binary file with header 
    public void GeneratePkFile(string fileName, string pkType, long rootOffset, long freeChunk, long padding)
    {
      // header h = new header(20, 10, -1, 24);
      long keyTypeCode;
      long varcharSizePadding = 0;

      switch (pkType)
      {
        case "int":
          keyTypeCode = 1;
          break;
        case "float":
          keyTypeCode = 2;
          break;
        default:
          keyTypeCode = 3;
          string tem = pkType.Substring(8).Split(')')[0].ToString();
          Int64.TryParse(tem, out varcharSizePadding);
          //Console.WriteLine("padding:{0},{1}", m_PKType.Substring(8).Split(')')[0].ToString(),VarcharSizePadding);
          break;
      }
      using (Stream filestream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        BinaryWriter writer = new BinaryWriter(filestream);
        {
          //Add header
          writer.Write(keyTypeCode);
          writer.Write(rootOffset);
          writer.Write(freeChunk);
          writer.Write(varcharSizePadding);
        }
        filestream.Close();
      }
    }

    //generate row table binary file
    public void GenerateRowFile(string fileName, List<string> columnType, Dictionary<string, bool> columnName)
    {
      using (Stream filestream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
      {
        filestream.Close();
      }
    }


    //For testing TestTableServer

    //static void Main(string[] args)
    //{
    //  TableServerTest t = new TableServerTest();
    //  t.Test();
    //  List<string> m_msg = new List<string>();
    //  m_msg = t.GetMessage();
    //  Console.WriteLine("The result of the Test Cases are as follows:");
    //  foreach (string m in m_msg)
    //  {
    //    Console.WriteLine(m);
    //  }
    //}


    //Test Cases
    static void Main(string[] args)
    {
      try
      {

        ///////////////Test Case 1//////////////////////
        //create object of TableManager Class

        TableManager bm = new TableManager();

        //populate the dictionary that holds the information about the Columns

        Dictionary<string, bool> dictColumnName = new Dictionary<string, bool>();
        dictColumnName.Add("ID", true);
        dictColumnName.Add("Name", false);
        dictColumnName.Add("Dept", true);

        List<string> columnTypelist = new List<string>();
        columnTypelist.Add("int");
        columnTypelist.Add("float");
        columnTypelist.Add("varchar(10)");

        List<string> ListColumnName = new List<string>();
        ListColumnName.Add("ID");
        ListColumnName.Add("Name");
        ListColumnName.Add("Dept");

        ArrayList AlColVal = new ArrayList();
        AlColVal.Add(12);
        AlColVal.Add(12.1f);
        AlColVal.Add("test2");

        bm.CreateDatabase("Status");
        bm.CreateTable("Status", "NewStat", dictColumnName, columnTypelist);
        bm.AddColumn("Status", "NewStat", false, "str", "varchar(8)");


        bm.InsertRow("Status", "NewStat", ListColumnName, AlColVal);
        bm.RenameTable("Status", "NewStat", "newTable");
        bm.RenameColumn("Status", "newTable", "newID", "ID");


        bm.EmptyTable("Status", "newTable");
        bm.DeleteTable("Status", "newTable");
        bm.DeleteDatabase("Status");

     }

      catch (Exception e)
      {
        Console.WriteLine("Error:" + e.Message.ToString());
      }
    }
    }

  }




  public class AddHeader
  {

    //reading a node in the file
    public void ReadNode(string tablename, long primarykey, long rowindex, int color, long leftchild, long rightchild)
    {
      long freechunk = 0;
      string fileName = "C:\\Temp\\" + tablename + ".dat";

      //open and read the file
      //append at the end of the file when FreeChunk=-1//


      if (File.Exists(fileName))
      {
        BinaryReader binReader =
            new BinaryReader(File.Open(fileName, FileMode.Open));
        try
        {
          // If the file is not empty,
          // read the application settings.
          // First read 4 bytes into a buffer to
          // determine if the file is empty.
          byte[] testArray = new byte[3];
          int count = binReader.Read(testArray, 0, 3);

          if (count != 0)
          {
            // Reset the position in the stream to zero.
            binReader.BaseStream.Seek(0, SeekOrigin.Begin);

            //create objects of BinaryReader and BinaryWriter classes
            long PKtype = binReader.ReadInt64();
            long rootoffset = binReader.ReadInt64();
            freechunk = binReader.ReadInt64();
            long padding = binReader.ReadInt64();
          }
        }
        catch (EndOfStreamException e)
        {
          Console.WriteLine("{0} caught and ignored. " +
              "Using default values.", e.GetType().Name);
        }
        binReader.Close();

      }

      if (freechunk == -1)
      {
        AppendData(tablename, primarykey, rowindex, color, leftchild, rightchild);
      }
      else
      {
        //read the bytes stored in freechunk variable and append at that position into the file
      }

    }

    private void AppendData(string tablename, long primarykey, long rowindex, int color, long leftchild, long rightchild)
    {

    }

  }




