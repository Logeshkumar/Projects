using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.cse784.eskimodb.authserver
{
    class AuthValidate : edu.syr.cse784.eskimodb.sharedobjs.IAuthValidate
    {
        public AuthValidate(AuthManager mgr) 
        {
            m_Mgr = mgr;     
        }

        public bool Validate(string token, out DateTime ExpTime) 
        {
            return m_Mgr.TokenVerifier(token, out ExpTime);
        }

        private AuthManager m_Mgr;
    }
}
