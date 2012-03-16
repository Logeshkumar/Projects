using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MessageExample
{
  public class WrappedMessageList
  {
    private Object m_Object;
    public WrappedMessageList(Object obj)
    {
      m_Object = obj;
    }

    public int getCount()
    {      
      PropertyInfo prop = m_Object.GetType().GetProperty("Count");
      return (int)prop.GetValue(m_Object, null);

    }

    public Message getMessage(int index)
    {
      PropertyInfo prop = m_Object.GetType().GetProperty("Item");
      return (Message)prop.GetValue(m_Object, new object[] { index });
    }
  }
}
