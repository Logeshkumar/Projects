using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.authserver
{
    public enum RequestType { Validate, CreateUser, Authenticate, IsAdmin };
    public class Request
    {
        public Request(string user, string password, string token, RequestType req, string Signature)
        {
            m_Username = user;
            m_Password = password;
            m_Token = token;
            m_RequestType = req;
            m_Signature = Signature;
        }
        public string m_Username;
        public string m_Password;
        public string m_Token;
        public RequestType m_RequestType;
        public string m_Signature;
    }
    public class ReturnRequest
    {
        AuthResult m_AuthResult;
        string m_Token;
        DateTime m_ExpTime;
        bool m_RequestResult;
        string m_Signature;

        public ReturnRequest(AuthResult m_RetAuthResult, string m_RetToken, DateTime m_RetExpTime, bool m_RetRequestResult, string m_RetSignature)
        {
            m_AuthResult = m_RetAuthResult;
            m_Token = m_RetToken;
            m_ExpTime = m_RetExpTime;
            m_RequestResult = m_RetRequestResult;
            m_Signature = m_RetSignature;
        }
    }

    public class SynchronizeRequest
    {
        public Request m_Request;
        public int m_SenderID;
        public DateTime m_ExpTime;

        public SynchronizeRequest(Request m_SynRequest, int m_SynSendID, DateTime m_SynExpTime)
        {
            m_Request = m_SynRequest;
            m_SenderID = m_SynSendID;
            m_ExpTime = m_SynExpTime;
        }
    }
}
