////////////////////////////////////////////////////////////////////////////////
// GenerateSalt.cs -  generate a 16 character-salt                            //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yu Gu                                                        //
//               ygu06@syr.edu                                                //
////////////////////////////////////////////////////////////////////////////////

/*
  * Module Operations
  * =================
  * 
  * This class is a part of AuthServer Package, it will randomly generate 
  * a 16 characters salt and return it. The set of the characters are 
  * "ABCDEFGHIGKLMNOPQRSTUVWXYZabcdefghigklmnopqrstuvwxyz1234567890"
  *  
  * 
  * 
  * Public Interface
  * ================
  * public string RandomSalt()
  * 
  */
/*
  * Build Process
  * =============
  * Required Files:
  *   None
  *   
  * 
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 13 Oct 11
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
    // This is the class to generate 16 characters log random salt tag
    public class GenerateSalt
    {        
        public string RandomSalt()
        {
            string m_SaltString = null;
            //generate the random seed
            string charlist="ABCDEFGHIGKLMNOPQRSTUVWXYZabcdefghigklmnopqrstuvwxyz1234567890";
            Random random = new Random((int)DateTime.Now.Ticks);

            // generate a random 16 character salt and return it
            for( int i = 0; i < 16 ; i++)
            {
                int j = random.Next(0, 61);
                m_SaltString += (charlist[j]);
            }
            return m_SaltString;
        }
    }
}
