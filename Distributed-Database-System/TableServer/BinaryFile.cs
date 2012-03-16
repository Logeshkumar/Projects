using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.eskimodb.tableserver
{
   public interface IBinaryFile
  {
    //void ParseHeader(string filename);
    long GetRowSize();
    long GetPrimaryKeySize(long inputTypeCode);
    DataTypes GetPrimaryKeyType();
  }


    public enum DataTypes
    {
      integer = 0,  //4 Bytes
      Double = 1,   //8 Bytes
      Float = 2,    //4 Bytes
      Char = 3,     //2 Bytes
      Varchar = 4,  //4 Bytes??
      biglong = 5,  //4 Bytes??
      Short = 6,    //2 Bytes
      Long = 7,     //8 Bytes

    };
  

   public class BinaryFile : IBinaryFile
  {
    
    public long GetRowSize()
    {
      return 13;
    }
    public  int GetPrimaryKeySize(long inputTypeCode)
    {
      // switch statement determine inputTypeCode , return corresponding size 
      return (int)DataTypes.Long;
    }

    public DataTypes GetPrimaryKeyType()
    {
      return DataTypes.integer;
    }



    long IBinaryFile.GetPrimaryKeySize(long inputTypeCode)
    {
      throw new NotImplementedException();
    }
  }

   
}
