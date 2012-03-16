//////////////////////////////////////////////////////////////////////////////////
// RandTokenGen.cs - Generate a random token combined with alphabets and numbers//
// Language:     C# 4.0                                                         //
// Platform:     Windows Vista                                                  //
// Application:  CSE784 Final Project EskimoDb                                  //
// Author:       Yukan Zhang,   Syracuse University                             //
//               yzhan158@syr.edu                                               //
//////////////////////////////////////////////////////////////////////////////////

/*
  * Module Operations
  * =================
  * 
  * This class is a part of AuthServer Package.
  * it generates a random token which is combined with up and lower case alphabets and numbers.
  * 
  * 
  * 
  * Public Interface
  * ================
  * public RandTokenGen()                    //constructor
  * public string Generator() //generator a random token
  *
  */
/*
  * Build Process
  * =============
  * Required Files:
  *
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 18 Oct 11
  *   - first release
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.authserver
{
    class RandTokenGen
    {
        public RandTokenGen()
        { 
        }

        public string Generator()
        {
            string ret;
            return ret = RandStringGen();
        }
        //The character in the random token is picked from the pool.
        private string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //A random number from 0 to 61 is generated.
        private int RandNumGen(int min, int max, int i)
        {
            //The seed is changed with time.
            Random m_Rand = new Random((int)DateTime.Now.Ticks + i);
            int ret;
            return ret = m_Rand.Next(min, max);

        }
        //A random string is built.
        private string RandStringGen()
        {
            int m_index;
            StringBuilder randToken = new StringBuilder();

            for (int i = 0; i < 64; i++)
            {
                m_index = RandNumGen(0,61,i);
                randToken.Append(pool[m_index]);
            }

            string ret;
            return ret = randToken.ToString();

        }


    }
}
