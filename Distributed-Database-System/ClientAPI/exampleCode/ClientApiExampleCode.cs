using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApiExample
{
  class Program
  {
    static void Main(string[] args)
    {
      ClientApi api = new ClientApi("128.230.199.93", "username", "password");
      ResultSet set = api.DoSQL("SELECT * FROM table0");
      foreach(var row in set){        
        int row_index = set.GetInt("row_index");
        String address = set.GetString("postal_address");
      }
    }


    class ResultSet
    {
      private int result_id;
      private ClientApi m_ApiRef;
      private int num_rows;
      private List<Row> curr_rows;
      private int curr_index;

      public ResultSet(int result_id, ClientApi api_ref)
      {
        api_ref.registerCallback(new PutDatasetDelegate(putDataSetCallback));
      }

      public bool hasNext()
      {
        //look at current ten.
        //if past end of current ten, 
          //get next ten (call the method that will trigger the callback) (block here waiting for callback to be called)
          
      }

      public void putDataSetCallback(QueryResult result, QueryDataSet set)
      {
        //capture the dataset
      }
    }
  }
}
