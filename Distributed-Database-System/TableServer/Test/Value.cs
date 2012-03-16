using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace edu.syr.eskimodb.tableserver
{
  // define a interface of one entry of the binary file (one node in RB tree)
  interface Value
  {
    void capture(string value);
    Value read(BinaryReader reader);
    void write(BinaryWriter writer);
    bool LessThan(Value other);
    int PKLengh();
  }



  class IntValue : Value
  {    
    int PkLengh;

    int PkValue;
    long RowIndex;
    int color;
    long leftChild;
    long rightChild;


    public IntValue(int PkTpye)
    {
      PkLengh = PkTpye;
    }


    public int PKLengh()
    {
       return PkLengh; 
    }

    public int PKValue
    {
      get { return PkValue; }
    }
    public long ROWIndex
    {
      get { return RowIndex; }
    }
    public int Color
    {
      get { return color; }
    }

    public long RightChild
    {
      get { return rightChild; }
    }

    public long LeftChild
    {
      get { return leftChild; }
    }

    public void capture(string str)
    {
       int PkValue = int.Parse(str);
    }

    public Value read(BinaryReader reader)
    {
      IntValue ret = new IntValue(4);
      ret.PkValue = reader.ReadInt32();
      ret.RowIndex = reader.ReadInt64();
      ret.color = reader.ReadInt32();
      return ret;
    }

    public bool LessThan(Value other)
    {
      if (other is IntValue == false)
        return false;
      IntValue typed_other = (IntValue)other;
      return PKValue < typed_other.PKValue;
    }

    public bool AddNodeIntoFile(int PrimaryKey, long RowIndex, int color, long leftChild, long RightChild, string Tablename)
    {

      string filename = "C:\\Temp\\" + Tablename + ".dat";
      using (BinaryWriter binWriter = new BinaryWriter(File.Open(filename, FileMode.Create)))
      {

        binWriter.Write(PrimaryKey);
        binWriter.Write(RowIndex);
        binWriter.Write(color);
        binWriter.Write(leftChild);
        binWriter.Write(RightChild);
      }

      return true;
    }


    public void write(BinaryWriter writer)
    {
      throw new NotImplementedException();
    }
  }

  class LongValue : Value
  {
    int PkLengh;

    long PkValue;
    long RowIndex;
    int color;
    long rightChild;
    long leftChild;

    public LongValue(int PkTpye)
    {
      PkLengh = PkTpye;
    }

    public int PKLengh()
    {
      return PkLengh; 
    }

    public long PKValue
    {
      get { return PkValue; }
    }
    public long ROWIndex
    {
      get { return RowIndex; }
    }
    public int Color
    {
      get { return color; }
    }

    public long RightChild
    {
      get { return rightChild; }
    }

    public long LeftChild
    {
      get { return leftChild; }
    }


    public void capture(string str)
    {
      PkValue = long.Parse(str);
    }

    public Value read(BinaryReader reader)
    {
      LongValue ret = new LongValue(8);
      long val = reader.ReadInt64();
      ret.RowIndex = reader.ReadInt64();
      ret.color = reader.ReadInt32();
      ret.PkValue = val;
      return ret;
    }
    public bool LessThan(Value other)
    {
      if (other is LongValue == false)
        return false;
      LongValue typed_other = (LongValue)other;
      return PkValue < typed_other.PKValue;
    }

    public void write(BinaryWriter writer)
    {
      throw new NotImplementedException();
    }


    public bool AddNodeIntoFile(long PrimaryKey, long RowIndex, int color, long leftChild, long RightChild, string Tablename)
    {

      string filename = "C:\\Temp\\" + Tablename + ".dat";
      using (BinaryWriter binWriter = new BinaryWriter(File.Open(filename, FileMode.Create)))
      {

        binWriter.Write(PrimaryKey);
        binWriter.Write(RowIndex);
        binWriter.Write(color);
        binWriter.Write(leftChild);
        binWriter.Write(RightChild);
      }

      return true;
    }

  }

  ////external interface
  //public void insert(string value, TypeEnum type)
  //{
  //  Value key_to_insert;
  //  if (type == TypeEnum.Integer)
  //  {
  //    key_to_insert = new IntValue();
  //  }
  //  else if (type == TypeEnum.Float)
  //  {
  //    key_to_insert = new FloatValue();
  //  }
  //  key_to_insert.capture(str);
  //  KeyInserter inseter = new KeyInserter();
  //  inseter.insert(key_to_insert);
  //}
}
