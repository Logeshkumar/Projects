/////////////////////////////////////////////////////////////////////////////////////////////
//  ITableServer.cs:               Interface for TableServer                               //
//  Language:                      C#, .Net Framework 4.0      				                     //
//  Platform:                      Windows 7								                               //
//  Application:                   EskimoDB - RootServer                                   //
/////////////////////////////////////////////////////////////////////////////////////////////

/*
 * Module Operations:
 * =================
 * This module is responsible for defining the function decoration or signatures that the TableServer will implement.
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

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  public interface ITableServer
  {
    /*
     * CreateDatabase() creates a new database, with the given name.
     * @param databaseName is the name of the database that should be created.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */
    TableResponse CreateDatabase(string databaseName);

    /*
     * CreateTable() creates a table in the given database with the given tablename 
     * @param databaseName is the name of the database in which the table must be created.
     * @param tableName is the name of the table, that should be created.
     * @param columnData refers to a dictionary with column name as Key and value as a bool which indicates whether the column is Index or not 
     * (a true refers to presence of PRIMARY KEY or INDEX and if neither of them are present, it refers to a false).
     * @param columnType is a list of column types, so each column should be created with the specified type in the list respectively.
     * So the first element in the uniqueName list is the unique key of the first element in the columnName list and its type is the 
     * first element in the columntype List and similarly the second and so on.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */
    TableResponse CreateTable(string databaseName,string tableName, Dictionary<string,bool> columnData,List<string> columnType);
    
    /*
     * DeleteTable() deletes thee specified table in the given database
     * @param databaseName refers to the database from which the table must be deleted.
     * @param tableName refers to the table name which must be deleted
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */    
    TableResponse DeleteTable(string databaseName, string tableName);

    /*
     * AddColumn() adds a column to the given table in the corresponding database with the specified details.
     * @param databaseName refers to the database in which the add operation must be done.
     * @param tableName refers to the table in which the column must be added.
     * @param uniqueKey refers to true if the column is Indexed or Primary Key and false if it is not Indexed or a Primary Key.
     * @param columnName refers to the name of the column.
     * @param columnType refers to the type of the column.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */
    TableResponse AddColumn(string databaseName, string tableName, bool uniqueKey, string columnName, string columnType);

    /*
     * DeleteColumn() deletes a column from the given table in the corresponding database according to the column name specified.
     * @param databaseName refers to the database in which the delete operation must be performed.
     * @param tablename refers to the table in which the specified column should be deleted.
     * @param columnName refers to the column name which must be removed from the table.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */    
    TableResponse DeleteColumn(string databaseName, string tableName, string columnName);

    /*
     * RenameTable() changes the name of a table, given the name of the existing table and the new table name.
     * @param databaseName refers to the database in which the rename table operation must be performed.
     * @param oldTableName refers to the name of the table existing in the database i.e. the name of table which should be renamed.
     * @param newTableName refers to the new table name.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */    
    TableResponse RenameTable(string databaseName, string oldTableName, string newTableName);

    /*
     * RenameColumn() changes the name of a column in the pspecified table, given the name of the existing column and the new column name.
     * @param databaseName refers to the database in which the rename column operation must be performed.
     * @param oldColumnName refers to the name of the column existing in the tablei.e the name of the column which should be renamed.
     * @param newColumnName refers to the new column name.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */    
    TableResponse RenameColumn(string databaseName, string tableName, string oldColumnName, string newColumnName);

    /*
     * EmptyTable() empties the data in the given table but does not deltes the table from the database.
     * @param databaseName refers to the name of the database in which the empty table operation must be performed.
     * @param tableName refers to the name of the table that must be emptied
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */    
    TableResponse EmptyTable(string databaseName, string tableName);

    /*
     * DeleteDatabase() deletes the specified database.
     * @param databasename refers to the name of the database that must be deleted.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */    
    TableResponse DeleteDatabase(string databaseName);

    /* 
     * InsertRow() inserts row into the given table in the corresponding column with respective values.
     * @param databaseName refers to the databse in which the insert row operation must be performed.
     * @param tablename refers to the name of the table on which the insert operation is to be performed.
     * @columnName refers to a list of column names in the table.
     * @columnValue refers a ArrayList which holds the corresponding values that are to be inserted in respective columns.
     * @returns a instance of TableResponse holding a message, whether the action was successfull or failure.
     */
    TableResponse InsertRow(string databaseName, string tableName, List<string> columnName, ArrayList columnValue);
    
    TableResponse SelectRow(string database, string tableName, List<string> selectColumns, string countColumn, 
      
      List<TernaryAssociative<string,string,string>> whereList, List<KeyValuePair<string, string>> orderByColumns, int limitStart, int limitCount); 
                            
    /*
     * @returns the DB structure.
     */
    Dictionary<string, List<string>> GetDBInfo();

    //TableResponse DeleteRows(string databaseName, string tableName, List<TernaryAssociative<string, string, string>> whereList);
  }  
}
