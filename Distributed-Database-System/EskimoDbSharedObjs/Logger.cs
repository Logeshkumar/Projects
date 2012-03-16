////////////////////////////////////////////////////////////////////////////////
// Logger.cs -  Common Module for generation of Project specific Text Logs    //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Indranil Mitra, Fall 2011, Syracuse University               //
//               imitra@syr.edu                                               //
////////////////////////////////////////////////////////////////////////////////
/*
 * Public Interface
 * ================
 * string Message = "Test Message";
 * Logger.LogWrite(Message);        //Message gets logged to bin\debug\MMDDYYYY_Log.txt
 * 
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 11/02/2011 - first
 * 12/08/2011 - second
 * /
 */
using System;
using System.IO;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  public static class Logger
  {

    #region Properties

    public static string m_LogPath
    {
      get;
      set;
    }

    public static string m_exMessage
    {
      get;
      set;
    }

    public static string m_exInnerException
    {
      get;
      set;
    }

    public static string m_exHelpLink
    {
      get;
      set;
    }

    public static string m_exSource
    {
      get;
      set;
    }

    public static string m_exStackTrace
    {
      get;
      set;
    }

    public static string m_exTargetSite
    {
      get;
      set;
    }

    #endregion Properties

    #region MemberFunctions

    private static void ConfigureLogger()
    {
      m_LogPath = @"Log\";
      createDir(m_LogPath);
    }

    public static void LogWrite(String logtext)
    {
      ConfigureLogger();

      string Totaltext = Convert.ToString(DateTime.Now) + " Event log : " + logtext;

      WriteToFile(m_LogPath + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString()+@"_log.txt", Totaltext);

    }

    public static void LogWrite(Exception exception)
    {
      ConfigureLogger();

      ConfigureExceptionProperties(exception);

      ShowExceptionProperties();
    }

    private static void ConfigureExceptionProperties(Exception ex)
    {
      m_exMessage = "\nMessage ---" + ex.Message + "\n";
      m_exInnerException = "\nInner Exception ---" + ex.InnerException + "\n";
      m_exHelpLink = "\nHelpLink ---" + @"http://msdn.microsoft.com" + "\n";
      m_exSource = "\nSource ---" + ex.Source + "\n";
      m_exStackTrace = "\nStackTrace ---" + ex.StackTrace + "\n";
      m_exTargetSite = "\nTargetSite ---" + ex.TargetSite + "\n";
    }

    private static void ShowExceptionProperties()
    {
      string Totaltext = Convert.ToString(DateTime.Now) + "\t" + m_exMessage + "\n\t\t" + m_exInnerException + "\n\t\t" + m_exHelpLink + "\n\t\t" + m_exSource + "\n\t\t" + m_exStackTrace + "\n\t\t" + m_exTargetSite;

      WriteToFile(m_LogPath + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Year.ToString() + @"_log.txt", Totaltext);

    }

    private static void createDir(string dirpath)
    {
      if (!(Directory.Exists(dirpath)))
      {
        Directory.CreateDirectory(dirpath);
      }
    }

    private static void WriteToFile(string path, string TextToWrite)
    {
      if (!File.Exists(path))
      {
        // Create a file to write to.
        using (StreamWriter sw = File.CreateText(path))
        {
          sw.WriteLine(TextToWrite);
        }
      }
      else
      {
        // This text is always added, making the file longer over time
        // if it is not deleted.
        using (StreamWriter sw = File.AppendText(path))
        {
          sw.WriteLine(TextToWrite);
        }
      }
    }

    #endregion MemberFunctions

  }
}

