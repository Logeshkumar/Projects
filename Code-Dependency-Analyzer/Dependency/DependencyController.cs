///////////////////////////////////////////////////////////////////////
// DependencyController.cs - Manages to detect the file dependencies //
//                                                                   //
// Logeshkumar, CSE681 - Software Modeling and Analysis, Fall 2010   //
///////////////////////////////////////////////////////////////////////

/* The class DependencyController implements funtionalities to detect the file dependencies.
 * It gets the list of files inputted by the user from the FileModel.
 * A file is tokenized by the tokenizer.
 * The type table consists of typename and its associated files.
 * The first typename is taken and is compared with the tokenized file.
 * If the the token matches the key then it is checked if the current  file and file stored in the typetable for the corresponding typename
 * if both are equal, no dependencies .. next file is passed to tokenizer
 * Otherwise the current file and file associated with the typename is passed to Dependency Model.
 /*
 * Build Process:
 *   Required Files:
 *   FileModel.cs, TypeModel.cs, Toker.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeAnalysis;
namespace MVCDemo
{ 
    public class DependencyController
    {
        // This method detects the dependencies and passes the currentfile and dependent file to the DependencyModel for storage.

        public void findDependency(List<string> files)
        {
            TypeModel tm = new TypeModel();
            CStoker.CToker toker = new CStoker.CToker();
            toker.returnComments(false);
            string msg1;
            foreach (string file in files)
            {
                if (!toker.openFile(file))
                {
                    msg1 = "Can't open file " + file;
                    Console.Write("\n\n  {0}", msg1);
                    Console.Write("\n  {0}", new string('-', msg1.Length));
                }
                else
                {
                    string tok = "";
                    DependencyModel dm = new DependencyModel();
                    while ((tok = toker.getTok()) != "")
                        if (tok != "\n")
                            foreach (KeyValuePair<string, List<string>> key in tm.dictionary())
                                if (key.Key == tok)
                                {
                                    foreach (string filename in key.Value)
                                        if (file != filename)
                                            dm.addDependency(file, filename);
                                }
                    toker.close();
                }
            }
        }
    
        }
    }
