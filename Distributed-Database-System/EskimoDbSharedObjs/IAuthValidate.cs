//Authentication Server interface for Root Server
using System;
using System.ServiceModel;

namespace edu.syr.cse784.eskimodb.sharedobjs
{
    [ServiceContract]
    public interface IAuthValidate
    {
        [OperationContract]
        bool Validate(string token, out DateTime ExpTime);
    }
}