using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using MessageExample;

namespace ConsoleApplication3
{
  public class Messag
  {
    public string Msg { get; set; }
    public int TestID { get; set; }
    public bool Passed { get; set; }
    public string AssemblyName { get; set; }
    public string TypeName { get; set; }
  }

  public class Loader
  {
    static string dir = @"C:\Repo"; // different from AppDomain.CurrentDomain.BaseDirectory
    public string path = System.IO.Path.Combine(dir, "MyDll.dll");

    AppDomain domain = AppDomain.CreateDomain("ItestDomain", null);



    public void Load(string path)
    {
      string[] files = Directory.GetFiles(path, "*.dll");
      foreach (string fil in files)
        Assembly.LoadFrom(fil);

    }

    public void LoadFile(string path)
    {
      // string[] files = Directory.GetFiles(path, "*.dll");
      // foreach (string fil in files)
      domain.Load(AssemblyName.GetAssemblyName(path));

    }

    public List<Type> GetTypesToTest()
    {
      //Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
      Assembly[] assems = domain.GetAssemblies();
      List<Type> ret = new List<Type>();
      foreach (Assembly assem in assems)
      {
        Type[] types = assem.GetTypes();
        foreach (Type type in types)
        {
          Type interf = type.GetInterface("ITest");
          if (interf != null)
            ret.Add(type);
        }
      }
      return ret;
    }

    public List<WrappedMessageList> GetTestInterface()
    {
      // Assembly[] assems = AppDomain.CurrentDomain.GetAssemblies();
      Assembly[] assems = domain.GetAssemblies();
      List<WrappedMessageList> ret = new List<WrappedMessageList>();
      foreach (Assembly assem in assems)
      {
        Type[] types = assem.GetTypes();
        foreach (Type type in types)
        {
          Type interf = type.GetInterface("ITest");
          if (interf != null)
            ret.Add(Invoker(type));
        }
      }
      return ret;
    }

    public  WrappedMessageList Invoker(Type type)
    {
      object testObj = Activator.CreateInstance(type);
      Type created = testObj.GetType();
      object[] args = new object[0];
      bool TestExecuted = false;
      List<string> ret1 = new List<string>();
      WrappedMessageList ret = null;

      //id = (string)created.InvokeMember(
      //  /* method name */ "id",
      //  /* action      */ BindingFlags.Default | BindingFlags.InvokeMethod,
      //  /* binder      */ null,
      //  /* instance    */ testObj,
      //  /* method args */ args
      //);


      // test may throw so prepare for that exception

      //TestExecuted = (bool)created.InvokeMember(
      //  /* method name */ "Test",
      //  /* action      */ BindingFlags.Default | BindingFlags.InvokeMethod,
      //  /* binder      */ null,
      //  /* instance    */ testObj,
      //  /* method args */ args
      //);
      Object result = created.InvokeMember(
        /* method name */ "test",
        /* action      */ BindingFlags.Default | BindingFlags.InvokeMethod,
        /* binder      */ null,
        /* instance    */ testObj,
        /* method args */ args
   );

      if (result != null)
      //  ret1 = (List<string>)created.InvokeMember(
      //    /* method name */ "GetMessage",
      //    /* action      */ BindingFlags.Default | BindingFlags.InvokeMethod,
      //    /* binder      */ null,
      //    /* instance    */ testObj,
      //    /* method args */ args
      //);
      {
        ret = new WrappedMessageList(result);
      }

     // ret = ConvertStringToMessage(ret1, type);

      return ret;
    }


    List<Messag> ConvertStringToMessage(List<string> ToConvert, Type type)
    {
      List<Messag> ret = new List<Messag>();
      foreach (string s in ToConvert)
      {
        XElement xdoc = XElement.Parse(s);
        Messag msg = new Messag();
        msg.Msg = xdoc.Element("Msg").Value;
        if (xdoc.Element("Passed").Value.ToString() == "True")
          msg.Passed = true;
        else
          msg.Passed = false;
        msg.TestID = Convert.ToInt32(xdoc.Element("TestID").Value.ToString());
        msg.AssemblyName = type.Assembly.GetName().Name;
        msg.TypeName = type.FullName;
        ret.Add(msg);
      }

      return ret;
    }



  }
}
