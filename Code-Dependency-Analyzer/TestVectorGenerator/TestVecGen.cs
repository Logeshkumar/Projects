using System;
using System.Collections;
using System.IO;

namespace proj4
{
  public class TVG_files : ITVG
  {
    Navig.Navigate nav;
    ArrayList files;
    IEnumerator ie;

    public TVG_files(string path, string pattern, bool recurse)
    {
      files = new ArrayList();
      if(recurse)
      {
        nav = new Navig.Navigate();
        nav.newFile += new Navig.Navigate.newFileHandler(this.save);
        nav.go(path, pattern);
      }
      else
      {
        string[] tempFiles = Directory.GetFiles(path,pattern);
        foreach(string file in tempFiles)
          files.Add(file);
      }
      ie = files.GetEnumerator();
    }
     
    public void save(string file)
    {
      files.Add(file);
    }
    public bool MoveNext()
    {
      return ie.MoveNext();
    }
    public object current()
    {
      return ie.Current;
    }

    public object Current
    {
      get { return ie.Current; }
    }

    public void Reset()
    {
      ie.Reset();
    }

    public IEnumerator GetEnumerator()
    {
      return ie;
    }

    static void Main(string[] args)
    {
      string path = "../..";
      string pattern = "*.*";
      TVG_files ftvg = new TVG_files(path,pattern,true);
      foreach(string file in ftvg)
        Console.Write("\n  {0}",Path.GetFileName(file));
      Console.Write("\n\n");
       
      ftvg.Reset();
      while(ftvg.MoveNext())
      {
        string file = ftvg.current() as string;
        Console.Write("\n  {0}",Path.GetFileName(file));
      }
      Console.Write("\n\n");
    }
  }
}
