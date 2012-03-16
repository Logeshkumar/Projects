/////////////////////////////////////////////////////////////////////////////////
// DesktopGUI.xaml.cs - The desktop Gui application which uses the client api  //
// version 1.0                                                                 //
// Language:     C# 4.0                                                        //
// Platform:     Windows 7                                                     //
// Application:  CSE784 EskimoDB                                               //
// Author:       Indranil Mitra (imitra@syr.edu), Anjali Banka (abanka@syr.edu)//
//               Fall 2011, Syracuse University                                //
//                                                                             //
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using edu.syr.cse784.eskimodb.clientapi;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.ClientGUI
{
  /// <summary>
  /// Interaction logic for DesktopGUI.xaml
  /// </summary>
  public partial class DesktopGUI : Window
  {
    #region properties

    public string LoginToken { get; set; }

    public string m_FinalNewTableQuery { get; set; }
    public bool UserLevelChanged { get; set; }
    public bool CurrentUserIsAdmin { get; set; }
    public string RootServerUrl { get; set; }
    public string AuthServerUrl { get; set; }

    DesktopGUIHelper CurrentSelectedRow
    {
      get
      {
        return m_CurrentSelectedRow;
      }
      set
      {
        if (m_CurrentSelectedRow != value)
        {
          m_CurrentSelectedRow = value;
        }
      }

    }

    #endregion

    #region Data Members

    string m_NewTableName = string.Empty;
    ClientAPI m_clientapi;
    List<DesktopGUIHelper> m_NewTableContents;
    CheckBox m_CbPrimary = null;
    private DesktopGUIHelper m_CurrentSelectedRow;

    #endregion

    #region Constructor

    public DesktopGUI(string intoken, string rootUrl, string authUrl)
    {
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      InitializeComponent();
      RootServerUrl = rootUrl;
      AuthServerUrl = authUrl;
      m_clientapi = new ClientAPI();

      Logger.LogWrite("Setting the root server url for desktop gui to " + RootServerUrl);
      m_clientapi.SetRootServer(RootServerUrl);
      Logger.LogWrite("Setting the auth server url for desktop gui to " + AuthServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      Logger.LogWrite("Configuring the client api");
      m_clientapi.ConfigClient();

      LoginToken = intoken;
      CurrentUserIsAdmin = m_clientapi.IsAdmin(LoginToken);
      if (CurrentUserIsAdmin)
      {
        Logger.LogWrite("User is admin");
        m_LblLevel.Visibility = System.Windows.Visibility.Visible;
        m_CmbUserPrivilege.Visibility = System.Windows.Visibility.Visible;
      }
      else
      {
        Logger.LogWrite("User logged in not as admin");
        m_LblLevel.Visibility = System.Windows.Visibility.Hidden;
        m_CmbUserPrivilege.Visibility = System.Windows.Visibility.Hidden;

      }
    }

    #endregion Constructor

    #region AccountManagement Tab


    #region AccountManagement Tab - Properties

    #endregion AccountManagement Tab - Properties


    #region AccountManagement Tab - Methods

    private void AccountMgmtTabLoad()
    {
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();

      this.cb_UserAccountsLoad();

      bn_New.IsEnabled = true;
      bn_Save.IsEnabled = true;
    }

    private void cb_UserAccountsLoad()
    {
      Logger.LogWrite("Getting the list of all user name ");
      cb_UserAccounts.ItemsSource = m_clientapi.GetAllUserNames(LoginToken);
    }

    /// <summary>
    /// To create a new user 
    /// </summary>
    /// <param name="InUsername"></param>
    /// <param name="InPassword"></param>
    /// <returns></returns>
    private bool CreateNewUserAccount(string InUsername, string InPassword)
    {
      if (m_clientapi.CreateNewUser(InUsername, InPassword, LoginToken).valid)
      {
        Logger.LogWrite("Created a new user : " + InUsername);
        return true;
      }
      else
      {
        return false;
      }
    }


    /// <summary>
    /// Wrapper function to change the user privilege level 
    /// </summary>
    /// <param name="m_InUsername"></param>
    /// <param name="m_Token"></param>
    /// <returns></returns>
    private bool ChangeUserLevel(string m_InUsername, string m_Token)
    {
      if (m_clientapi.ChangeUserPrivilege(m_InUsername, CurrentUserIsAdmin, LoginToken).valid)
      {
        Logger.LogWrite("Changing the user level for " + m_InUsername);
        return true;
      }
      else
      {
        return false;
      }

    }


    /// <summary>
    /// Validation function before saving the new user 
    /// </summary>
    /// <param name="Message"></param>
    /// <returns></returns>
    private bool IsValidSave(out string Message)
    {
      bool ret = true;
      Message = "Success";

      if (!(tb_AIPassword.Text == tb_AIConfirmPassword.Text))
      {
        Logger.LogWrite("Passwords do not match!");
        ret = false;
        Message = "Entered Passwords do not match!";
      }

      if (tb_AIUsername.Text == "")
      {
        Logger.LogWrite("Invalid Username entered");
        ret = false;
        Message = "Invalid Username entered!";
      }

      if (tb_AIPassword.Text == "")
      {
        Logger.LogWrite("Invalid Username");
        ret = false;
        Message = "Invalid Password entered!";
      }

      return ret;
    }

    #endregion AccountManagement Tab - Methods


    #region AccountManagement Tab - EventHandlers

    private void AccountMgmtTab_Loaded(object sender, RoutedEventArgs e)
    {
      this.AccountMgmtTabLoad();
    }

    private void bn_Save_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      Logger.LogWrite("button press down 1");
      string tmp_Message;
      if (this.IsValidSave(out tmp_Message))
      {
        if (this.CreateNewUserAccount(tb_AIUsername.Text, tb_AIPassword.Text))
        {
          MessageBox.Show("User " + tb_AIUsername.Text + " created");
        }
        else
        {
          MessageBox.Show("User " + tb_AIUsername.Text + " not created");
        }
      }
      if (UserLevelChanged == true)
      {
        ChangeUserLevel(tb_AIUsername.Text, LoginToken);
        MessageBox.Show("Updated the user privilege level", "Eskimo DB");
      }
      else
      {
        MessageBox.Show(tmp_Message);
      }

    }

    private void bn_Save_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      Logger.LogWrite("button press up1");
      bn_Save.Focusable = false;
    }

    private void bn_New_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      Logger.LogWrite("button press down2");
      tb_AIUsername.Text = "";
      tb_AIPassword.Text = "";
      tb_AIConfirmPassword.Text = "";
    }

    private void bn_New_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      bn_New.Focusable = false;
    }


    private void cb_UserAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      tb_AIUsername.Text = cb_UserAccounts.SelectedItem.ToString();
      tb_AIPassword.Text = "";
      tb_AIConfirmPassword.Text = "";
    }
    private void m_CmbUserPrivilege_Loaded(object sender, RoutedEventArgs e)
    {
      m_CmbUserPrivilege.Items.Clear();
      m_CmbUserPrivilege.Items.Add("regular user");
      m_CmbUserPrivilege.Items.Add("administrator");
    }
    private void m_CmbUserPrivilege_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      UserLevelChanged = true;
    }



    #endregion AccountManagement Tab - EventHandlers


    #endregion AccountManagement Tab

    #region EskimoDBQuery Tab

    #region EskimoDBQuery Tab - Properties

    public int m_RowsPerPage { get; set; }

    public List<string> m_ColumnNames { get; set; }

    public List<Type> m_ColumnTypes { get; set; }

    public QueryDataset m_SourceData;

    #endregion EskimoDBQuery Tab - Properties

    #region EskimoDBQuery Tab - Methods

    private void EskimoDBQueryTabLoad()
    {

    }

    public void dg_QueryResultsLoad()
    {
      try
      {

        dg_QueryResults.ItemsSource = null;
        if (!String.IsNullOrEmpty(m_txtEskimoDBQuery.Text.ToString()))
        {
          m_clientapi.ExecuteQuery(m_txtEskimoDBQuery.Text.ToString(), LoginToken);

          if (m_clientapi.CheckIfRowsReturned())
          {


            DataTable DataGridDataTable = this.ConvertToDataTable(m_clientapi);

            dg_QueryResults.ItemsSource = DataGridDataTable.DefaultView;
          }
          else
          {
            if (m_clientapi.GetQueryMessage() != null)
            {
              MessageBox.Show(m_clientapi.GetQueryMessage());
            }
            else
            {
              MessageBox.Show("Invalid Input");
            }
            //  MessageBox.Show("No rows of Data Returned");
          }
        }
        else
        {
          MessageBox.Show("Enter the query to be executed", "Eskimo DB");
        }
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
      }
    }


    public DataTable ConvertToDataTable(ClientAPI m_QueryData)
    {
      DataTable ret;

      try
      {
        ret = new DataTable();
        ret.TableName = "testtable";
        DataColumn column;
        DataRow row;

        List<List<string>> ExecuteQueryData = new List<List<string>>();

        ExecuteQueryData.Add(m_QueryData.IterateDataSet());

        List<string> ColNames = m_QueryData.GetAllColumnNames();
        List<System.Type> ColTypes = m_QueryData.GetAllColumnTypes();

        for (int i = 0; i < ColNames.Count; i++)
        {
          column = new DataColumn();
          column.DataType = ColTypes[i];
          column.ColumnName = ColNames[i];
          column.ReadOnly = false;
          column.Unique = false;
          // Add the Column to the DataColumnCollection.
          ret.Columns.Add(column);
        }

        if (!(tb_RowsPerPage.Text == ""))
        {
          m_RowsPerPage = Convert.ToInt32(tb_RowsPerPage.Text);
        }
        else
        {
          m_RowsPerPage = 5;
        }

        for (int i = 0; i < m_RowsPerPage; i++)
        {
          List<string> tempList = m_QueryData.IterateDataSet();
          ExecuteQueryData.Add(tempList);
        }

        for (int i = 0; i < m_RowsPerPage; i++)
        {
          List<string> rowdata = ExecuteQueryData[i];
          row = ret.NewRow();
          for (int j = 0; j < ColNames.Count; j++)
          {
            string temp = rowdata[j];
            row[ColNames[j]] = Convert.ChangeType(temp, Type.GetType(ColTypes[j].ToString()));
          }
          ret.Rows.Add(row);
        }

        return ret;
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
        return new DataTable();
      }
    }

    #endregion EskimoDBQuery Tab - Methods

    #region EskimoDBQuery Tab - EventHandlers

    private void EskimoDBQuery_Loaded(object sender, RoutedEventArgs e)
    {
      this.EskimoDBQueryTabLoad();
    }

    private void m_btnExecuteQuery_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      try
      {
        this.dg_QueryResultsLoad();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void m_btnExecuteQuery_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      this.m_btnExecuteQuery.Focusable = false;
    }



    #endregion EskimoDBQuery Tab - EventHandlers

    #endregion EskimoDBQuery Tab

    #region TableConfiguration

    // Fix to prevent the existence of a blank  extra row in the data grid 
    private void m_dataGridTable_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      DataGrid myDataGrid = (DataGrid)sender;
      // Do not change column size if Visibility State Changed 
      if (myDataGrid.RenderSize.Width != 0)
      {
        double all_columns_sizes = 0.0;
        foreach (DataGridColumn dg_c in myDataGrid.Columns)
        {
          all_columns_sizes += dg_c.ActualWidth;
        }
        // Space available to fill ( - Standard vScrollbar) 
        double space_available = (myDataGrid.RenderSize.Width - 2) - all_columns_sizes;
        foreach (DataGridColumn dg_c in myDataGrid.Columns)
        {
          dg_c.Width = new DataGridLength(dg_c.ActualWidth + (space_available / myDataGrid.Columns.Count));
        }
      }
    }

    private void m_dataGridTable_Loaded(object sender, RoutedEventArgs e)
    {
      m_NewTableContents = new List<DesktopGUIHelper>();
      m_dataGridTable.DataContext = m_NewTableContents;
    }

    /// <summary>
    /// Based on the user input, we create the query to build a new table in the database 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void m_CreateTable_Click(object sender, RoutedEventArgs e)
    {
      string test = string.Empty;
      foreach (DesktopGUIHelper m_item in m_NewTableContents)
      {
        test = test + "Column Name:" + m_item.ColumnName + " Column Type: " + m_item.ColumnType + "\n";
      }

      if (ValidateUserInput())
      {
        MessageBox.Show("Valid details entered by the user", "Eskimo DB");
        //Create the query based on user input
        BuildCreateTableQuery();
        m_TxtbQuery.Text = m_FinalNewTableQuery;
        m_clientapi.ExecuteQuery(m_TxtbQuery.Text, LoginToken);
      }

    }

    /// <summary>
    /// Validates the data entered by the user in the Gui
    /// 
    /// </summary>
    /// <returns>
    /// True when valid data is entered by the user
    /// False when invalid data entered by the user 
    /// </returns>
    private bool ValidateUserInput()
    {
      bool validate = true;

      if (!CheckTableNamePresent())
      {
        validate = false;

      }
      if (!CheckTableNameFormat())
      {
        validate = false;

      }
      if (!CheckColumnNamesPresent())
      {
        validate = false;

      }
      if (!CheckColumnNamesFormat())
      {
        validate = false;

      }
      if (!CheckAllColumnTypesSelected())
      {
        validate = false;
      }
      if (validate == false)
      {
        return false;

      }

      return true;
    }

    /// <summary>
    /// Checks if the name of the table is entered by the user
    /// </summary>
    /// <returns>
    /// True when table name is present
    /// False when table name is not present 
    /// </returns>
    private bool CheckTableNamePresent()
    {
      if (!String.IsNullOrEmpty(m_TxbTableName.Text))
      {
        return true;
      }
      MessageBox.Show("Please enter the name of the table", "Eskimo DB");
      return false;
    }

    private bool CheckTableNameFormat()
    {
      if (!String.IsNullOrEmpty(m_TxbTableName.Text))
      {
        if (!ValidateNameFormat(m_TxbTableName.Text))
        {
          MessageBox.Show("Enter a valid table name", "Eskimo DB");
          return false;
        }
      }
      return true;

    }

    private bool ValidateNameFormat(string m_ColumnName)
    {
      m_ColumnName = m_ColumnName ?? string.Empty;
      string m_NameRegex = @"[a-zA-Z][a-zA-Z0-9]*";
      Regex m_Re = new Regex(m_NameRegex);
      if (m_Re.IsMatch(m_ColumnName))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Checks each column name present in the datagrid
    /// </summary>
    /// <returns>
    /// True when all column names are valid
    /// False when the column names are invalid 
    /// </returns>
    private bool CheckColumnNamesFormat()
    {
      string m_InvalidColumns = string.Empty;
      foreach (DesktopGUIHelper m_item in m_NewTableContents)
      {
        if (!ValidateNameFormat(m_item.ColumnName))
        {
          m_InvalidColumns = m_InvalidColumns + m_item.ColumnName + "\n";

        }
      }
      if (!String.IsNullOrEmpty(m_InvalidColumns))
      {
        MessageBox.Show("Following Column Names are Incorrect" + "\n" + m_InvalidColumns, "Eskimo DB");
        return false;
      }

      return true;
    }


    /// <summary>
    /// To check if the rows are present in the datagrid i.e. column details entered by the user 
    /// </summary>
    /// <returns>
    /// False when no column definitions provided by the user
    /// True when column definitions are provided by the user 
    /// </returns>
    private bool CheckColumnNamesPresent()
    {

      if (m_NewTableContents.Count == 0)
      {
        MessageBox.Show("Please enter column names for all rows", "Eskimo DB");
        return false;
      }
      return true;
    }

    private bool CheckAllColumnTypesSelected()
    {
      foreach (DesktopGUIHelper m_item in m_NewTableContents)
      {
        if (String.IsNullOrEmpty(m_item.ColumnType))
        {
          MessageBox.Show("Please enter column types for all rows", "Eskimo DB");
          return false;
        }
      }
      return true;
    }







    /// <summary>
    /// Main function to build the query. 
    /// It calls a number of other functions to build different parts of the query
    /// </summary>
    private void BuildCreateTableQuery()
    {

      ///Checks if the table name is not left blank by the client
      if (!String.IsNullOrEmpty(m_TxbTableName.Text))
      {
        m_NewTableName = m_TxbTableName.Text;
      }

      m_FinalNewTableQuery = "CREATE TABLE" + " " + m_NewTableName + "(";

      BuildTableColumnList();


    }

    private void BuildTableColumnList()
    {
      int m_NoOfItems = m_NewTableContents.Count;
      if (m_NoOfItems != 0)
      {
        foreach (DesktopGUIHelper m_item in m_NewTableContents)
        {
          bool m_IsPrimary;
          m_IsPrimary = m_item.PrimaryKey;
          if (m_item != m_NewTableContents[m_NoOfItems - 1])
          {
            IsPrimaryKey(m_IsPrimary);
            m_FinalNewTableQuery = m_FinalNewTableQuery + " " + m_item.ColumnName + " " + m_item.ColumnType + " " + ",";
          }
          else
          {

            IsPrimaryKey(m_IsPrimary);
            m_FinalNewTableQuery = m_FinalNewTableQuery + " " + m_item.ColumnName + " " + m_item.ColumnType + " ";
          }
        }
      }

      m_FinalNewTableQuery = m_FinalNewTableQuery + ");";


    }

    private void IsPrimaryKey(bool isprimary)
    {
      if (isprimary)
      {
        m_FinalNewTableQuery = m_FinalNewTableQuery + "PRIMARY KEY";
      }
    }

    private void m_ChkBoxPrimaryKey_Loaded(object sender, RoutedEventArgs e)
    {
      m_CbPrimary = sender as CheckBox;

    }

    private void m_ChkBoxPrimaryKey_Checked(object sender, RoutedEventArgs e)
    {
      DesktopGUIHelper m_SelectedRow = (DesktopGUIHelper)m_dataGridTable.SelectedItem;
      m_SelectedRow.PrimaryKey = true;



      //this.PrimaryKey = "true";


    }

    private void m_dataGridTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      DesktopGUIHelper m_current = CurrentSelectedRow;
      if (m_current != null)
      {
        string name = m_current.ColumnName;
        string type = m_current.ColumnType;
      }
    }
    private void m_dataGridTable_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
    {
      m_CbPrimary.IsEnabled = true;
    }

    private void m_dataGridTable_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
      m_CbPrimary.IsEnabled = false;

    }

    #endregion TableConfiguration

    #region Table Tab

    #region Properties

    public string SelectedItemHeader { get; set; }

    public Dictionary<string, List<string>> m_DBTableInfos { get; set; }

    #endregion

    #region Event Handlers

    private void TreeView_Loaded(object sender, RoutedEventArgs e)
    {
      m_clientapi = new ClientAPI();
      m_clientapi.SetRootServer(RootServerUrl);
      m_clientapi.SetAuthHostAddress(AuthServerUrl);
      m_clientapi.ConfigClient();

      m_DBTableInfos = m_clientapi.GetTableInfos(LoginToken);
      m_EskimoDbTree.Items.Clear();

      foreach (KeyValuePair<string, List<string>> m_kvps in m_DBTableInfos)
      {
        TreeViewItem m_Level1Item = new TreeViewItem();
        m_Level1Item.Header = m_kvps.Key;

        foreach (string m_Value in m_kvps.Value)
        {
          TreeViewItem m_Level2Item = new TreeViewItem();
          m_Level2Item.Header = m_Value;
          m_Level1Item.Items.Add(m_Level2Item);
        }

        m_EskimoDbTree.Items.Add(m_Level1Item);

      }
    }

    private void m_EskimoDbTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
      TreeViewItem selectedItem = (TreeViewItem)m_EskimoDbTree.SelectedItem;
      if (selectedItem != null)
      {
        SelectedItemHeader = selectedItem.Header.ToString();

      }

      if (m_DBTableInfos.ContainsKey(SelectedItemHeader))
      {
        m_DgContentOfTables.Visibility = System.Windows.Visibility.Hidden;
        m_DeleteTable.Visibility = System.Windows.Visibility.Hidden;
      }
      else
        if (this.IsValueExists(m_DBTableInfos, SelectedItemHeader))
        {
          m_DgContentOfTables.Visibility = System.Windows.Visibility.Visible;
          m_DeleteTable.Visibility = System.Windows.Visibility.Visible;
          ExecuteSelectQuery(SelectedItemHeader);
        }


    }
    #endregion

    #region Methods


    /// <summary>
    /// To get the datbase name , corresponding to the selected table 
    /// </summary>
    /// <param name="ArgDict"></param>
    /// <param name="Val"></param>
    /// <returns></returns>
    private string GetKeyForValue(Dictionary<string, List<string>> ArgDict, string Val)
    {
      string ret = null;

      foreach (KeyValuePair<string, List<string>> kvp in ArgDict)
      {
        foreach (string itemvalue in kvp.Value)
        {
          if (itemvalue == Val)
          {
            ret = kvp.Key;
          }
        }
      }
      return ret;
    }

    /// <summary>
    /// To check if a value exists in the dictionary of datagase names and table configuration details 
    /// </summary>
    /// <param name="ArgDict"></param>
    /// <param name="Val"></param>
    /// <returns></returns>
    private bool IsValueExists(Dictionary<string, List<string>> ArgDict, string Val)
    {
      bool ret = false;
      foreach (KeyValuePair<string, List<string>> kvp in ArgDict)
      {
        foreach (string itemvalue in kvp.Value)
        {
          if (itemvalue == Val)
          {
            ret = true;
          }
        }
      }
      return ret;
    }

    #endregion

    /// <summary>
    /// To execute the select statements , when the table name is selected in the tree view 
    /// </summary>
    /// <param name="m_TableName"></param>
    private void ExecuteSelectQuery(string m_TableName)
    {
      try
      {
        m_clientapi = new ClientAPI();
        m_clientapi.SetRootServer(RootServerUrl);
        m_clientapi.SetAuthHostAddress(AuthServerUrl);
        m_clientapi.ConfigClient();

        m_DgContentOfTables.ItemsSource = null;

        string m_Query = "SELECT * FROM " + this.GetKeyForValue(m_DBTableInfos, m_TableName) + "." + m_TableName;

        m_clientapi.ExecuteQuery(m_Query, LoginToken);

        if (m_clientapi.CheckIfRowsReturned())
        {
          DataTable DataGridDataTable = this.GenerateColumnNameAndTypes(m_clientapi);

          m_DgContentOfTables.ItemsSource = DataGridDataTable.DefaultView;
        }
        else
        {
          MessageBox.Show("No rows of Data Returned");
        }

      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
      }
    }


    /// <summary>
    /// To generate the column names and column types 
    /// </summary>
    /// <param name="m_QueryData"></param>
    /// <returns></returns>
    public DataTable GenerateColumnNameAndTypes(ClientAPI m_QueryData)
    {
      DataTable ret;

      try
      {
        ret = new DataTable();
        ret.TableName = "testtable";
        DataRow row;

        List<List<string>> ExecuteQueryData = new List<List<string>>();

        ExecuteQueryData.Add(m_QueryData.IterateDataSet());

        List<string> ColNames = m_QueryData.GetAllColumnNames();
        List<System.Type> ColTypes = m_QueryData.GetAllColumnTypes();
        //creating the column name column in the datagrid 
        DataColumn m_ColumnName = new DataColumn();
        m_ColumnName.ColumnName = "Column Name";
        m_ColumnName.DataType = Type.GetType("System.String");
        ret.Columns.Add(m_ColumnName);

        //creating the column types column in the datagrid 
        DataColumn m_ColumnType = new DataColumn();
        m_ColumnType.ColumnName = "Column Type";
        m_ColumnType.DataType = Type.GetType("System.String");
        ret.Columns.Add(m_ColumnType);

        //add the column names to the datatable 
        for (int i = 0; i < ColNames.Count; i++)
        {
          row = ret.NewRow();
          row["Column Name"] = ColNames[i].ToString();
          row["Column Type"] = ColTypes[i].ToString();
          ret.Rows.Add(row);

        }

        return ret;
      }
      catch (Exception ex)
      {

        MessageBox.Show(ex.Message);
        return new DataTable();
      }
    }

    #endregion

  }

  #region Styles

  #region TreeViewStyle
  public static class MyTreeViewHelper
  {
    //
    // The TreeViewItem that the mouse is currently directly over (or null).
    //
    private static TreeViewItem _currentItem = null;

    //
    // IsMouseDirectlyOverItem:  A DependencyProperty that will be true only on the 
    // TreeViewItem that the mouse is directly over.  I.e., this won't be set on that 
    // parent item.
    //
    // This is the only public member, and is read-only.
    //

    // The property key (since this is a read-only DP)
    private static readonly DependencyPropertyKey IsMouseDirectlyOverItemKey =
        DependencyProperty.RegisterAttachedReadOnly("IsMouseDirectlyOverItem",
                                            typeof(bool),
                                            typeof(MyTreeViewHelper),
                                            new FrameworkPropertyMetadata(null, new CoerceValueCallback(CalculateIsMouseDirectlyOverItem)));

    // The DP itself
    public static readonly DependencyProperty IsMouseDirectlyOverItemProperty =
        IsMouseDirectlyOverItemKey.DependencyProperty;

    // A strongly-typed getter for the property.
    public static bool GetIsMouseDirectlyOverItem(DependencyObject obj)
    {
      return (bool)obj.GetValue(IsMouseDirectlyOverItemProperty);
    }

    // A coercion method for the property
    private static object CalculateIsMouseDirectlyOverItem(DependencyObject item, object value)
    {
      // This method is called when the IsMouseDirectlyOver property is being calculated
      // for a TreeViewItem.  

      if (item == _currentItem)
        return true;
      else
        return false;
    }

    //
    // UpdateOverItem:  A private RoutedEvent used to find the nearest encapsulating
    // TreeViewItem to the mouse's current position.
    //

    private static readonly RoutedEvent UpdateOverItemEvent = EventManager.RegisterRoutedEvent(
        "UpdateOverItem", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyTreeViewHelper));

    //
    // Class constructor
    //

    static MyTreeViewHelper()
    {
      // Get all Mouse enter/leave events for TreeViewItem.
      EventManager.RegisterClassHandler(typeof(TreeViewItem), TreeViewItem.MouseEnterEvent, new MouseEventHandler(OnMouseTransition), true);
      EventManager.RegisterClassHandler(typeof(TreeViewItem), TreeViewItem.MouseLeaveEvent, new MouseEventHandler(OnMouseTransition), true);

      // Listen for the UpdateOverItemEvent on all TreeViewItem's.
      EventManager.RegisterClassHandler(typeof(TreeViewItem), UpdateOverItemEvent, new RoutedEventHandler(OnUpdateOverItem));
    }


    //
    // OnUpdateOverItem:  This method is a listener for the UpdateOverItemEvent.  When it is received,
    // it means that the sender is the closest TreeViewItem to the mouse (closest in the sense of the tree,
    // not geographically).

    static void OnUpdateOverItem(object sender, RoutedEventArgs args)
    {
      // Mark this object as the tree view item over which the mouse
      // is currently positioned.
      _currentItem = sender as TreeViewItem;

      // Tell that item to re-calculate the IsMouseDirectlyOverItem property
      _currentItem.InvalidateProperty(IsMouseDirectlyOverItemProperty);

      // Prevent this event from notifying other tree view items higher in the tree.
      args.Handled = true;
    }

    //
    // OnMouseTransition:  This method is a listener for both the MouseEnter event and
    // the MouseLeave event on TreeViewItems.  It updates the _currentItem, and updates
    // the IsMouseDirectlyOverItem property on the previous TreeViewItem and the new
    // TreeViewItem.

    static void OnMouseTransition(object sender, MouseEventArgs args)
    {
      lock (IsMouseDirectlyOverItemProperty)
      {
        if (_currentItem != null)
        {
          // Tell the item that previously had the mouse that it no longer does.
          DependencyObject oldItem = _currentItem;
          _currentItem = null;
          oldItem.InvalidateProperty(IsMouseDirectlyOverItemProperty);
        }

        // Get the element that is currently under the mouse.
        IInputElement currentPosition = Mouse.DirectlyOver;

        // See if the mouse is still over something (any element, not just a tree view item).
        if (currentPosition != null)
        {
          // Yes, the mouse is over something.
          // Raise an event from that point.  If a TreeViewItem is anywhere above this point
          // in the tree, it will receive this event and update _currentItem.

          RoutedEventArgs newItemArgs = new RoutedEventArgs(UpdateOverItemEvent);
          currentPosition.RaiseEvent(newItemArgs);

        }
      }
    }
  }

  #endregion TreeViewStyle

  #endregion Styles
}
