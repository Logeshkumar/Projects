using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.authserver.test
{
    class HarshCodeConverterTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Harsh Code Converter Demo");
            Console.WriteLine("Please Enter a Password!");
            string testString = Console.ReadLine();
            HarshCodeConverter testCase = new HarshCodeConverter();
            testString = testCase.Convert(testString);
            Console.WriteLine("The Converted Code is :");
            Console.WriteLine(testString);
        }
    }
}
