////////////////////////////////////////////////////////////////////////////////
// RandTokenTest.cs - Test RandTokenGen.cs                                    //
// Language:     C# 4.0                                                       //
// Platform:     Windows Vista                                                //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yukan Zhang,   Syracuse University                           //
//               yzhan158@syr.edu                                             //
////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace edu.syr.cse784.eskimodb.authserver.test
{
    class RandTokenTest
    {
        static void Main(string[] args)
        {
            RandTokenGen randTokenGen = new RandTokenGen();
            string randToken;
            randToken = randTokenGen.Generator();
        }
    }
}
