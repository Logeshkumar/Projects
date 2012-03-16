/*
 * ITableServerCallback.cs
 * callback inteface for root server to push data back to client API
 * 
 */
/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintain
 * ======================
 * 11/30/2011 - v1.1
 *   - Change PutDatasetInfo() name to PutQueryInfo().
 *   - add parameter id to PutDataset().
 *   
 * 11/30/2011 - first release.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
  public interface ITableServerCallback
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
    void PutDataset(QueryDataset QueryData, string DataId);


  }
}