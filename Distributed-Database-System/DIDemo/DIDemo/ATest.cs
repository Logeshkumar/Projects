using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIDemo
{
    public class ATest : ITest
    {
        public bool doTest()
        {
            Console.WriteLine("Test in ATest");
            return true;
        }
    }
}
