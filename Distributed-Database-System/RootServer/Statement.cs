/////////////////////////////////////////////////////////////////////////////////////////////////
//  Statement.cs:                  Responsible for determining query type and associated data  //
//  Language:                      C#, .Net Framework 4.0      				                         //
//  Platform:                      Windows 7								                                   //
//  Application:                   EskimoDB - RootServer                                       //
/////////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Module Operations:
 * =================
 * This module is responsible for fetching and storing the necessary data for each EskimoDB query
 * It contains various classes to support all the defined EskimoDb queries
 * /
/*
Maintainence History:
=====================
ver 1.0 : 03 October 2011
- first release
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.rootserver;

namespace edu.syr.cse784.eskimodb.rootserver
{
  public enum StatementType
  {
    CREATE_DB, CREATE_TABLE,
    MOD_TABLE, DELETE_DB,
    DELETE_TABLE, EMPTY_TABLE,
    INSERT_ROW, SELECT_ROW,
    UPDATE_ROW, DELETE_ROWS,
    SELECT_DB, RENAME_TABLE,
    RENAME_COLUMN
  };

  public class Statement
  {
    protected StatementType m_StatementType;

    public void SetStatementType(StatementType t)
    {
      this.m_StatementType = t;
    }

    public StatementType GetStatementType()
    {
      return this.m_StatementType;
    }
  }

  /* The class CreateDB is responsible for storing and retrieving the database name to be created.
   * according to the request sent by the client. 
   * setDatabaseName() sets the datbase name.
   * getDatabaseName() gives the name of the database to be created whenever requested.
   * @param m_DatabaseName is used to store and get the datbase name to be created.
   */ 
  public class CreateDB : Statement
  {
    private string m_DatabaseName;

    public void SetDatabaseName(string name)
    {
      this.m_DatabaseName = name;
    }

    public string GetDatabaseName()
    {
      return this.m_DatabaseName;
    }
  }

  /* The class SelectDB is responsible for storing and retrieving the database name to be selected
   * according to the request sent by the client. 
   * setDatabaseName() sets the datbase name
   * getDatabaseName() gives the name of the database to be selected whenever requested
   * @param m_DatabaseName is used to set and get the database name to be selected
   */ 
  public class SelectDB : Statement
  {
    private string m_DatabaseName;

    public void SetDatabaseName(string name)
    {
      this.m_DatabaseName = name;
    }

    public string GetDatabaseName()
    {
      return this.m_DatabaseName;
    }
  }

  /* The class DeleteDB is responsible for storing and retrieving the database name to be deleted.
   * according to the request sent by the client. 
   * setDatabaseName() stores the datbase name.
   * getDatabaseName() gives the name of the database to be deleted whenever requested.
   * @param m_DatabaseName is used to store and retrieve the database name to be deleted.
   */ 
  public class DeleteDB : Statement
  {
    private string m_DatabaseName;

    public void SetDatabaseName(string name)
    {
      this.m_DatabaseName = name;
    }

    public string GetDatabaseName()
    {
      return this.m_DatabaseName;
    }
  }

  /* The class DeleteTable is responsible for setting and retrieving the table name to be deleted.
   * according to the request sent by the client. 
   * setTableName() sets the datbase name.
   * getTableName() gives the name of the database whenever requested.
   * @param m_TableName is used to store and retrieve table name to be deleted.
   */ 
  public class DeleteTable : Statement
  {
    private string m_TableName;

    public void SetTableName(string name)
    {
      this.m_TableName = name;
    }

    public string GetTableName()
    {
      return this.m_TableName;
    }
  }

  /* The class EmptyTable is responsible for setting and retrieving the table name to be emptied.
   * according to the request sent by the client. 
   * setTableName() sets the table name to be emptied.
   * getTableName() gives the name of the table to be emptied whenever requested.
   * @param m_TableName is used to store and retrieve table name to be emptied.
   */ 
  public class EmptyTable : Statement
  {
    string m_TableName;

    public void SetTableName(string m_TableName)
    {
      this.m_TableName = m_TableName;
    }

    public string GetTableName()
    {
      return this.m_TableName;
    }
  }

  /* ModifyTab class is responsible two main actions
   * Adding a column to a Table.
   * Deleting a column from a Table.
   * setType() is responsible for setting the type of table modification i.e Add or Delete.
   * getType() retrieves the type of modification. 
   * setAddColumnData() sets the details necessary to add a column into a table.
   * getAddColumnData() retrives the data neccesay to add a column into a table.
   * setDelColumnData() sets the details necessary to delete a column from a table.
   * getDelColumnData() retrives the data neccesay to delete a column from a table.
   * @param m_Type is a string used to store and retrieve type of a column.
   * @param addColumnData is used to store and get the column datas necessary to add a new column.
   * @param delColumnData is used to store and get the column datas necessary to delete a column.
   */
  public class ModifyTab : Statement
  {
    string m_Type;
    AddColumn addColumnData;
    DeleteColumn delcolumnData;
    
    public void SetType(string m_Type)
    {
      this.m_Type = m_Type;
    }

    public string GetTyp()
    {
      return m_Type;
    }
    public void SetAddColumnData(AddColumn columnData)
    {
      this.addColumnData = columnData;
    }

    public AddColumn GetAddColumnData()
    {
      return addColumnData;
    }

    public void SetDelColumnData(DeleteColumn columnData)
    {
      delcolumnData = columnData;
    }

    public DeleteColumn GetDelcolumnData()
    {
      return delcolumnData;
    }
  }

  /* DeleteColumn class inherits ModifyTab and is responsible for delete column operation over a specified table.
   * setColumnData() sets the name of the column to be deleted.
   * getColumnData() retrieves the name of the column to be deleted.
   * setTableName() sets the table name on which the delete operation is to be performed.
   * getTableName() retieves the name of the table on which the delete operation is to be performed.
   * @param m_ColumnData is a string used to set and get column name.
   * @param m_TableName is a string used to set and get table name.
   */
  public class DeleteColumn : ModifyTab
  {
    
    string m_ColumnData;
    string m_TableName; 

    public void SetColumnData(string columnData)
    {
      this.m_ColumnData = columnData;
    }

    public string GetColumnData()
    {
      return m_ColumnData;
    }

    public void SetTableName(string m_Tablename)
    {
      this.m_TableName = m_Tablename;
    }

    public string GetTableName()
    {
      return m_TableName;
    }
  }

  /* AddColumn class inherits ModifyTab and is responsible for add column operation over a specified table.
   * setColumnData() sets the various data like unique key, column name, type of a column that is to be added to the specified table.
   * getColumnData() retrieves the various data like unique key, column name, type of a column that is to be added to the specified table.
   * setTableName() sets the table name on which the add operation is to be performed.
   * getTableName() retieves the name of the table on which the add operation is to be performed.
   * @param m_ColumnData specifies the unique key, column name , type of a particular column.
   * @param m_Table_Name is used to store and retrieve table name.
   */
  public class AddColumn : ModifyTab
  {
    TableColumn m_ColumnData;
    string m_TableName;

    public void SetColumnData(TableColumn columnData)
    {
      this.m_ColumnData = columnData;
    }

    public TableColumn GetColumnData()
    {
      return m_ColumnData;
    }

    public void SetTableName(string m_Tablename)
    {
      this.m_TableName = m_Tablename;
    }

    public string GetTableName()
    {
      return m_TableName;
    }
  }

  /* Table class is responsible for setting and retrieving table name
   * setTableName() sets the table name.
   * getTableName() retrieves the table name.
   * @param m_TableName is used to store and retrieve table name.
   */
  public class Table
  {
    string m_TableName;
    public void SetTableName(string m_TableName)
    {
      this.m_TableName = m_TableName;
    }

    public string GetTableName()
    {
      return m_TableName;
    }
  }

  /* CreateTable class is responsible setting and retreiving datas necessary for creation of a table
   * setTableName() sets the table name 
   * getTableName() retrieves the table name that should be created.
   * setList() sets the list of columns that must be present in the table
   * getList() retrieves the list of columns with which the table must be created
   * @param m_TableName is used to store and retrieve table name.
   * @param m_ColumnList is a list of column elements which specifies unique key, column name and type of a column
   */
  public class CreateTable : Statement
  {
    string m_TableName;
    List<TableColumn> m_ColumnList = new List<TableColumn>();
    public void SetTableName(string m_TableName)
    {
      this.m_TableName = m_TableName;
    }

    public string GetTableName()
    {
      return m_TableName;
    }

    public void SetList(ColumnList c)
    {
      m_ColumnList = c.GetList();
    }

    public List<TableColumn> GetList()
    {
      return m_ColumnList;
    }
  }

  /* ColumnList class is responsible collecting each column data and storing it in a list
   * addToList() is responsible adding each column entity into a list.
   * getList() is responsible retrieving the list which contains each element as a column entity
   * @param lis is a list of column elements which specifies unique key, column name and type of a column
   */
  public class ColumnList
  {
    List<TableColumn> lis = new List<TableColumn>();
    public void AddToList(TableColumn t)
    {
      lis.Add(t);
    }
    public List<TableColumn> GetList()
    {
      return lis;
    }
  }

  /* TableColumn is responsible setting and retrieving details for each column in a table.
   * setUniqueKey() sets the column as Primary Key or Index .
   * getUniqueKey() gets the Unique Key the specified column.
   * setColumnName() sets the name of a column.
   * getColumnName() retrieves the name of respective column.
   * setVarType() sets the type of the column.
   * getVarType() gets the type of the specified column.
   * @param m_UniqueKey is a string used to store and retrieve unique key of a column i.e primary key or index.
   * @param m_ColumnName is a string used to set and get column name.
   * @param m_TypeName is a string used to store and retrieve type of a column.
   * @param m_Number is a string used to set the length of a Varchar variable.
   */
  public class TableColumn
  {
    string m_UniqueKey;
    string m_ColumnName;
    string m_TypeName;
    string m_Number;

    public void SetUniqueKey(string m_UniqueKey)
    {
      this.m_UniqueKey = m_UniqueKey;
    }

    public string GetUniqueKey()
    {
      return m_UniqueKey;
    }

    public void SetColumnName(string m_ColumnName)
    {
      this.m_ColumnName = m_ColumnName;
    }

    public string GetColumnName()
    {
      return m_ColumnName;
    }

    public void SetVarType(VarType t)
    {
      m_TypeName = t.getVarType();
      m_Number = t.getVarRange();
    }

    public string GetVarType()
    {
      return m_TypeName;
    }

    public string GetVarRange()
    {
      return m_Number;
    }
  }

  /* VarType class sets and retrieves the type of a column.
   * setVartype() sets the type of the column.
   * getVarType() retrieves the type of the column.
   * setVarRange() sets the VARCHAR length if the column type is VARCHAR
   * getVarRange() gets the VARCHAR length  
   * @param m_Type is used to set and get the type of a variable
   * @param m_Number is used to set and get the length of a Varchar variable
   */
  public class VarType
  {
    string m_Type = null;
    string m_Number = null;
    public void SetVarType(string m_Type)
    {
      this.m_Type = m_Type;
    }
    public string getVarType()
    {
      return m_Type;
    }

    public void SetVarRange(string m_Number)
    {
      this.m_Number = m_Number;
    }
    public string getVarRange()
    {
      return m_Number;
    }
  }
  
  /* ColumnList_Ins class is responsible for storing and retrievel of column names 
   * in a particular table in order to insert a particular value in a specified column
   * addToList() is responsible for adding the column names into a list
   * getColumnList() returns a list of column names
   * @param lis is list of column names.
   */
  public class ColumnList_Ins
    {
      List<string> lis = new List<string>();
      public void AddToList(string m_ColumnName)
      {
        lis.Add(m_ColumnName);
      }
      public List<string> GetColumnList()
      {
        return lis;
      }

    }

  /* ColumnName class is responsible setting and retrieving each column name for which a value must be inserted
   * Each column name is then used by the above class (Column_Ins) to add the column names to a list
   * setColumnName() sets a colum name
   * getColumnName() gets a column name
   * @param m_ColumnName is a string used to store and retrieve column name
   */
  public class ColumnName
    {
      string m_ColumnName;

      public void SetColumnName(String m_ColumnName)
      {
        this.m_ColumnName = m_ColumnName;
      }

      public string GetColumnName()
      {
        return m_ColumnName;
      }
    }


  /* ColumnValueList class stores and retrieves a list of column values to be inserted in specified columns of a particular table
   * setColumnValue() adds the column value to a list.
   * getColumnValue returns a list of column values to be inserted.
   * @param lis is a list of column values
   */
  public class ColumnValueList
    {
      private List<ColumnValue> lis = new List<ColumnValue>();
      
      public void SetColumnValue(ColumnValue colVal)
      {
        lis.Add(colVal);
      }

      public List<ColumnValue> GetColumnValue()
      {
        return lis;
      }      
    }

  public class SelectRows : Statement
  {
    private SelectRowTableColList m_SelectRowTableColList;
    private Table m_tableName;
    private WhereList m_WhereList;
    private OrderByList m_OrderByList;
    private LimitRange m_LimitRange;
    private bool m_OrderByFlag;
    private bool m_WhereListFlag;
    private bool m_LimitRangeFlag;

    public void SetWhereList(WhereList whereList)
    {
      m_WhereList = whereList;
    }

    public WhereList GetWhereList()
    {
      return m_WhereList;
    }

    public void SetOrderByList(OrderByList orderByList)
    {
      m_OrderByList = orderByList;
    }

    public OrderByList GetOrderByList()
    {
      return m_OrderByList;
    }

    public void SetLimitRangeFlag(bool flag)
    {
      m_LimitRangeFlag = flag;
    }

    public bool GetLimitRangeFlag()
    {
      return m_LimitRangeFlag;
    }

    public void SetLimitRange(LimitRange limitRange)
    {
      m_LimitRange = limitRange;
    }

    public LimitRange GetLimitRange()
    {
      return m_LimitRange;
    }

    public void SetOrderByFlag(bool flag)
    {
      m_OrderByFlag = flag;
    }


    public bool GetOrderByFlag()
    {
      return m_OrderByFlag;
    }

    public void SetWhereListFlag(bool flag)
    {
      m_WhereListFlag = flag;
    }

    public bool GetWhereListFlag()
    {
      return m_WhereListFlag;
    }

    public void SetSelectRowTableColList(SelectRowTableColList srtclObj)
    {
      m_SelectRowTableColList = srtclObj;
    }

    public SelectRowTableColList GetSelectRowTableColList()
    {
      return m_SelectRowTableColList;
    }

    public void SetTableName(Table tableName)
    {
      m_tableName = tableName;
    }
    public string GetTableName()
    {
      return m_tableName.GetTableName();
    }
  }

  public class SelectRowTableColList
    {
      private SelectRowColumnType m_SelectRowColumnType;
      private SelectColumnList m_TableColumnList;
      private CountRows m_CountRows;

      public void SetCountRows(CountRows countRows)
      {
        m_CountRows = countRows;
      }

      public CountRows GetCountRows()
      {
        return m_CountRows;
      }

      public void SetTableColumnList(SelectColumnList colList)
      {
        m_TableColumnList = colList;
      }

      public SelectColumnList GetTableColumnList()
      {
        return m_TableColumnList;
      }

      public void SetSelectRowsColumnType(SelectRowColumnType type)
      {
        m_SelectRowColumnType = type;
      }

      public SelectRowColumnType GetSelectRowColumnType()
      {
        return m_SelectRowColumnType;
      }

    }

  public class WhereList
    {
      private SubWhereList m_SubWhereList;

      public void SetSubWhereList(SubWhereList subWhereList)
      {
        m_SubWhereList = subWhereList;
      }

      public SubWhereList GetSubWhereList()
      {
        return m_SubWhereList;
      }
    }

  public class SubWhereList
    {
      private List<WhereEntry> m_WhereEntryList = new List<WhereEntry>();

      public void AddWhereEntryList(WhereEntry whereEntry)
      {
        m_WhereEntryList.Add(whereEntry);
      }

      public List<WhereEntry> GetWhereEntryList()
      {
        return m_WhereEntryList;
      }

    }

  public class WhereEntry
    {
      private string m_ColumnName;
      private ColumnValue m_ColumnValue;
      private ComparisonOperatorType m_ComparisonOperatorType;

      public void SetComparisonOperatorType(ComparisonOperatorType opType)
      {
        m_ComparisonOperatorType = opType;
      }

      public ComparisonOperatorType GetComparisonOperatorType()
      {
        return m_ComparisonOperatorType;
      }

      public void SetColumnName(string colName)
      {
        m_ColumnName = colName;
      }

      public string GetColumnName()
      {
        return m_ColumnName;
      }

      public void SetColumnValue(ColumnValue colVal)
      {
        m_ColumnValue = colVal;
      }

      public ColumnValue GetColumnValue()
      {
        return m_ColumnValue;
      }
    }

  public enum ColValueType { STRING, INTEGER, DOUBLE };

  public class ColumnValue
    {
      private ColValueType m_ValueType;
      private int m_IntColValue;
      private string m_StrColValue;
      private double m_DoubleColValue;

      public void SetColumnValueType(ColValueType type)
      {
        m_ValueType = type;
      }

      public ColValueType GetColumnValueType()
      {
        return m_ValueType;
      }

      public void SetIntColumnValue(string intVal)
      {
        m_IntColValue = Convert.ToInt32(intVal);
      }

      public int GetIntColumnValue()
      {
        return m_IntColValue;
      }

      public void SetStringColumnValue(string stringVal)
      {
        m_StrColValue = stringVal;
      }

      public string GetStringColumnValue()
      {
        return m_StrColValue;
      }

      public void SetDoubleColumnValue(string DoubleVal)
      {
        m_DoubleColValue = Convert.ToDouble(DoubleVal);
      }

      public double GetDoubleColumnValue()
      {
        return m_DoubleColValue;
      }
    }

  /*InsertRow class is responsible for inserting a row into a table.
   * setTableName() sets the table name on which insert operation is to be performed.
   * getTableName() gets the table name on which the insert operation is to be performed.
   * setValueList() sets the column values that must be inserted.
   * getValueList() gets the column values that must are to be inserted.
   * setList() sets the columns on which the column values must be inserted i.e basically the column names.
   * getList() gets the columns on which the column values must be inserted i.e basically the column names.
   * @param m_TableName is string used to set and get table name.
   * @param lis is list of column values.
   * @param m_ColumnList is a list of column names.
   */
  public class InsertRow : Statement
  {
    string m_TableName;
    List<ColumnValue> lis = new List<ColumnValue>();
    List<string> m_ColumnList = new List<string>();
    
    public void SetTableName(string m_TableName)
    {
      this.m_TableName = m_TableName;
    }

    public string GetTableName()
    {
      return m_TableName;
    }

    public void SetValueList(List<ColumnValue> colVal)
    {
      lis = colVal;
    }

    public List<ColumnValue> GetValueList()
    {
      return lis;
    }

    public void SetList(List<string> m_ColumnList)
    {
      this.m_ColumnList = m_ColumnList;
    }

    public List<string> GetList()
    {
      return m_ColumnList;
    }
  }

  public class OrderByList
  {
    private SubOrderByList m_SubOrderByList;

    public void SetSubOrderByList(SubOrderByList subOrderByList)
    {
      m_SubOrderByList = subOrderByList;
    }

    public SubOrderByList GetSubOrderBylist()
    {
      return m_SubOrderByList;
    }
  }

  public class SubOrderByList
  {
    private List<OrderByEntry> m_OrderByEntryList = new List<OrderByEntry>();

    public void AddOrderByEntryList(OrderByEntry orderByEntry)
    {
      m_OrderByEntryList.Add(orderByEntry);
    }

    public List<OrderByEntry> GetOrderByEntryList()
    {
      return m_OrderByEntryList;
    }
  }

  public class OrderByEntry
  {
    private string m_ColumnName;
    private string m_OrderByType;

    public void SetColumnName(string columnName)
    {
      m_ColumnName = columnName;
    }

    public string GetColumnName()
    {
      return m_ColumnName;
    }

    public void SetOrderByType(string orderByType)
    {
      m_OrderByType = orderByType;
    }

    public string GetOrderByType()
    {
      return m_OrderByType;
    }

  }

  public class SelectColumnList
  {
    List<string> m_ColList = new List<string>();
    public void AddToList(string t)
    {
      m_ColList.Add(t);
    }
    public List<string> GetList()
    {
      return m_ColList;
    }
  }

  public class LimitRange
  {
    private int m_StartIndex;
    private int m_Count;

    public void SetStartIndex(string startIndex)
    {
      m_StartIndex = Convert.ToInt32(startIndex);
    }

    public int GetStartIndex()
    {
      return m_StartIndex;
    }

    public void SetCount(string count)
    {
      m_Count = Convert.ToInt32(count);
    }

    public int GetCount()
    {
      return m_Count;
    }

  }

  public class CountRows
  {
    private bool m_CountAllRowsFlag;
    private string m_ColumnName;

    public bool GetCountAllRowsFlag()
    {
      return m_CountAllRowsFlag;
    }

    public void SetCountAllRowsFlag(bool flag)
    {
      m_CountAllRowsFlag = flag;
    }

    public void SetColumnName(string colName)
    {
      m_ColumnName = colName;
    }

    public string GetColumnName()
    {
      return m_ColumnName;
    }
  }

  public enum SelectRowColumnType
  {
    ALL_COLUMNS, SPECIFIC_COLUMNS, COUNT_ROWS
  };

  public class UpdateRows : Statement
  {
    private Table m_TableName;
    private SetList m_SetList;
    private WhereList m_WhereList;
    private bool m_WhereListFlag;

    public void SetTableName(Table tableName)
    {
      m_TableName = tableName;
    }

    public Table GetTableName()
    {
      return m_TableName;
    }

    public void SetSetList(SetList setList)
    {
      m_SetList = setList;
    }

    public SetList GetSetList()
    {
      return m_SetList;
    }

    public void SetWhereList(WhereList whereList)
    {
      m_WhereList = whereList;
    }

    public WhereList GetWhereList()
    {
      return m_WhereList;
    }

    public void SetWhereListFlag(bool flag)
    {
      m_WhereListFlag = flag;
    }

    public bool GetWhereListFlag()
    {
      return m_WhereListFlag;
    }
  }

  public class SetList
  {
    private List<SetEntry> m_SetEntryList = new List<SetEntry>();

    public void AddSetEntryList(SetEntry setEntry)
    {
      m_SetEntryList.Add(setEntry);
    }

    public List<SetEntry> GetSetEntryList()
    {
      return m_SetEntryList;
    }

  }

  public class SetEntry
  {
    private string m_ColumnName;
    private ColumnValue m_ColumnValue;

    public void SetColumnName(string colName)
    {
      m_ColumnName = colName;
    }

    public string GetColumnName()
    {
      return m_ColumnName;
    }

    public void SetColumnValue(ColumnValue colVal)
    {
      m_ColumnValue = colVal;
    }

    public ColumnValue GetColumnValue()
    {
      return m_ColumnValue;
    }
  }

  public class DeleteRows : Statement
  {
    private Table m_TableName;
    private WhereList m_WhereList;
    private bool m_WhereListFlag;

    public void SetTableName(Table tableName)
    {
      m_TableName = tableName;
    }

    public Table GetTableName()
    {
      return m_TableName;
    }

    public void SetWhereList(WhereList whereList)
    {
      m_WhereList = whereList;
    }

    public WhereList GetWhereList()
    {
      return m_WhereList;
    }

    public void SetWhereListFlag(bool flag)
    {
      m_WhereListFlag = flag;
    }

    public bool GetWhereListFlag()
    {
      return m_WhereListFlag;
    }
  }

  public enum ComparisonOperatorType
  {
    EQUALITY, LESS_THAN, GREATER_THAN, LESS_THAN_EQUAL, GREATER_THAN_EQUAL
  }

  /* RenameTable class is responsible for changing a table from old name to given name.
   * setOldTableName() stores the value of the old table name.
   * setNewTableName() stores the value of the new table name.
   * getOldTableName() retrieves the old table name.
   * getNewTableName() retrieves the new table name.
   * @param m_OldTableName used to set and get old table name.
   * @param m_NewTableName used to set and get new table name.
   */
    public class RenameTable : Statement
    {
      string m_OldTableName;
      string m_NewTableName;

      public void SetOldTableName(string OldTableName)
      {
        this.m_OldTableName = OldTableName;
      }
      public void SetNewTableName(string NewTableName)
      {
        this.m_NewTableName = NewTableName;
      }
      public string GetOldTableName()
      {
        return m_OldTableName;
      }
      public string GetNewTableName()
      {
        return m_NewTableName;
      }
 
    }

    /* RenameColumn class is responsible for changing a column from old name to a given name.
     * setoldColumnName() stores the old column name.
     * setNewColumnName() stores the new column name.
     * getOldColumnName() retrieves the old column name.
     * getNewColumnName() retrieves the new column name.
     * setTableName() stores the table name in order to select the table on which the operation shall be performed.
     * getTableName() retrieves the table name in which the specified column name must be changed from old name to new one.
     * @param m_OldColumnName used to set and get old column name.
     * @param m_NewColumnName used to set and get new column name.
     * @param m_TableName used to set and get table name.
     */
    public class RenameColumn : Statement
    {

      string m_OldColumnName;
      string m_NewColumnName;
      string m_TableName;

      public void SetOldColumnName(string OldColumnName)
      {
        this.m_OldColumnName = OldColumnName;
      }
      public void SetNewColumnName(string NewColumnName)
      {
        this.m_NewColumnName = NewColumnName;
      }
      public string GetOldColumnName()
      {
        return m_OldColumnName;
      }
      public string GetNewColumnName()
      {
        return m_NewColumnName;
      }

      public void SetTableName(string tableName)
      {
        this.m_TableName = tableName;
      }

      public string GetTableName()
      {
        return m_TableName;
      }

    }
}


 