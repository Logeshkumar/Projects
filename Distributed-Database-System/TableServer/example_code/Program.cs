using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace test_table_writer
{
  class Program
  {
    interface Value
    {
      void capture(string str);
      void write();
      void read();
      string toString();
    }

    class IntValue : Value
    {
      BinaryWriter m_Writer;
      BinaryReader m_Reader;
      int value;

      public void capture(string str)
      {
        value = int.Parse(str);
      }
      public void write()
      {
        m_Writer.Write(value);
      }

      public void read()
      {
        value = m_Reader.Read();
      }
      public string toString()
      {
        return value.ToString();
      }

      public Value read(BinaryReader reader)
      {
        IntValue ret = new IntValue();
        int val = reader.ReadInt32();
        ret.value = val;
        return ret;
      }
      public bool LessThan(Value other)
      {
        if (other is IntValue == false)
          return false;
        IntValue typed_other = (IntValue)other;
        return value < typed_other.value;
      }
    }

    BinaryWriter m_Writer;

    void addKey(Value value)
    {
      
  


    }
    static void Main(string[] args)
    {
    }
  }
}
