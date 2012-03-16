using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace htmlreport
{
  public class html
  {
    public string path;
    string[] xmlcont;
    string[] htmlnode;
    public void loadfile()
    {
      xmlcont = Directory.GetFiles(@path,"*.xml");
      for (int i = 0; i < xmlcont.Length; i++)
        htmlnode.SetValue(loadinfo(xmlcont[i]), i);
       
    }
    public string loadinfo(string path)
    {
      string content = null;
      try
      {
        XmlTextReader textReader = new XmlTextReader(path);
        content = ReadXml(textReader);
       
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return content;
    }

    private string ReadXml(XmlTextReader reader)
    {
      string read=" ";
      try
      { 
        while (reader.Read())
        {
          switch (reader.NodeType)
          {
            case XmlNodeType.Element:
              if (reader.IsEmptyElement) 
              {
                Console.WriteLine("<{0}/>", reader.Name);
              }
              else
              {
                Console.Write("<{0}", reader.Name);
                if (reader.HasAttributes)   
                {
                  while (reader.MoveToNextAttribute())
                  {
                    Console.Write(" {0}=\"{1}\"", reader.Name, reader.Value);
                  }
                }
                Console.WriteLine(">", reader.Name);
              }
              break;
            case XmlNodeType.Text:
              read = reader.Value;
              Console.WriteLine(reader.Value);
              break;
            case XmlNodeType.CDATA:
              Console.WriteLine("<![CDATA[{0}]]>", reader.Value);
              break;
            case XmlNodeType.ProcessingInstruction:
              Console.WriteLine("<?{0} {1}?>", reader.Name, reader.Value);
              break;
            case XmlNodeType.Comment:
              Console.WriteLine("<!--{0}-->", reader.Value);
              break;
            case XmlNodeType.XmlDeclaration:
              Console.WriteLine("<?xml version='1.0'?>");
              break;
            case XmlNodeType.Document:
              break;
            case XmlNodeType.DocumentType:
              Console.WriteLine("<!DOCTYPE {0} [{1}]>", reader.Name, reader.Value);
              break;
            case XmlNodeType.EntityReference:
              Console.WriteLine(reader.Name);
              break;
            case XmlNodeType.EndElement:
              Console.WriteLine("</{0}>", reader.Name);
              break;
          }
        }
      }
      catch (XmlException ex)
      {
        Console.WriteLine(ex.Message);
      }
      return read;
    }
    
    public string context()
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 1; i <= htmlnode.Length; i++)
      {
        sb.AppendLine("" + xmlcont[i] + "");
        sb.AppendLine("<tr "+htmlnode[i]+" \tr>");
      }
      return sb.ToString();
    }
    public void build()
    {
      loadfile();
      FileStream fs = File.OpenWrite(path +"htmlreport.html");
      StreamWriter writer = new StreamWriter(fs, Encoding.UTF8);
      writer.Write(context());
      writer.Close();

    }
  }
}
