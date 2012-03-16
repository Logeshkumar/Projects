/////////////////////////////////////////////////////////////////////////////
//  Layers.cs -    Indents the list of lines acording to specification     //
//  Language:      Visual C# 4.0    				                                 //
//  Platform:      Windows 7								                               //
//  Application:   Code Indentor      			                               //
//  Author:        logeshkumar								                             //
/////////////////////////////////////////////////////////////////////////////

/*
Maintainence History:
=====================
ver 1.0 04 October 2011
- first release
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Project1TestHarness {
  class Layers {
    static string[] b = null;
    Storage r = new Storage();

    // Passing the list to layers of functions which operate on th list for proper indentation
    public List<string> setList(List<string> lis){
      List<string> li = new List<string>();
      Layers lay = new Layers();
      lay.BracketSplit(lis);
      li = lay.Bracket();
      r.clear1();
      r.clear3();
      return li;
    }

    // initially breaking the list of string according to braces(both open and close braces)
    public void BracketSplit(List<string> lis){
      List<string> li = new List<string>();
      string brac = null;
      Layers lay = new Layers();
      foreach (string line in lis){
        brac += line;
        if (line.Contains("{") && !line.Contains("\"")){
          li.Add(brac);
          brac = "";
        } else if (line.Contains("}") && !line.Contains("\"")){
          li.Add(brac);
          brac = "";
        }
      }
      lay.SemicolonSplit(li);
    }

    // splitting according to semicolon
    public void SemicolonSplit(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string lin in lis){
        string semiSpace = lin.Replace(" ;", ";");
        string line = semiSpace.Trim();
        if (line.Contains(";")){
          b = line.Split(';');
          int i = 1;
          foreach (string l in b){
            if (l != ""){
              if (i == b.Length){
                li.Add(l);
              } else {
                i++;
                string semi = l.Insert(l.Length, ";");
                li.Add(semi);
              }
            }
          }
        } else {
          li.Add(line);
        }
        b = null;
      }
      lay.BracketHierarchy(li);
    }

    //adding brackets for else if , else if it is not present
    public void BracketHierarchy(List<string> lis){
      Layers lay = new Layers();
      int flag = 0;
      List<string> li = new List<string>();
      foreach (string line in lis){
        if (line.Contains("else if")){
          int i = 0;
          i = line.IndexOf(")");
          if (line.Contains(") {") || line.Contains("){") && (line.Length > i + 2)){
            if (line[i + 2] != '{'){
              string h = line.Insert(i + 1, "{");
              flag = 1;
              li.Add(h);
            } else {
              li.Add(line);
            }
          } else {
            li.Add(line);
          }
        } else if(flag == 1){
          if (line.Contains("else") && !line.Contains("if")){
            flag = 2;
            li.Add(line);
          } else {
            li.Add(line);
          }
        } else if (flag == 2){
          string h = line.Replace(";", ";\n}");
          li.Add(h);
          flag = 0;
        } else {
          li.Add(line);
        }
      }
      lay.DotNormalizer(li);
    }
    
    // no space between the dot operator
    public void DotNormalizer(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string line in lis){
        if (line.Contains(".") && !line.Contains("using")){
          int i = line.IndexOf(".");
          if (line[i - 1] == ' ' && line[i + 1] == ' '){
            string g = line.Replace(" . ", ".");
            li.Add(g);
          } else if ((line[i - 1] == ' ' && line[i + 1] != ' ') || (line[i - 1] != ' ' && line[i + 1] == ' ')){
            int j = line.IndexOf(".");
            if (line[i + 1] == ' '){
              string g = line.Replace(". ", ".");
              li.Add(g);
            } else {
              string g = line.Replace(" .", ".");
              li.Add(g);
            }
            li.Add(line);
          } else {
            li.Add(line);
          }
        } else {
          li.Add(line);
        }
      }
      lay.ParanthesisNormalizer(li);
    }

    // normalizing parathesis.. without spaces wherever necessary
    public void ParanthesisNormalizer(List<string> lis){
      List<string> li = new List<string>();
      Layers lay = new Layers();
      foreach (string line in lis){
        string j = null;
        string g = null;
        string n = null;
        string m = null;
        if (line.Contains('(') && line.Contains(')')){
          j = line.Replace(" (", "(");
          g = j.Replace(" )", ")");
          n = g.Replace("( ", "(");
          m = n.Replace(") ", ")");
          li.Add(m);
        } else if (line.Contains("(")){
          j = line.Replace(" (", "(");
          n = j.Replace("( ", "(");
          li.Add(n);
        } else if (line.Contains(")")){
          g = line.Replace(" )", ")");
          m = g.Replace(") ", ")");
          li.Add(m);
        } else {
          li.Add(line);
        }
      }
      lay.forcontrol(li);
    }

    // making sure the for control is in a single line 
    //rather than splitted by semicolons.
    public void forcontrol(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      string j = null;
      int flag = 0;
      foreach (string line in lis){
        if (line.Contains("for")){
          j += line;
          if (line.Contains(")")){
            li.Add(line);
          } else {
            flag = 1;
          }
        } else if(flag == 1){
          j += line;
          if (line.Contains(")")){
            li.Add(j);
            flag = 0;
          }
        } else if(flag == 0){
          li.Add(line);
        }
      }
      lay.addbrackets(li);
    }

    // adding brackets for the controls for,else,if and while
    //in the case they dont have open and close braces.
    public void addbrackets(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string line in lis){
        if (line.Contains("for") && !line.Contains("{")){
          string g = line.Replace(")", "){");
          string h = g.Insert(g.Length, "}");
          if (h.Contains("{;")){
            string j = h.Replace("{;", ";\n");
            li.Add(j);
          } else {
            li.Add(h);
          }
        } else if (line.Contains("while") && !line.Contains(");") && !line.Contains("()")){
          string j = line.Replace(")", "){");
          string h = j.Replace(";", ";\n}");
          li.Add(h);
        } else if (line.Contains("if") && !line.Contains("{") && !line.Contains("else")){
          string j = line.Replace(")", "){");
          string h = j.Replace(";", ";\n}");
          li.Add(h);
        } else if (line.Contains("else") && !line.Contains("{") && !line.Contains("if")){
          string j = line.Replace("else", "else{");
          string h = j.Replace(";", ";\n}");
          li.Add(h);
        } else {
          li.Add(line);
        }
      }
      lay.OpenBracesSplit(li);
    }

    // splitting according to open brackets
    public void OpenBracesSplit(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string lin in lis){
        string line = lin.Trim();
        if (line.Contains("{") && !line.Contains("\"")){
          b = line.Split('{');
          if (b[0] == ""){
            string semi = b[0].Insert(0, "{");
            li.Add(semi);
            continue;
          }
          foreach (string l in b){
            if (l != ""){
              if (l.Contains("for")){
                string semi = l.Insert(l.Length, "{");
                li.Add(semi);
              } else if (!l.Contains(";")){
                string semi = l.Insert(l.Length, "{");
                li.Add(semi);
              } else {
                li.Add(l);
              }
            }
          }
        } else {
          li.Add(line);
        }
      }
      lay.CloseBracesSplit(li);
    }

    // splitting according to close brackets
    public void CloseBracesSplit(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string lin in lis){
        string line = lin.Trim();
        int i = 0;
        if (line.Contains("}") && !line.Contains("while") && !line.Contains("\"")){
          b = line.Split('}');
          foreach (string l in b){
            if (l.Contains("\n")){
              string d = l.Replace("\n", "");
              li.Add(d);
            } else if (l != " "){
              i++;
              if (l != ""){
                if (!l.Contains(";")){
                  li.Add(l);
                }
              } else if (l == "" && i != b.Length){
                li.Add("}");
              }
            }
          }
        } else {
          li.Add(line);
        }
      }
      lay.SpaceAdder(li);
    }

    // adding space wherever necessary..
    public void SpaceAdder(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string line in lis){
        if (line.Contains(".") && !line.Contains("using")){
          if (line.Contains("+")){
            string h = line.Replace("+", " + ");
            li.Add(h);
          } else {
            li.Add(line);
          }
        } else {
          li.Add(line);
        }
      }
      lay.elsecontrol(li);
    }

    // normalizing the else control to make sure that there is 
    //space before and after else between the close and open braces
    public void elsecontrol(List<string> lis){
      List<string> li = new List<string>();
      int i = 0;
      foreach (string line in lis){
        i++;
        if (line.Contains("else") && !line.Contains("if")){
          string h = li[i - 2].Replace("}", "} " + line);
          li[i - 2].Remove(0);
          li[i - 2] = h;
          i--;
        } else {
          li.Add(line);
        }
      }
      Layers lay = new Layers();
      lay.elseifcontrol(li);
    }

    // normalizing the else if control to make sure that
    // there is a space before else if control.
    public void elseifcontrol(List<string> lis){
      List<string> li = new List<string>();
      int i = 0;
      foreach (string line in lis){
        i++;
        if (line.Contains("else if")){
          string h = li[i - 2].Replace("}", "} " + line);
          li[i - 2].Remove(0);
          string g = h.TrimStart();
          li[i - 2] = g;
          i--;
        } else {
          li.Add(line);
        }
      }
      Layers lay = new Layers();
      lay.IndentNormalizer(li);
    }

    // leaving space between the brackets according to the type .. i.e whether namespace and etc..
    public void IndentNormalizer(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string lin in lis){
        Regex r = new Regex(@"\s+");
        string reg = r.Replace(lin, @" ");
        string trim = reg.Trim();
        string s = trim.TrimStart();
        string line = s.TrimEnd();
        if (line.Contains("namespace") || line.Contains("class")){
          if (line.Contains(" {")){
            li.Add(line);
          } else {
            string h = line.Replace("{", " {");
            li.Add(h);
          }
        } else if (line.Contains("else if")){
          string h = null;
          if (line.Contains(" {")){
            h = line.Replace(" {", "{");
            if (!h.Contains("} ")){
              string g = h.Replace("}", "} ");
              li.Add(g);
            } else {
              li.Add(h);
            }
          } else if (!line.Contains("} ")){
            string g = line.Replace("}", "} ");
            li.Add(g);
          } else {
            li.Add(line);
          }
        } else {
          li.Add(line);
        }
      }
      lay.ControlNormalizer(li);
    }

    // Verifies the spacing for the else and if controls
    public void ControlNormalizer(List<string> lis){
      Layers lay = new Layers();
      List<string> li = new List<string>();
      foreach (string line in lis){
        if (line.Contains("else") && !line.Contains("if")){
          if (line.Contains("} ") && !line.Contains(" {")){
            string h = line.Replace("{", " {");
            li.Add(h);
          } else if (!line.Contains("} ") && line.Contains(" {")){
            string g = line.Replace("}", "} ");
            li.Add(g);
          } else {
            li.Add(line);
          }
        } else if (line.Contains("if") && !line.Contains("else")){
          if (line.Contains(" {")){
            string h = line.Replace(" {", "{");
            li.Add(h);
          } else if (line.Contains("{")){
            string h = line.Replace(" {", "{");
            li.Add(line);
          } else {
            li.Add(line);
          }
        } else {
          li.Add(line);
        }
      }
      r.setContainer2(li);
    }

    // a function which adds space to the string in the front 
    public static string Indent(int count){
      return "".PadLeft(count * 2);
    }

    // adding spaces in the front according to the brackets.
    public List<string> Bracket(){
      int count = 0;
      List<string> lis = new List<string>();
      List<string> li = new List<string>();
      lis = r.getContainer2();
      foreach (string b in lis){
        string trim = b.Trim();
        string s = trim.TrimStart();
        string line = s.TrimEnd();
        if (line.Contains('{') && !line.Contains("\"")&& !line.Contains("else")){
          string j = Layers.Indent(count) + line;
          li.Add(j + "\r\n");
          count++;
        } else if (line.Contains('}') && !line.Contains("\"")&& !line.Contains("else")){
          count--;
          string j = Layers.Indent(count) + line;
          if (count == 0){
            string h = Layers.Indent(count) + line;
            li.Add(h + "\r\n");
          } else {
            li.Add(j+ "\r\n");
          }
        } else if(line.Contains("else")){
            count--;
          string j = Layers.Indent(count) + line;
            li.Add(j + "\r\n");
            count++;
          } else {
          string j = Layers.Indent(count) + line;
          li.Add(j + "\r\n");
        }
      }
      return li;
    }
  }
}
