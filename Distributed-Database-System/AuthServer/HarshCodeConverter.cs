////////////////////////////////////////////////////////////////////////////////
// HarshCodeConverter.cs - Convert a string to a harshed code                 //
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
  * This class is a part of AuthServer Package, this class HarshCodeConverter are
  * able to convert a string to a harshed code and return it.
  * 
  * The input are original password with salt 
  * 
  * 
  * Public Interface
  * ================
  *  public string Convert(string Password)  - convert original password with salt to string
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
  * ver 1.0 : 4 Oct 11
  *   - first release
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.authserver
{
    class HarshCodeConverter
    {
        //The HarshCode Convert Function
        public string Convert(string Password)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            string ret = null;
            byte[] hashValue;
            byte[] message = ue.GetBytes(Password);

            SHA256Managed hashString = new SHA256Managed();

            hashValue = hashString.ComputeHash(message);

            foreach (byte x in hashValue)
                ret += String.Format("{0:x2}", x);

            return ret;
        }
    }
}