﻿/*
 * TokenProcessor.cs
 * This module is responsible for getting tokens from the set of tokens
 * generated by the Antlr3 grammar.
 * 
 * @Author: Satyajeet N Desale
 * @Date: 10/13/2011
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 10/13/2011 - first release.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.rootserver
{
  public class TokenProcessor
  {
    private string m_TokenFilePath;
    private static Dictionary<int,string> m_TokenDictionary;

    public TokenProcessor()
    {
      m_TokenFilePath = "..\\..\\Query.tokens";
      m_TokenDictionary = null;
    }

    /*
     * private function to fill dictionary with available tokens 
     * @param none
     * @returns none
     */
    private void FillDictionary()
    {
      string line,tokenName;
      int id,pos;
      m_TokenDictionary = new Dictionary<int, string>();

      System.IO.StreamReader file = new System.IO.StreamReader(m_TokenFilePath);
      
      if (file == null)
        throw new Exception("Cannot open token file");

      while ((line = file.ReadLine()) != null)
      {
        if (!line.Contains("T__"))
        {
          pos = line.LastIndexOf('=');

          tokenName = line.Substring(0, pos);
          
          id = Convert.ToInt32(line.Substring(pos + 1));
          
          m_TokenDictionary.Add(id, tokenName);
          
        }
      }
    }

    /*
     * public function to get tokens from the file
     * @param none
     * @returns none
     */
    public string GetTokenName(int id)
    {
      if (m_TokenDictionary == null)
        FillDictionary();

      string tokenName = m_TokenDictionary[id];

      if(tokenName == null)
        return "";
      return tokenName;
    }


  }
}
