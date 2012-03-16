/*
 * MockAuthSercer.cs
 * Mock Auth server method for root server
 * 
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 10/6/2011 - first release.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;


namespace edu.syr.cse784.eskimodb.rootserver
{
  public class MockAuthServer : IAuthValidate
  {
    private Dictionary<string, DateTime> m_tokenDict = new Dictionary<string, DateTime>();

    //Constructor with a fake data of <token , expire time>
    public MockAuthServer()
    {
      m_tokenDict.Add("xxxx", new DateTime(2011,10,20,10,10,10));
                        
    }

    // validate the input token from root and return the bool status and exptime
    public bool Validate(string token, out DateTime exptime)
    {
      if (!m_tokenDict.TryGetValue(token, out exptime))
        return false;
      return true;
    }



#if(TEST_MOCKAUTH)
    static void Main(string[] args)
    {
      //=========== MockAuthServer  test stub============
      /*
      MockAuthServer MAS = new MockAuthServer();
      DateTime exptime= new DateTime();

      string token = "xxxx";

      if (MAS.Validate(token,out exptime))
      {
        Console.WriteLine("success~ save the token and expire time");
        Console.WriteLine("exp time: " + exptime.ToString());
      }
      else
      {
        Console.WriteLine("fail, reject client");      
      }
      */
      //=================================================
    }
#endif
  }
}
