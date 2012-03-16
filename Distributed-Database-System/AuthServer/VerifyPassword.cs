////////////////////////////////////////////////////////////////////////////////
// VerifyPassword.cs - Verify the password when a new username is created     //
// Language:     C# 4.0                                                       //
// Platform:     Windows Vista                                                //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yukan Zhang,   Syracuse University                           //
//               yzhan158@syr.edu                                             //
////////////////////////////////////////////////////////////////////////////////

/*
  * Module Operations
  * =================
  * 
  * This class is a part of AuthServer Package.
  * it checks the length, characters of the password, and compares it with the word in the dictionary.
  * 
  * 
  * 
  * Public Interface
  * ================
  * public VerifyPassword()                    //constructor
  * public bool CheckPassword(string password) //verify the password
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
  * ver 1.0 : 12 Oct 11
  *   - first release
  * 
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace edu.syr.cse784.eskimodb.authserver
{
    class VerifyPassword
    {
        public VerifyPassword() 
        {
        }

        public bool CheckPassword(string Password, out string msg)
        {
            if (CheckLength(Password,out msg))
            {
                if (CheckSpecChar(Password, out msg))
                {
                    if (CheckDict(Password, out msg))
                    {
                        return true;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        // The length of the password should be longer than 8 and shorter than 16 
        private bool CheckLength(string Password, out string msg)
        {
            msg = null;
            if (Password.Length < 9)
            {
                msg = "The Password should be longer than 8 characters!";
                Console.WriteLine("The Password should be longer than 8 characters!");
                return false;
            }
            else if (Password.Length > 16)
            {
                msg = "The Password should be shorter than 16 characters!";
                Console.WriteLine("The Password should be shorter than 16 characters!");
                return false;
            }
            else 
                return true;

        }
        //Special punctuation should not be included in the password
        private bool CheckSpecChar(string Password, out string msg)
        {
            msg = null;
            for (int i = 0; i < Password.Length; i++)
            {
                if ((Password[i] == '/') || (Password[i] == '\\') || (Password[i] == '*')
                    || (Password[i] == ':') || (Password[i] == ';') || (Password[i] == '"')
                    || (Password[i] == '<') || (Password[i] == '>') || (Password[i] == '?'))
                {
                    msg = "The Password should not include: /\\*?\":;<>";
                    Console.WriteLine("The Password should not include: /\\*?\":;<>");
                    return false;
                }
            }
            return true;
        }
        //Compare the password with the word in the dictionary under the directory "test-cases\"
        private bool CheckDict(string Password, out string msg) 
        {
            msg = null;
            TextReader reader = new StreamReader("test-cases\\Dict_9.txt");
            string passwordDictString = reader.ReadToEnd();
            reader.Close();
            List<string> passwordDict = new List<string>();
            string temp = null;
            for (int i = 0; i < passwordDictString.Length; i++)
            {
                if (passwordDictString[i] == '\r')
                {
                    if (Password == temp)
                    {
                        msg = "The Password should not be a word in the Dictionary!";
                        Console.WriteLine("The Password should not be a word in the Dictionary!");
                        return false;
                    }
                    i++;
                    temp = null;
                }
                else if (passwordDictString[i] != '\r')
                {
                    temp += passwordDictString[i]; 
                }
            }
            return true;
        }
    }
}
