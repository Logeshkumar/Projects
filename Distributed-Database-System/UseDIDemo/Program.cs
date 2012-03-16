using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.usedidemo
{
  class Program:ICallback
  {
    public string func()
    {
      return this.GetType().ToString();
    }

    static void Main(string[] args)
    {
      depinject.DependencyInjection di = depinject.DependencyInjection.GetInstance();
      di.SetConfig(args[0]);
      Program client = new Program();
      object[] info = new object[3];
      info[0] = client;
      IExample example = (IExample)di.CreateObject("my example",info);
      Console.WriteLine(example.Say("hello"));
      Console.ReadKey();
    }
  }
}
