using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
    [DataContract]
    public class QueryResult
    {
        [DataMember]
        private int m_Id;

        [DataMember]
        private string m_Content;

        [DataMember]
        private object m_Data;

        public QueryResult(int id, string content, object data = null)
        {
            m_Id = id;
            m_Content = content;
            m_Data = data;
        }

        public int GetId()
        {
            return m_Id;
        }

        public string GetMessage()
        {
            return m_Content;
        }

        public object GetData()
        {
            return m_Data;
        }
    }
}