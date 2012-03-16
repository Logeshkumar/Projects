/*
 * IRootServerCallback.cs
 * callback inteface for root server to push data back to client API
 * 
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 10/13/2011 - v1.1
 *   - Change PutDatasetInfo() name to PutQueryInfo().
 *   - add parameter id to PutDataset().
 *   
 * 10/13/2011 - first release.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  public interface IRootServerCallback
  {
    /*
     * PutDataset() receives the result of a previous GetResult() request,
     * and if the request is accepted by the root server, the function will
     * also receive the requested dataset along with the id of the table
     * requested from root server.if previous request failed, the id will be 
     * empty string "", and data will be null.
     * @param result is the result of the previous request and related info.
     * @param id is the identifier of previously requested table.
     * @param data is the requested dataset.
     */
    [OperationContract]
    void PutDataset(QueryResult result, string id, QueryDataset data);
    /*
     * PutQueryInfo() receives the returning infomation of a previous ExecQuery()
     * request. It receives the execution result of the request, if the request 
     * is successful,and there's a dataset as the return of the request, then
     * the function will also receive a identifier of the result data table, and 
     * the total number of data entries in that table. If the request fails, or the
     * previous query don't have dataset as return, then the id will be empty 
     * string "", and lines will be 0.
     * @param result is the result of the previous request and related info.
     * @param is the identifier of the related data table for previous request.
     * @param is the total number of data entries in data table.
     */
    [OperationContract]
    void PutQueryInfo(QueryResult result, string id, long lines);
  }
}