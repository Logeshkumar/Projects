/////////////////////////////////////////////////////////////////////////////////
// SignIn.xaml.cs - Initial SignIn Page for ClientGUI application              //
// version 1.0                                                                 //
// Language:     C# 4.0                                                        //
// Platform:     Windows 7                                                     //
// Application:  CSE784 EskimoDB                                               //
// Author:       Indranil Mitra (imitra@syr.edu), Anjali Banka (abanka@syr.edu)//
//               Fall 2011, Syracuse University                                //
//                                                                             //
/////////////////////////////////////////////////////////////////////////////////

/*
Module Operations: 
==================
This module is a WPF GUI for the user log in. The credentials are authenticated, based 
 * on which the user in allowed to proceed with the applciation.
 
Public Interface
=================

 
Build Process
================
 * 
 * 
 Required Files:
===================
 * ClientAPI.cs


Maintenance History:
====================
ver 1.0 : 17 October 2011

*/

using System.Windows;
using System.Windows.Input;
using edu.syr.cse784.eskimodb.clientapi;
using edu.syr.cse784.eskimodb.depinject;
using edu.syr.cse784.eskimodb.sharedobjs;
using edu.syr.cse784.eskimodb.executor;
using System;

namespace edu.syr.cse784.eskimodb.ClientGUI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region Properties and Fields

    private string m_UserName, m_PassWord;

    ClientAPI m_clientapi;

    public string UserName
    {
      get
      {
        return m_UserName;
      }
      set
      {
        m_UserName = value;
      }

    }

    public string PassWord
    {
      get
      {
        return m_PassWord;
      }
      set
      {
        m_PassWord = value;
      }

    }

    #endregion Properties and Fields

    #region Constructor

    public MainWindow()
    {
      Logger.LogWrite("Loading the sign in page for Desktop GUI");
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      InitializeComponent();

      m_LblAuthServer.Visibility = System.Windows.Visibility.Hidden;
      m_LblRootServer.Visibility = System.Windows.Visibility.Hidden;
      m_TxtAuthURL.Visibility = System.Windows.Visibility.Hidden;
      m_TxtRootURL.Visibility = System.Windows.Visibility.Hidden;

      DependencyInjection di = DependencyInjection.GetInstance();
      di.SetConfig("config.xml");
      Startup();

    }

    #endregion Constructor

    private bool Startup()
    {
      Logger.LogWrite("Connecting using the AuthServer.exe");
      bool ret = true;
      ret = Executor.Execute(@"../../../AuthServer/bin/Debug/AuthServer.exe", new string[] { "http://localhost:8080/IComm" });
      return ret;
    }

    #region CheckBox Event Handler


    private void checkBox1_Checked(object sender, RoutedEventArgs e)
    {
      Logger.LogWrite("User checked the checkbox ");
      m_LblAuthServer.Visibility = System.Windows.Visibility.Visible;
      m_LblRootServer.Visibility = System.Windows.Visibility.Visible;
      m_TxtAuthURL.Visibility = System.Windows.Visibility.Visible;
      m_TxtRootURL.Visibility = System.Windows.Visibility.Visible;

    }

    private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
    {
      Logger.LogWrite("User unchecked the checkbox ");
      m_LblAuthServer.Visibility = System.Windows.Visibility.Hidden;
      m_LblRootServer.Visibility = System.Windows.Visibility.Hidden;
      m_TxtAuthURL.Visibility = System.Windows.Visibility.Hidden;
      m_TxtRootURL.Visibility = System.Windows.Visibility.Hidden;

    }

    #endregion

    #region Button - Event Handlers

    private void m_btnLogIn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      try
      {
        string temptoken;
        m_clientapi = new ClientAPI();
        m_clientapi.SetAuthHostAddress(m_TxtAuthURL.Text.ToString());
        m_clientapi.SetRootServer(m_TxtRootURL.Text.ToString());
        m_clientapi.ConfigClient();
        AuthResult m_AuthResult = m_clientapi.AuthenticateUser(m_txtUserName.Text, m_txtPassWord.Password, out temptoken);
        if (m_AuthResult.valid)
        {
          Logger.LogWrite("User: " + m_txtUserName.Text + " is authenticated");
          MessageBox.Show(m_txtUserName.Text + " Authenticated!!!", "Eskimo DB");
          DesktopGUI m_UserMenuWindow = new DesktopGUI(temptoken, m_TxtRootURL.Text.ToString(), m_TxtAuthURL.Text.ToString());
          m_UserMenuWindow.Show();
          this.Close();
        }
        else
        {
          Logger.LogWrite("User: " + m_txtUserName.Text + " is not authenticated");
          MessageBox.Show(m_AuthResult.msg);
          m_txtUserName.Text = string.Empty;
          m_txtPassWord.Password = string.Empty;
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Please enter valid url. Error Message :" + ex.Message, "EskimoDB");
      }
    }

    private void m_btnLogIn_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      m_btnLogIn.Focusable = false;
    }

    #endregion Button - Event Handlers

  }
}
