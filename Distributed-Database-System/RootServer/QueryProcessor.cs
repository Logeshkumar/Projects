/////////////////////////////////////////////////////////////////////////////////////////////
//  QueryProcessor.cs:             Responsible for organising the data for the TableServer //
//  Language:                      C#, .Net Framework 4.0      				                     //
//  Platform:                      Windows 7								                               //
//  Application:                   EskimoDB - RootServer                                   //
/////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Module Operations:
 * =================
 * This module is responsible for organising the data fetched from EskimoDb query
 * in a way to send the corresponding data to the TableServer according to its Interface.
 * /
/*
Maintainence History:
=====================
ver 1.0 : 02 November 2011
- first release
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using edu.syr.cse784.eskimodb.sharedobjs;


namespace edu.syr.cse784.eskimodb.rootserver
{
  class QueryProcessor
  {
    Request m_Request = null;
    Object[] m_Parameters = null;
    string m_token = "";
    ClientMap m_ClientMap = null;

    public QueryProcessor(ClientMap clientMap)
    {
      m_ClientMap = clientMap;  
    }

    public Request GetRequestObject(string token,Statement queryObj,IRootServerCallback callback)
    {
      m_token = token;
      string queryType = queryObj.GetStatementType().ToString();
      try
      {
        switch (queryType)
        {
          case "CREATE_DB":
          CreateDb(queryObj,callback);
            break;
          case "CREATE_TABLE":
          CreateTable(queryObj, callback);
            break;
          case "MOD_TABLE":
          ModifyTable(queryObj, callback);
            break;
          case "DELETE_DB":
          DeleteDb(queryObj, callback);
            break;
          case "DELETE_TABLE":
          DeleteTable(queryObj, callback);
            break;
          case "EMPTY_TABLE":
          EmptyTable(queryObj, callback);
            break;
          case "INSERT_ROW":
          InsertRow(queryObj, callback);
            break;
          case "SELECT_ROW":
          SelectRow(queryObj, callback);
            break;
          case "UPDATE_ROW":
          UpdateRow(queryObj, callback);
            break;
          case "DELETE_ROWS":
          DeleteRows(queryObj, callback);
            break;
          case "SELECT_DB":
          SelectDb(queryObj, callback);
            break;
          case "RENAME_TABLE":
          RenameTable(queryObj, callback);
            break;
          case "RENAME_COLUMN":
          RenameColumn(queryObj, callback);
            break;
          default :
            Console.WriteLine("None of the query type matched");
            break;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Query Processor:" + ex.Message);
      }
      return m_Request;
    }

    private string GetDatabaseName(string token)
    { 
      string ret = "";
      if (m_ClientMap.GetDatabaseName(token, out ret))
        return ret;
      else
      {
        ret = "default";
        return ret;
      }
    }

    private void CreateDb(Statement queryObj, IRootServerCallback callback)
    {
      try
      {
        m_Request = new Request();
        m_Parameters = new Object[1];
      m_Parameters[0] = ((CreateDB)queryObj).GetDatabaseName(); 
      
      m_Request.SetCallingMethod("CreateDatabase");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
      }
      catch (Exception ex)
      {
        Console.WriteLine("createdb: " + ex.Message);
      }
    }

    private void CreateTable(Statement queryObj, IRootServerCallback callback)
    {
      List<TableColumn> columnList = new List<TableColumn>();
      Dictionary<string, bool> columnData = new Dictionary<string, bool>();
      List<bool> uniqueKey = new List<bool>();
      List<string> columnName = new List<string>();
      List<string> columnType = new List<string>();
      string tableName = ((CreateTable)queryObj).GetTableName();
      columnList = ((CreateTable)queryObj).GetList();
      foreach(TableColumn column in columnList)
      {
        if((column.GetUniqueKey() == "PRIMARY KEY" ||(column.GetUniqueKey() == "primary key") || (column.GetUniqueKey() =="INDEX") || (column.GetUniqueKey() =="index")))
        {
          columnData.Add(column.GetColumnName(), true);
        }
        else
        {
          columnData.Add(column.GetColumnName(), false);
        }
        if (column.GetVarType() == "VARCHAR")
        {
          string range = column.GetVarRange();
          columnType.Add("VARCHAR(" + range + ")");
        }
        else
        {
          columnType.Add(column.GetVarType());
        }
      }
      
      m_Request = new Request();
      m_Parameters = new Object[5];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = tableName;
      m_Parameters[2] = uniqueKey;
      m_Parameters[3] = columnName;
      m_Parameters[4] = columnType;

      m_Request.SetCallingMethod("CreateTable");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);

    }

    public void ModifyTable(Statement queryObj,IRootServerCallback callback)
    {
        m_Request = new Request();
               
        ModifyTab obj = (ModifyTab)queryObj;

        if (obj.GetTyp() == "ADD")
        {
          AddColumn columnData = obj.GetAddColumnData();
          m_Parameters = new Object[5];
          m_Parameters[0] = GetDatabaseName(m_token);
          m_Parameters[1] = columnData.GetTableName();
               
          if (columnData.GetColumnData().GetUniqueKey() == null)
            m_Parameters[2] = false;
          else
            m_Parameters[2] = true;
          
          m_Parameters[3] = columnData.GetColumnData().GetColumnName();

          if (columnData.GetColumnData().GetVarType() == "VARCHAR")
            m_Parameters[4] = "VARCHAR" + "(" + columnData.GetColumnData().GetVarRange() + ")";
          else
            m_Parameters[4] = columnData.GetColumnData().GetVarType();
          m_Request.SetCallingMethod("AddColumn");
        }
        else
        {
          DeleteColumn columnData = obj.GetDelcolumnData();
          m_Parameters = new Object[3];
          m_Parameters[0] = GetDatabaseName(m_token);
          m_Parameters[1] = columnData.GetTableName();
          m_Parameters[2] = columnData.GetColumnData();
          m_Request.SetCallingMethod("DeleteColumn");
        }

        m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
        m_Request.SetRootServerCallback(callback);
        m_Request.SetMethodParameters(m_Parameters);
    }

    public void DeleteDb(Statement queryObj,IRootServerCallback callback)
    {
      m_Request = new Request();
      m_Parameters = new Object[1];
      m_Parameters[0] = ((DeleteDB)queryObj).GetDatabaseName();
      
      m_Request.SetCallingMethod("DeleteDatabase");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
    }
    public void DeleteTable(Statement queryObj,IRootServerCallback callback)
    {
      m_Request = new Request();
      m_Parameters = new Object[2];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = ((DeleteTable)queryObj).GetTableName();

      m_Request.SetCallingMethod("DeleteTable");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
      
    }
    public void EmptyTable(Statement queryObj, IRootServerCallback callback)
    {
      m_Request = new Request();
      m_Parameters = new Object[2];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = ((EmptyTable)queryObj).GetTableName();

      m_Request.SetCallingMethod("EmptyTable");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
    }

    public void RenameTable(Statement queryObj, IRootServerCallback callback)
    {
      m_Request = new Request();
      m_Parameters = new Object[3];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = ((RenameTable)queryObj).GetOldTableName();
      m_Parameters[2] = ((RenameTable)queryObj).GetNewTableName();

      m_Request.SetCallingMethod("RenameTable");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
      
    }

    public void RenameColumn(Statement queryObj, IRootServerCallback callback)
    {
      m_Request = new Request();
      m_Parameters = new Object[4];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = ((RenameColumn)queryObj).GetTableName();
      m_Parameters[2] = ((RenameColumn)queryObj).GetOldColumnName();
      m_Parameters[3] = ((RenameColumn)queryObj).GetNewColumnName();

      m_Request.SetCallingMethod("RenameColumn");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);

    }

    public void InsertRow(Statement queryObj, IRootServerCallback callback)
    {
      
      InsertRow insertObj = (InsertRow)queryObj;
      List<string> ColumnList = new List<string>();
      ArrayList ColumnValueList = new ArrayList();
  
      foreach (ColumnValue val in insertObj.GetValueList())
      {
        if (val.GetColumnValueType() == ColValueType.STRING)
        {
          ColumnValueList.Add(val.GetStringColumnValue());
        }
        else if (val.GetColumnValueType() == ColValueType.INTEGER)
        {
          ColumnValueList.Add(val.GetIntColumnValue());
        }
        else if (val.GetColumnValueType() == ColValueType.DOUBLE)
        {
          ColumnValueList.Add(val.GetDoubleColumnValue());
        }
      }
      
      m_Request = new Request();
      m_Parameters = new Object[4];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = insertObj.GetTableName();
      m_Parameters[2] = insertObj.GetList();
      m_Parameters[3] = ColumnValueList;

      m_Request.SetCallingMethod("InsertRow");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);

    }


    public void SelectRow(Statement queryObj, IRootServerCallback callback)
    {
      SelectRows selectRows = (SelectRows)queryObj;
      List<TernaryAssociative<string, string, string>> whereList = new List<TernaryAssociative<string, string, string>>();
      List<KeyValuePair<string, string>> orderByColumns = new List<KeyValuePair<string, string>>();

      m_Request = new Request();
      m_Parameters = new Object[8];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = selectRows.GetTableName();
      if(selectRows.GetSelectRowTableColList().GetSelectRowColumnType() == SelectRowColumnType.ALL_COLUMNS)
      {
        m_Parameters[2] = new List<string>();
        m_Parameters[3] = "";
      }
      else if (selectRows.GetSelectRowTableColList().GetSelectRowColumnType() == SelectRowColumnType.SPECIFIC_COLUMNS)
      {
        m_Parameters[2] = selectRows.GetSelectRowTableColList().GetTableColumnList().GetList();
        m_Parameters[3] = "";
      }
      else if (selectRows.GetSelectRowTableColList().GetSelectRowColumnType() == SelectRowColumnType.COUNT_ROWS)
      {
        m_Parameters[2] = new List<string>();
        if(selectRows.GetSelectRowTableColList().GetCountRows().GetCountAllRowsFlag() == true)
          m_Parameters[3] = "*";
        else
          m_Parameters[3] = selectRows.GetSelectRowTableColList().GetCountRows().GetColumnName();
      }
      if (selectRows.GetWhereListFlag() == true)
      {
        List<WhereEntry> whereEntries = selectRows.GetWhereList().GetSubWhereList().GetWhereEntryList();
        foreach (WhereEntry whereEntry in whereEntries)
        {
          TernaryAssociative<string, string, string> item = new TernaryAssociative<string, string, string>();
          item.First = whereEntry.GetColumnName();
          item.Second = whereEntry.GetComparisonOperatorType().ToString();

          if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          {
            item.Third = whereEntry.GetColumnValue().GetStringColumnValue();
          }
          else if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          {
            item.Third = whereEntry.GetColumnValue().GetIntColumnValue().ToString();
          }
          else if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          {
            item.Third = whereEntry.GetColumnValue().GetDoubleColumnValue().ToString();
          }
          whereList.Add(item);    
        }
      }
      m_Parameters[4] = whereList;
      if (selectRows.GetOrderByFlag() == true)
      {
        List<OrderByEntry> orderByEntries = selectRows.GetOrderByList().GetSubOrderBylist().GetOrderByEntryList();
        foreach (OrderByEntry orderByEntry in orderByEntries)
        {
          KeyValuePair<string, string> item = new KeyValuePair<string, string>(orderByEntry.GetColumnName(),orderByEntry.GetOrderByType());
          orderByColumns.Add(item);
        }
      }
      m_Parameters[5] = orderByColumns;
      if (selectRows.GetLimitRangeFlag() == true)
      {
        m_Parameters[6] = selectRows.GetLimitRange().GetStartIndex();
        m_Parameters[7] = selectRows.GetLimitRange().GetCount();
      }
      else
      {
        m_Parameters[6] = -1;
        m_Parameters[7] = -1;
      }
      
      m_Request.SetCallingMethod("SelectRow");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
      
    }


    public void UpdateRow(Statement queryObj, IRootServerCallback callback)
    {
      UpdateRows updateRows = (UpdateRows)queryObj;
      List<TernaryAssociative<string, string, string>> whereList = new List<TernaryAssociative<string, string, string>>();
      List<KeyValuePair<string, string>> setList = new List<KeyValuePair<string, string>>();

      m_Request = new Request();
      m_Parameters = new Object[4];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = updateRows.GetTableName();

      List<SetEntry> setEntries = updateRows.GetSetList().GetSetEntryList();
      foreach (SetEntry setEntry in setEntries)
      {
        if (setEntry.GetColumnValue().GetColumnValueType() == ColValueType.STRING)
        {
          KeyValuePair<string, string> item = new KeyValuePair<string, string>(setEntry.GetColumnName(), setEntry.GetColumnValue().GetStringColumnValue());
          setList.Add(item);  
        }
        else if (setEntry.GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
        {
          KeyValuePair<string, string> item = new KeyValuePair<string, string>(setEntry.GetColumnName(), setEntry.GetColumnValue().GetIntColumnValue().ToString());
          setList.Add(item);  
        }
        else if (setEntry.GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
        {
          KeyValuePair<string, string> item = new KeyValuePair<string, string>(setEntry.GetColumnName(), setEntry.GetColumnValue().GetDoubleColumnValue().ToString());
          setList.Add(item);
        }
      }
      m_Parameters[2] = setList;
      
      if(updateRows.GetWhereListFlag() == true)
      {
        List<WhereEntry> whereEntries = updateRows.GetWhereList().GetSubWhereList().GetWhereEntryList();
        foreach (WhereEntry whereEntry in whereEntries)
        {
          TernaryAssociative<string, string, string> item = new TernaryAssociative<string, string, string>();
          item.First = whereEntry.GetColumnName();
          item.Second = whereEntry.GetComparisonOperatorType().ToString();

          if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          {
            item.Third = whereEntry.GetColumnValue().GetStringColumnValue();
          }
          else if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          {
            item.Third = whereEntry.GetColumnValue().GetIntColumnValue().ToString();
          }
          else if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          {
            item.Third = whereEntry.GetColumnValue().GetDoubleColumnValue().ToString();
          }
          whereList.Add(item);    
        }
      }
      m_Parameters[3] = whereList; 

      m_Request.SetCallingMethod("UpdateRow");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);    
    }

    public void DeleteRows(Statement queryObj, IRootServerCallback callback)
    {
      DeleteRows deleteRows = (DeleteRows)queryObj;
      List<TernaryAssociative<string, string, string>> whereList = new List<TernaryAssociative<string, string, string>>();
      
      m_Request = new Request();
      m_Parameters = new Object[3];
      m_Parameters[0] = GetDatabaseName(m_token);
      m_Parameters[1] = deleteRows.GetTableName();

      if (deleteRows.GetWhereListFlag() == true)
      {
        List<WhereEntry> whereEntries = deleteRows.GetWhereList().GetSubWhereList().GetWhereEntryList();
        foreach (WhereEntry whereEntry in whereEntries)
        {
          TernaryAssociative<string, string, string> item = new TernaryAssociative<string, string, string>();
          item.First = whereEntry.GetColumnName();
          item.Second = whereEntry.GetComparisonOperatorType().ToString();

          if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.STRING)
          {
            item.Third = whereEntry.GetColumnValue().GetStringColumnValue();
          }
          else if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.INTEGER)
          {
            item.Third = whereEntry.GetColumnValue().GetIntColumnValue().ToString();
          }
          else if (whereEntry.GetColumnValue().GetColumnValueType() == ColValueType.DOUBLE)
          {
            item.Third = whereEntry.GetColumnValue().GetDoubleColumnValue().ToString();
          }
          whereList.Add(item);
        }
      }
      m_Parameters[2] = whereList;
      
      m_Request.SetCallingMethod("DeleteRow");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
    }

    public void SelectDb(Statement queryObj, IRootServerCallback callback)
    {
      SelectDB selectdb = (SelectDB)queryObj;
      
      m_Request = new Request();
      m_Parameters = new Object[1];
      m_Parameters[0] = selectdb.GetDatabaseName();
      
      m_Request.SetCallingMethod("SelectDatabase");
      m_Request.SetRequestType(RequestType.EXECUTE_QUERY);
      m_Request.SetRootServerCallback(callback);
      m_Request.SetMethodParameters(m_Parameters);
      
    }
  }
}
