/*
 * IRootServer.cs
 * Root Server interface (service contract) for client API
 * 
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 10/13/2011 - first release.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  [ServiceContract(Namespace = "edu.syr.cse784.eskimodb.sharedobjs", CallbackContract = typeof(IRootServerCallback))]
  public interface IRootServer
  {
    /*
     * ExecQuery(query,token) receives a request with a authentication token.
     * It does a quick check on the validity of thetoken, and the query grammar, 
     * if the check doesn't pass it will return a result telling client the 
     * failure and info associated with the failure. If check passes, it adds 
     * the request to a queue, and notify client that the request is accepted.
     * @param query is the query string.
     * @param token is the authentication token
     * @returns whether the operation is successful and info related to the result.
     */
    [OperationContract]
    QueryResult ExecQuery(string query, string token);
    /*
     * GetResult(id,startline,numberOfLines) receives a request asking for data
     * in a table stored on the root server. 
     * @param id is the identifier for the table on root server.
     * @param startLine is the first data entry that the client wants.
     * @param numberOfLines is the total number of data entries the client wants.
     * @param token is the authentication token.
     * @returns the result of operation and info related to the result.
     */
    [OperationContract]
    QueryResult GetResult(string id, int startLine, int numberOfLines, string token);
    /*
     * Release(id,token) will release the reference to a table object on root server
     * and let the table object be garbage collected.
     * @param id is the identifier for the table on root server.
     * @param token is the authentication token
     * @returns the result of operation and info related to the result.
     */
    [OperationContract]
    QueryResult Release(string id, string token);
    /*
     * @param token is the authentication token
     * @returns the DB structure.
     */
    [OperationContract]
    Dictionary<string,List<string>> GetDBInfo(string token);

    [OperationContract]
    void configureRootServer(string authServerUrl, string tableServerUrl);
  }
}