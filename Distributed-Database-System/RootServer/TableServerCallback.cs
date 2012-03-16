/*
 * TableServerCallback.cs
 * TableServerCallback implementation.
 * 
 * @Author: Satyajeet N. Desale
 * @Date: 12/01/2011
 */
/*
 * Dependent files
 * ======================
 * TableSererCallback.cs
 * 
 * 
 * Maintanence
 * ======================
 * 12/01/2011 - first release.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.rootserver
{
  class TableServerCallback : ITableServerCallback
  {
    /*
     * PutDataset implements the contract ITableServerCallback. 
     * It is responsible for getting the QueryDataSet from the tableserver
     * and storing on the rootserver.
     * @param QueryData is the dataset received from the tableserver
     * @param DataId is a unique id received from the tableserver for the specific request
     * @returns none
     */
    public void PutDataset(QueryDataset QueryData, string DataId)
    {
      try
      {
        ResultStorage resultStorage = ResultStorage.Instance;
        if (!resultStorage.AddResultEntry(DataId, QueryData))
        {
          throw new Exception("Result not added in storage.");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
