using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Test
{
  // define a interface of one entry of the binary file (one node in RB tree)
  //Make Value as an abstract class and not an interface
  public abstract class Value : IComparable
  {   
    public abstract bool m_LessThan(Value other);

    private int m_pkLengh;
    private long m_rowIndex;
    private int m_color;
    private long m_leftChild;
    private long m_rightChild;

    public int m_PKLengh
    {
      get { return m_pkLengh; }
      set { m_pkLengh = value; }
    }

    public long m_RowIndex
    {
      get { return m_rowIndex; }
      set { m_rowIndex = value; }
    }

    public int m_Color
    {
      get { return m_color; }
      set { m_color = value; }
    }

    public long m_RightChild
    {
      get { return m_rightChild; }
      set { m_rightChild = value; }
    }

    public long m_LeftChild
    {
      get { return m_leftChild; }
      set { m_leftChild = value; }
    }

    public abstract int CompareTo(object obj);
    
  }



  public class IntValue : Value
  {
    private int m_PkValue;
    //====constructor===
    public IntValue()
    {
      this.m_PKLengh = 4;
    }
    public IntValue(int PrimaryKey, long RowIndex)
    {
      this.m_PKLengh = 4;
      this.m_PkValue = PrimaryKey;
      this.m_RowIndex = RowIndex;      
    }
    public IntValue(int PrimaryKey, long RowIndex, int color, long leftChild, long RightChild)
    {
      this.m_PKLengh = 4;
      this.m_PkValue = PrimaryKey;
      this.m_RowIndex = RowIndex;
      this.m_Color = color;
      this.m_LeftChild = leftChild;
      this.m_RightChild = RightChild;
    }
    //==================

    public int m_PKValue
    {
      get { return m_PkValue; }
    }    
    
    public override int CompareTo(object key)
    {
      if (m_PKValue > ((IntValue)key).m_PKValue)
        return 1;
      else
        if (m_PKValue < ((IntValue)key).m_PKValue)
          return -1;
        else
          return 0;
    }

    public override bool m_LessThan(Value other)
    {
      if (other is IntValue == false)
        return false;
      IntValue typed_other = (IntValue)other;
      return m_PKValue < typed_other.m_PKValue;
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

  }

}
