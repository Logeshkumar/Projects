using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
    [DataContract]
    public class AuthResult
    {
        [DataMember]
        public bool valid;
        [DataMember]
        public string msg;
    }
}