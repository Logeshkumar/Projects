using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.executor
{
  public class Executor
  {
    //function to run an exe with a given set of arguments 
    public static bool Execute(string executable, string[] args)
    {
      
      System.Diagnostics.Process proc = new System.Diagnostics.Process();
      proc.StartInfo.WorkingDirectory = ".";
      proc.StartInfo.UseShellExecute = false;
      proc.StartInfo.FileName = executable;
      //convert string[] to string for the process
      string arg = "";
      if((args != null) && args.Length >= 1)
      arg =  args[0];    
      for (int i = 1; i < args.Length; i++)
        arg = arg + " " + args[i];
      proc.StartInfo.Arguments = arg;
      bool ret = false;
      try
      {
       ret   = proc.Start();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw ex;
      }
      return ret;
    }

  }
}
