///////////////////////////////////////////////////////////////////////
///  Navigate.cs - Navigates a Directory Subtree, displaying files  ///
///  ver 1.1       and some of their properties                     ///
///                                                                 ///
///  Language:     Visual C#                                        ///
///  Platform:     Dell Dimension 8100, Windows Pro 2000, SP2       ///
///  Application:  CSE681 Example                                   ///
///  Author:       Jim Fawcett, CST 2-187, Syracuse Univ.           ///
///                (315) 443-3948, jfawcett@twcny.rr.com            ///
///////////////////////////////////////////////////////////////////////
/*
 *  Operations:
 * =============
 *  Recursively displays the contents of a directory tree
 *  rooted at path
 *
 *  This version uses delegates to avoid embedding application
 *  details in the Navigator.  Navigate now is reusable.  Clients
 *  simply register event handlers for Navigate events newDir 
 *  and newFile.
 * 
 *  Maintenance History:
 * ======================
 * ver 1.1 : 06 Oct 05
 * - converted path to fullpath in go(path) to avoid a startup problem
 * - added go(path,pattern)
 * ver 1.0 : 25 May 03
 * - first release
 */
using System;
using System.IO;

namespace Navig
{
  public class Navigate
  {
    public delegate void newDirHandler(string dir);
    public event newDirHandler newDir;
    public delegate void newFileHandler(string file);
    public event newFileHandler newFile;

    public Navigate()
    {
    }
    ///////////////////////
    // The go function now has no application specific code.
    // It just invokes its event delegate to notify clients.
    // The clients take care of all the application specific stuff.
    
    public void go(string path)
    {
      go(path,"*.*");
    }
    public void go(string path, string pattern)
    {
      path = Path.GetFullPath(path);
      Directory.SetCurrentDirectory(path);
      if(newDir != null)
        newDir(path);

      string [] files = Directory.GetFiles(path,pattern);
      foreach(string file in files)
      {
        if(newFile != null)
          newFile(file);
      }
      string[] dirs = Directory.GetDirectories(path);
      foreach(string dir in dirs)
        go(dir,pattern);
    }
  }
}
