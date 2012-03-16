using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace test_table_writer
{
  class Inserter
  {
    private BinaryWriter m_Writer;
    private BinaryReader m_Reader;
    private TableConfig m_Config;

    public void addKey(Value value)
    {
      m_Config.SeekToRootElement(m_Reader, m_Writer);
      Value curr = value.read(m_Reader);
      if(curr.LessThan(value)){
        m_Config.SeekRight(m_Reader);
      }
    }

    private void seekRight()
    {

      m_Reader
    }
  }
}
