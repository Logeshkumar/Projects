/*
 * TalbeResponse.cs
 * when root call command to Table server, Table server response this object 
 * 
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 12/5/2011 - v1.1
 *   
 * 12/5/2011 - first release.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.sharedobjs
{

   /* The class constructor is used to set the message.
   * getMessage() is responsible for retrieving the response message.
   * @param m_message is used to set and retrieve a response message.
   */
  public class TableResponse
  {
    bool m_response;
    string m_message;
    string m_response_id;

    /*
     * @param m_response is the bool result for this command.
     * @param m_message is the detailed message for this command.
     * @param m_response_id is for identifying retrieve data. (for select command)
     */
    public TableResponse(bool response, string message, string resId)
    {
      m_message = message;
      m_response = response;
      m_response_id = resId;
    }

    public bool GetResponse
    {
      get{return m_response;}
    }
    public string GetId
    {
      get{return m_response_id;}
    }
    public string GetMessage
    {
      get{return m_message;}
    }
  }
}
