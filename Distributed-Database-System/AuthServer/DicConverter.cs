////////////////////////////////////////////////////////////////////////////////
// DicConverter -  Convert the dictionary into 9-character password dictionary//
//                                                                            //
// version 1.0                                                                //
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
  * This class is a relatively independent class from the others.
  * it will be called when a new dictionary need to be converted.
  * 
  * 
  * 
  * Public Interface
  * ================
  * public DicConverter()      //constructor
  * public void Converting (string filename)  //get the input file, modify it and output a new file.
  *
  */
/*
  * Build Process
  * =============
  * Required Files:
  *   DICT.TXT
  * 
  * Maintenance History
  * ===================
  * 
  * ver 1.0 : 5 Oct 11
  *   - first release
  * ver 1.1 : 13 Oct 11
  *   - add public void Converting()
  */
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace edu.syr.cse784.eskimodb.authserver
{
    // This is the class to modify a user provided dictionary 
    // such that the all words whose lengths are less than 9 will be removed
    class DicConverter
    {
        
        public DicConverter()
        {           
        }

        public void Converting(string filename)
        {
            string f_Input = null;
            f_Input = InputFile(filename);

            List<string> f_Modified = new List<string>();
            f_Modified = Filter(f_Input);

            FinishConverting(f_Modified);
            
        }
        //The input file should be put under the directory "test-cases\"
        private string InputFile(string filename)
        {
            TextReader reader = new StreamReader("test-cases\\" + filename); 
            string ret = reader.ReadToEnd();
            reader.Close();
            return ret;
        }

        private List<string> Filter(string input)
        {
            List<string> ret = new List<string>();
            List<string> modified = new List<string>();
            string temp = null;

            for (int i = 0; i < input.Length; i++)
            {
                temp += input[i];
                if (input[i] == '\n')
                {
                   modified.Add(temp);
                   temp = null;
                }
            }

            for (int i = 0; i < modified.Count; i++)
            {
                if (modified[i].Length < 10)
                {
                    modified.RemoveRange(i, 1);
                    i--;
                }
            }
            
            return ret = modified;
        }
        //The output file will be located under the directory "test-cases\"
        private void FinishConverting(List<string> file)
        {
            using (TextWriter output = File.CreateText("test-cases\\Dict_9.txt"))
            {
                for (int i = 0; i < file.Count; i++)
                {
                    output.Write(file[i]);
                }
                output.Close();
            }
        }
    }
}
