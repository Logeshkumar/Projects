////////////////////////////////////////////////////////////////////////////////
// DataBindingHelpers.cs - Class used to support functionalities of the       //
//                                                           Desktop GUI      //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Anjali Banka, Fall 2011, Syracuse University                 //
//               abanka@syr.edu                                               //
////////////////////////////////////////////////////////////////////////////////

/*
Module Operations: 
==================
This module is responsible to define various properties and functions 
 * which are created to support the functionality of the DesktopGUI WPF package.

 
Public Interface
=================

 
Build Process
================
 * 
 * 
 Required Files:
===================
 * None


Maintenance History:
====================
ver 1.0 : November 03 2011

*/

using System.Collections.Generic;

namespace edu.syr.cse784.eskimodb.ClientGUI
{
  /// <summary>
  /// Helper class for the desktopGUI. 
  /// </summary>
  class DesktopGUIHelper : List<string>
  {

    /// <summary>
    /// Constructor of the class
    /// </summary>
    public DesktopGUIHelper()
    {
      AddDataTypesToDataGrid();
    }

    #region properties

    private string m_ColumnName, m_ColumnType;
    private bool m_PrimaryKey;

    /// <summary>
    /// Column Name of a new column in a  new table 
    /// </summary>
    public string ColumnName
    {
      get
      {
        return m_ColumnName;
      }
      set
      {
        if (m_ColumnName != value)
        {
          m_ColumnName = value;
        }
      }
    }

    /// <summary>
    /// Column Type of the new column in a new table
    /// </summary>
    public string ColumnType
    {
      get
      {
        return m_ColumnType;
      }
      set
      {
        if (m_ColumnType != value)
        {
          m_ColumnType = value;
        }
      }
    }

    public bool PrimaryKey
    {
      get
      {
        return m_PrimaryKey;
      }
      set
      {
        if (m_PrimaryKey != value)
        {
          m_PrimaryKey = value;
        }
      }
    }

    #endregion

    /// <summary>
    /// Used to add the datatypes to the combobox present in the datagrid
    /// </summary>
    private void AddDataTypesToDataGrid()
    {
      string[] m_DataTypes = new string[] { "CHAR", "SHORT", "INT", "LONG", "BIGLONG", "FLOAT", "DOUBLE", "VARCHAR(255)" };
      foreach (string m_Item in m_DataTypes)
      {
        this.Add(m_Item);
      }
    }


  }
}
