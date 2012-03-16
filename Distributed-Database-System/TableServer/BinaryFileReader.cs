using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace edu.syr.eskimodb.tableserver
{
  class testObj
  {
    int key;
    long data;
  }

  class TestWriter
  {

    public void CreateTable(string filename, int type, int size)
    {
      using (BinaryWriter binWriter = new BinaryWriter(File.Open(filename + ".dat", FileMode.Create)))
      {
        long headerPK;
        if (type == 1)
        {
          headerPK = 1;
        }
        else if (type == 2)
        {
          headerPK = 2;
        }
        else
        {
          headerPK = 3;
        }

        long patchHeader = 0;

        binWriter.Write(headerPK);
        binWriter.Write(patchHeader);
      }

    }

    private void bWriter()
    {
      string filename = "C:\\Users\\Priya\\Desktop\\TestBinary.dat";
      using (BinaryWriter binWriter = new BinaryWriter(File.Open(filename, FileMode.Create)))
      {
        long header_PK = 19;
        long header_padding = 87;
        int PK = 88;
        long RI = 99;
        int RorB = 11;
        int PK1 = 882;
        long RI1 = 992;
        int RorB1 = 2;
        int PK2 = 0; //empty entry
        long RI2 = 0; //empty entry
        int RorB2 = 0;//empty entry

        //Console.WriteLine("type of key is:" + key.GetType().Name.ToString());

        binWriter.Write(header_PK);
        binWriter.Write(header_padding);
        binWriter.Write(PK);
        binWriter.Write(RI);
        binWriter.Write(RorB);
        binWriter.Write(PK1);
        binWriter.Write(RI1);
        binWriter.Write(RorB1);
        binWriter.Write(PK2);
        binWriter.Write(RI2);
        binWriter.Write(RorB2);

      }

    }

    public void search(string fileName)
    {
      long header;
      long padding;
      int PKey1;
      long RIndex1;
      int color1;


      if (File.Exists(fileName))
      {
        BinaryReader binReader =
            new BinaryReader(File.Open(fileName, FileMode.Open));
        try
        {
          // If the file is not empty,
          // read the application settings.
          // First read 4 bytes into a buffer to
          // determine if the file is empty.

          //byte[] headerarray = new byte[15];
          //int count1 = binReader.Read(headerarray, 0, 15);
          //binReader.BaseStream.Seek(0, SeekOrigin.Begin);
          //if (count1 != 0)
          //{
          //  header = binReader.ReadInt64();
          //  padding = binReader.ReadInt64();

          //}
          byte[] testArray = new byte[63];
          int count = binReader.Read(testArray, 0, 63);
          binReader.BaseStream.Seek(0, SeekOrigin.Begin);
          if (count != 0)
          {
            // Reset the position in the stream to zero.
            header = binReader.ReadInt64();
            padding = binReader.ReadInt64();
            for (int i = 1; i <= 3; i++)
            {
              int size = 16 * i;
              binReader.BaseStream.Seek(size, SeekOrigin.Begin);
              PKey1 = binReader.ReadInt32();
              RIndex1 = binReader.ReadInt64();
              color1 = binReader.ReadInt32();
            }
          }
        }

        catch (EndOfStreamException e)
        {
          Console.WriteLine("{0} caught and ignored. " +
              "Using default values.", e.GetType().Name);
        }
        finally
        {
          binReader.Close();
        }
      }
    }

    static void Main(string[] args)
    {

      TestWriter tw = new TestWriter();
      tw.bWriter();
      tw.search("C:\\Users\\Priya\\Desktop\\TestBinary.dat");
      return;

    }
  }
 
}
