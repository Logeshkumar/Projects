using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace htmlreport
{
  class Program
  {
    static void Main(string[] args)
    {
      html report = new html();
      report.path = "C:\\Users\\zhuandbao\\Desktop\\test";
      report.build();
    }
  }
}
