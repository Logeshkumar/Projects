﻿////////////////////////////////////////////////////////////////////////////////
// TagAdder.cs - Add tag to the valid password and then harsh it              //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yu Gu,   Syracuse University                                 //
//               315-751-7158, ygu06@syr.edu                                  //
////////////////////////////////////////////////////////////////////////////////

/*
  * Module Operations
  * =================
  * 
  * This class is a part of AuthServer Package, it will add tag to the valid password.
  * And then harsh it.
  * 
  * Tag will be generated by a random function. It has 16 characters. 
  * 
  * 
  * Public Interface
  * ================
  * public TagAdder(string ValidPassword)     // Constructor of the class TagAdder, it receives the Valid password
  * public string AddSalt()                   // Add salt to the password and then harsh it. Return harshed code
  * public string GetSalt()                    // Return tag
  * 
  */
/*
  * Build Process
  * =============
  * Required Files:
  *   GenerateSalt.cs
  *   HarshCodeConverter.cs
  *   
  * 
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 11 Oct 11
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
    public class TagAdder
    {
        //constructor
        public TagAdder(string ValidPassword) 
        {
            m_PasswordWithoutSalt = null;
            m_PasswordWithoutSalt = ValidPassword;
            m_Tag = null;
            m_Salt = new GenerateSalt();
            m_harshcode = new HarshCodeConverter();
            m_Tag = m_Salt.RandomSalt();
        }

        // call this function will add salt to original password
        // the return string is a harshed code from original password with salt 
        public string AddSalt() 
        {           
            m_PasswordWithSalt = m_PasswordWithoutSalt + m_Tag;
            return m_harshcode.Convert(m_PasswordWithSalt);
        }

        // return tag (without harsh)
        public string GetTag()
        {
            return m_Tag;
        }

        private HarshCodeConverter m_harshcode;
        private GenerateSalt m_Salt;
        private string m_PasswordWithoutSalt;
        private string m_PasswordWithSalt;
        private string m_Tag;
    }
}
