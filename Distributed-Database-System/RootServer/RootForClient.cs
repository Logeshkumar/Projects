using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;


namespace edu.syr.cse784.eskimodb.rootserver
{
  public class RootForClient : IRootServer
  {

    private bool CheckToken(string token)
    {
      DateTime exptime = new DateTime();
      MockAuthServer MAS = new MockAuthServer();
      return MAS.Validate(token, out exptime);      
    }

    public QueryResult ExecQuery(string query, string token)
    {
      throw new NotImplementedException();
    }

    public QueryResult GetResult(string id, int startLine, int numberOfLines, string token)
    {
      throw new NotImplementedException();
    }

    public QueryResult Release(string id, string token)
    {
      throw new NotImplementedException();
    }

    /*
     * @returns the DB structure.
     */
    public Dictionary<string, List<string>> GetDBInfo(string str)
    {
      return new Dictionary<string, List<string>>();
    }

    public void configureRootServer(string authServerUrl, string tableServerUrl)
    { }
  }
}
