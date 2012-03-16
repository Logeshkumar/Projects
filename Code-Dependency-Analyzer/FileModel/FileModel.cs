///////////////////////////////////////////////////////////////////////
// FileModel.cs - Manages retrieved file data                        //
// V1.1                                                              //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////
/*
 * The class FileModel manages a List with filename entries.  It accepts in
 * bool collectFiles(
 *   string[] paths, string[] patterns, bool recurse, bool makeUnique
 * )
 * an array of paths to search, an array of patterns to search, "*.cs" for
 * example, and predicates indicating that the search should or should not
 * recurse down the directory tree rooted at a given path, and if the 
 * resulting file set should contain only unique filespecs.
 * 
 * When the collectFiles returns, its internal list holds a set of filespecs,
 * e.g., fully qualified filenames.
 * 
 * The List is declared static so that access is enabled whenever an 
 * instance of the FileModel class is created.  The instances all share
 * the same List.
 * 
 * FileModel also defines a public static property CurrentFile so any
 * method needing that information can access it conveniently.
 */
/*
 * Build Process:
 *   Required Files:
 *   FileModel.cs, FileController.CS, FileModelTests.cs, FileView.cs
 *
 * Maintenance History:
 *   V1.1 : 20 Sep 10
 *   - added these and other comments
 *   - added CurrentFile property
 *   V1.0 : 15 Sep 10
 *   - first release
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MVCDemo
{
  /////////////////////////////////////////////////////////////////////////
  // FileModel gathers all files matching a set of patterns
  // - if recurse is false each of the paths entered on the command line
  //   is searched for matching files
  // - else each directory tree rooted at a path cited on the command line
  //   is searched for matching files

  public class FileModel
  {
    static private List<string> fileSpecs = new List<string>();
    static private List<string> invalidSpecs = new List<string>();
    static private string _currentFile;

    //----< name of the file being analyzed >--------------------------------

    public string CurrentFile
    {
      get { return _currentFile; }
      set { _currentFile = value; }
    }
    

    //----< constructs FileModel with existing shared file list >------------

    public FileModel()
    {
      // don't need to do anything, user wants to share existing list
    }
    //----< constructs FileModel with specified file list >------------------
    //
    //  This constructor is deprecated.  It's operation is taken over by
    //  the better named collectFiles function.
    //
    public FileModel(string[] patterns, bool recurse)
    {
      try
      {
        string[] paths = System.Environment.GetCommandLineArgs();
        foreach (string path in paths.Skip(1))
          BuildFileList(path, patterns, recurse);
        IEnumerable<string> temp = fileSpecs.Distinct<string>();
        if (temp.AsQueryable().Count() < fileSpecs.Count)
          fileSpecs = new List<string>(temp);
      }
      catch (Exception ex)
      {
        fileSpecs.Add(ex.Message);
      }
    }
    //----< collects files on paths that match patterns >--------------------
    //
    //  Builds an internal List of fileSpecs (path + filename) found at a set of 
    //  paths.  If the predicate recurse is true, the entire directory tree rooted
    //  at that path is searched, otherwise just that directory.  If the predicate
    //  makeUnique is true, any duplicate fileSpecs are removed.
    //
    public bool collectFiles(string[] paths, string[] patterns, bool recurse, bool makeUnique)
    {
      try
      {
        foreach (string path in paths)
          BuildFileList(path, patterns, recurse);
        if (makeUnique)
        {
          IEnumerable<string> temp = fileSpecs.Distinct<string>();
          if (temp.AsQueryable().Count() < fileSpecs.Count)
          {
            fileSpecs = new List<string>(temp);
            return false;  // removed some duplicate files
          }
        }
        return true;  // all files unique
      }
      catch (Exception ex)
      {
        fileSpecs.Add(ex.Message);
        return true;
      }
    }
    //----< returns constructed file list >----------------------------------

    public List<string> files()
    {
      return fileSpecs;
    }
    //----< returns list of all invalid paths found on command line >--------

    public List<string> invalidPaths()
    {
      return invalidSpecs;
    }
    //----< helper: returns files on given path matching patterns >----------

    private List<string> getFiles(string path, string[] patterns)
    {
      List<string> files = new List<string>();
      foreach (string pattern in patterns)
      {
        string[] temp = Directory.GetFiles(path, pattern);
        files.AddRange(temp);
      }
      return files;
    }
    //----< helper: builds list of fileSpecs found on path >-----------------

    private void BuildFileList(string path, string[] patterns, bool recurse)
    {
      if (!Directory.Exists(path))
      {
        invalidSpecs.Add(path);
        return;
      }
      path = Path.GetFullPath(path);
      fileSpecs.AddRange(getFiles(path, patterns));
      if (recurse)
      {
        string[] dirs = Directory.GetDirectories(path);
        foreach (string dir in dirs)
          BuildFileList(dir, patterns, true);
      }
    }
  }
}

