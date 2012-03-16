//////////////////////////////////////////////////////////////////////////////////
//Program : DependencyInjection                                                 //
//Function : Provides an Single container that holds                            //
//           all the libraries loaded and thier respective mapping              //
//Author :   Yiou Li, Shashank Hegde                                            //
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace edu.syr.cse784.eskimodb.depinject
{
  public class DependencyInjection
  {
    class DIFilter
    {
      public string Type { get; set; }
      public string Key { get; set; }
      public string Value { get; set; }

      public bool DoFilter(Type[] types)
      {
        return false;
      }
    }

    private static DependencyInjection m_instance;

    public static DependencyInjection GetInstance()
    {
      if (m_instance == null) //TODO: Locking needs to be implemented to support multi-core engines 
      {
        m_instance = new DependencyInjection();
      }

      return m_instance;
    }

    private string m_ConfigPath;
    private List<string> m_LoadedConfigs;
    private Dictionary<string, Type> m_TypeReg;
    private Dictionary<string, string> m_TypeMapping;
    private Dictionary<string, string> m_WcfMapping;
    private List<DIFilter> m_Filters;

    //private constructor for singleton
    private DependencyInjection()
    {
      m_ConfigPath = "";
      m_LoadedConfigs = new List<string>();
      m_TypeReg = new Dictionary<string, Type>();
      m_TypeMapping = new Dictionary<string, string>();
      m_WcfMapping = new Dictionary<string, string>();
      m_Filters = new List<DIFilter>();
    }

    private void Clear()
    {
      m_ConfigPath = "";
      m_LoadedConfigs.Clear();
      m_TypeReg.Clear();
      m_TypeMapping.Clear();
      m_Filters.Clear();
      m_WcfMapping.Clear();
    }

    private void LoadImportFiles(IEnumerable<XElement> importsSections)
    {
      foreach(XElement section in importsSections)
      {
        var imports = from q in section.Descendants("Import") select q;
        foreach (var import in imports)
        {
          if (import.Attribute("path") != null)
          {
            LoadConfig(Path.GetFullPath(import.Attribute("path").Value));
          }
          else if (import.Attribute("dir") != null)
          {
            string pattern = "*.*";
            if (import.Attribute("pattern") != null)
              pattern = import.Attribute("pattern").Value;
            string[] files = Directory.GetFiles(Path.GetFullPath(import.Attribute("dir").Value), pattern);
            foreach (string file in files)
              LoadConfig(file);
          }
        }
      }
    }

    private void LoadLibs(IEnumerable<XElement> libsSections)
    {
      foreach (XElement section in libsSections)
      {
        var libs = from n in section.Descendants("Lib")
                       select n;
        foreach (var lib in libs)
        {
          if (lib.Attribute("path") != null)
          {
            Assembly.LoadFrom(Path.GetFullPath(lib.Attribute("path").Value));
          }
          else
          {
            string dir = Path.GetFullPath(lib.Attribute("dir").Value);
            List<string> files = new List<string>();
            if (lib.Attribute("pattern") != null)
            {
              string[] patterns = lib.Attribute("pattern").Value.Split(',');
              foreach (string pat in patterns)
                files = files.Union(Directory.GetFiles(dir, pat)).ToList();
            }
            else
              files = Directory.GetFiles(dir, "*.*").ToList();
            foreach (string file in files)
              Assembly.LoadFrom(file);
          }
        }
      }
    }

    private void LoadMappings(IEnumerable<XElement> mappingsSections)
    {
      foreach (XElement section in mappingsSections)
      {
        var mappings = from n in section.Descendants("Mapping")
                      select n;
        foreach (XElement mapping in mappings)
        {
          string identifier = mapping.Attribute("name").Value;
          string Typename = mapping.Attribute("type").Value;
          if (mapping.Attribute("wcf") != null && !m_WcfMapping.ContainsKey(identifier))
            m_WcfMapping.Add(identifier, Typename);
          else
            m_TypeMapping.Add(identifier, Typename);
        }
      }
    }

    private void LoadFilters(IEnumerable<XElement> filtersSections)
    {
      foreach (XElement section in filtersSections)
      {
        var filters = from n in section.Descendants("Filter")
                       select n;
        foreach (XElement filter in filters)
        {
          DIFilter obj = new DIFilter();
          obj.Type = filter.Attribute("type").Value;
          obj.Key = filter.Attribute("key").Value;
          obj.Value = filter.Attribute("value").Value;
          m_Filters.Add(obj);
        }
      }
    }

    private void LoadConfig(string path)
    {
      if (!m_LoadedConfigs.Contains(path))
      {
        XDocument conf = XDocument.Load(path);
        m_LoadedConfigs.Add(path);
        var imports = from q in conf.Descendants("Imports") select q;
        LoadImportFiles(imports);
        var filters = from q in conf.Descendants("Filters") select q;
        LoadFilters(filters);
        var libs = from q in conf.Descendants("Libs") select q;
        LoadLibs(libs);
        var mappings = from q in conf.Descendants("Mappings") select q;
        LoadMappings(mappings);
      }
    }

    private void RegisterTypes()
    {
      Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
      foreach (Assembly assem in assems)
      {
        Type[] types = assem.GetTypes();
        foreach (DIFilter filter in m_Filters)
          filter.DoFilter(types);
        foreach (Type type in types)
        {
          string typeStr = type.FullName;
          if (!m_TypeReg.ContainsKey(typeStr))
            m_TypeReg.Add(typeStr, type);
        }
      }
    }

    //set the current DI configuration file path
    public void SetConfig(string configPath)
    {
      Clear();
      m_ConfigPath = Path.GetFullPath(configPath);
      LoadConfig(m_ConfigPath);
      RegisterTypes();
    }

    public object CreateObject(string name, object[] runtimeInfo = null)
    {
      object ret = null;
      string typeName;
      Type type;
      if (m_WcfMapping.TryGetValue(name, out typeName) && m_TypeReg.TryGetValue(typeName, out type))
        ret = ServiceRefCreator.GetWcfReference(type, runtimeInfo);
      else if (m_TypeMapping.TryGetValue(name, out typeName) && m_TypeReg.TryGetValue(typeName, out type))
      {
        if (runtimeInfo != null)
        {
          try
          {
            ret = Activator.CreateInstance(type, runtimeInfo);
          }
          catch (MissingMethodException)
          {
            ret = Activator.CreateInstance(type);
          }
        }
        else
          ret = Activator.CreateInstance(type);
      }
      return ret;
    }
  }
}
