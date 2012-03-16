using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver
{
  enum RequestType
  { 
    EXECUTE_QUERY, ROOTSERVER_SHUTDOWN, GET_RESULT, RELEASE, DB_QUERY
  };

  class Request
  {
    private IRootServerCallback m_IRootServerCallback;
    private string m_CallingMethod;
    private ITableServer m_TableServer;
    private Object[] m_MethodParameters = null;
    private RequestType m_RequestType;
    
    public void SetRequestType(RequestType requestType)
    {
      m_RequestType = requestType;
    }

    public RequestType getRequestType()
    {
      return m_RequestType;
    }

    public IRootServerCallback getRootServerCallback()
    {
      return m_IRootServerCallback;
    }

    public void SetRootServerCallback(IRootServerCallback callback)
    {
      m_IRootServerCallback = callback;
    }

    public void SetCallingMethod(string methodName)
    {
      m_CallingMethod = methodName;    
    }

    public string getCallingMethod()
    {
      return m_CallingMethod;
    }

    public ITableServer getTableServerObject()
    {
      return m_TableServer;    
    }

    public void setTableServerObject(ITableServer iTableServer)
    {
      m_TableServer = iTableServer;
    }

    public void SetMethodParameters(Object[] parameters)
    {
      m_MethodParameters = new Object[parameters.Length];
      parameters.CopyTo(m_MethodParameters, 0);
    }

    public Object[] getMethodParameters()
    {
      return m_MethodParameters;
    }
    
  }
}
