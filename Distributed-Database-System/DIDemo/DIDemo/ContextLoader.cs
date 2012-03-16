using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Reflection;

namespace DIDemo
{
    public class ContextLoader : MarshalByRefObject
    {
        private static bool m_isConfigured = false;
        private static string m_configFile = "";
        private static Dictionary<string, Type> m_typeReg = new Dictionary<string, Type>();
        private static Dictionary<string, string> m_typeMapping = new Dictionary<string, string>();
        private static Dictionary<string, string> m_wcfMapping = new Dictionary<string, string>();

        private static bool loadTypes(string libPath)
        {
            libPath = Path.GetFullPath(libPath);
            List<string> libs = Directory.GetFiles(libPath, "*.dll").ToList<string>();
            List<string> exes = Directory.GetFiles(libPath, "*.exe").ToList<string>();
               
            foreach (string lib in libs.Union(exes))
            {
                Assembly.LoadFrom(lib);
            }
            Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assem in assems)
            {
                Type[] types = assem.GetTypes();
                foreach(Type type in types)
                {
                    string typeStr = type.FullName;
                    if (!m_typeReg.ContainsKey(typeStr))
                        m_typeReg.Add(typeStr, type);
                }
            }
            return true;
        }

        private static bool loadMappings(string confPath)
        {
            confPath = Path.GetFullPath(confPath);
            XDocument xdoc = XDocument.Load(confPath);
            var mappings = from q in xdoc.Descendants("class")
                        select q;
            foreach (XElement mapping in mappings)
            {
                string name = mapping.Attribute("name").Value;
                string typeName = mapping.Attribute("type").Value;
                if (mapping.Attribute("wcf")!=null && !m_wcfMapping.ContainsKey(name))
                  m_wcfMapping.Add(name, typeName);
                else if (!m_typeMapping.ContainsKey(name))
                  m_typeMapping.Add(name, typeName);
            }
            return true;
        }

        private static bool loadConfig()
        {
            XDocument xdoc = XDocument.Load(m_configFile);
            var libs = from q in xdoc.Descendants("lib")
                        select q.Attribute("path").Value;
            var configs = from p in xdoc.Descendants("config")
                        select p.Attribute("path").Value;
            foreach (string libPath in libs)
                if (!loadTypes(libPath))
                    return false;
            foreach (string confPath in configs)
                if (!loadMappings(confPath))
                    return false;
            return true;
        }

        public static bool Reload()
        {
            m_isConfigured = loadConfig();
            return m_isConfigured;
        }

        public static bool SetConfiguration(string configFile)
        {
            m_configFile = Path.GetFullPath(configFile);
            m_isConfigured = loadConfig();
            return m_isConfigured;
        }

        public static Object GetObject(string name,object[] info = null)
        {
            Object ret = null;
            string typeName;
            Type type;
            if (m_wcfMapping.TryGetValue(name, out typeName) && m_typeReg.TryGetValue(typeName, out type))
              ret = ServiceRefCreator.GetWcfReference(type, info);
            else if (m_typeMapping.TryGetValue(name, out typeName) && m_typeReg.TryGetValue(typeName, out type))
            {
              if (info != null)
              {
                try
                {
                  ret = Activator.CreateInstance(type, info);
                }
                catch(MissingMethodException){
                  ret = Activator.CreateInstance(type);
                }
              }
              else
                ret = Activator.CreateInstance(type);
            }
            return ret;
        }

        static void Main(String[] args)
        {
            string configPath = args[0];
            if (ContextLoader.SetConfiguration(configPath))
            {
              object[] info = new object[] { "param" };
                ITest test = (ITest)ContextLoader.GetObject("myTest",info);
                test.doTest();
                Console.ReadKey();
            }
        }
    }
}