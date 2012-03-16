////////////////////////////////////////////////////////////////////////////////
// AuthRequestManager.cs - Manager and control the whole Auth Server System   //
//                                                                            //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 Final Project EskimoDb                                //
// Author:       Yang Ge,   Syracuse University                               //
//               yage@syr.edu                                                 //
////////////////////////////////////////////////////////////////////////////////

#define DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using edu.syr.cse784.eskimodb.sharedobjs;

namespace edu.syr.cse784.eskimodb.authserver
{
    public class AuthRequestManager
    {
#if DEBUG
        // This function is for testing only, will be removed future
        public void EnqueueRequest(Request req1)
        {
            m_RequestQueue.enQ(req1);
        }
#endif
        public void CreateAuthManager()
        {
            // Very Important: Before we start the monitoring thread
            // We need to keep the data in the new authserver up to date
            // We need to lock the m_SyncRequestQueue so that no synchronization request will be served in the mean time
            // Then we copy the data in an arbitrary existing AuthManager instance, 
            // This depends on the correct implementation of copy constructor of AuthManager and its data member
            // note that we do not lock the AuthManager instance we are going to copy
            // So that we are not going to exprience the deadlock
            // If the AuthManager is being modified by serving some requests, the new instance will be updated later
            
            // Sleep a little bit first before we start: for random number generator
            Thread.Sleep(5);

            lock (m_SyncRequestQueue)
            {
                int ID = m_AuthManagerList.Count;
                AuthManager am;
                if (ID == 0)
                {
                    am = new AuthManager();
                }
                else
                {
                    am = new AuthManager(m_AuthManagerList[0]);
                }
                AuthManagerMoniterThread ammt = new AuthManagerMoniterThread(ID, m_RequestQueue, am, m_ReturnRequestQueue, m_SyncRequestQueue);
                m_AuthManagerList.Add(am);
                m_AuthManagerMoniterThreadList.Add(ammt);

#if DEBUG
                Console.WriteLine("Create a AuthManager, ID: " + ID + " , Good Luck!");
#endif
                Thread td = new Thread(new ThreadStart(ammt.proc));
                m_MoniterThreadList.Add(td);
                td.Start();
            }
        }

        public void DistributeRequest()
        {
        }
        public void DestroyAuthManager()
        {
        }

        private BlockingQueue<Request> m_RequestQueue;
        private List<AuthManager> m_AuthManagerList;
        private List<AuthManagerMoniterThread> m_AuthManagerMoniterThreadList;
        private List<Thread> m_MoniterThreadList;
        // A blocking Queue to hold requests that have been processed
        // The request sender (comming from root server) will sample the queue to see if the queue head
        // is the request it send before, if it is, it will deque the request
        private BlockingQueue<ReturnRequest> m_ReturnRequestQueue;
        // A blocking Queue to hold requests that have been processed 
        // and need to synchronize with other AuthServer instance
        private BlockingQueue<SynchronizeRequest> m_SyncRequestQueue;
        // A thread to check the m_SyncRequestQueue queue
        Thread m_AuthManagerSynchronizationThread;

        public AuthRequestManager()
        {
            m_RequestQueue = new BlockingQueue<Request>();
            m_AuthManagerList = new List<AuthManager>();
            m_AuthManagerMoniterThreadList = new List<AuthManagerMoniterThread>();
            m_MoniterThreadList = new List<Thread>();
            m_ReturnRequestQueue = new BlockingQueue<ReturnRequest>();
            m_SyncRequestQueue = new BlockingQueue<SynchronizeRequest>();

            // Create a thread, its function is to synchronize the data 
            // between different instances of AuthServer
            m_AuthManagerSynchronizationThread = new Thread(new ThreadStart(AuthManagerSynchronizationThread));
            m_AuthManagerSynchronizationThread.Start();
        }
        private void AuthManagerSynchronizationThread()
        {
            SynchronizeRequest syncreq;
            while (true)
            {
                syncreq = null;
                // Lock and deque the SyncRequestQueue
                lock (m_SyncRequestQueue)
                {
                    if (m_SyncRequestQueue.size() != 0)
                    {
                        syncreq = m_SyncRequestQueue.deQ();
                    }
                }
                // Serve the synchronization request from the queue
                if (syncreq != null)
                {
#if DEBUG
                    Console.WriteLine("Get syncreq: " + syncreq.m_Request.m_Username + " "
                                        + syncreq.m_Request.m_Password + " "
                                        + syncreq.m_Request.m_Signature + " "
                                        + syncreq.m_Request.m_RequestType + " "
                                        + syncreq.m_SenderID);
#endif
                    for (int i = 0; i < m_AuthManagerList.Count; ++i)
                    {
                        if (i != syncreq.m_SenderID)
                        {
#if DEBUG
                            Console.WriteLine("Update syncreq for Authserver ID: " + i);
#endif
                            lock (m_AuthManagerList[i])
                            {
                                ProcessSynchronizeRequest(m_AuthManagerList[i], syncreq);
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        // Call this function only with am locked
        private void ProcessSynchronizeRequest(AuthManager am, SynchronizeRequest syncreq)
        {
            Request req = syncreq.m_Request;
            string msg = "";
            switch (req.m_RequestType)
            {
                // If we created a new user, just call the Register function
                case RequestType.CreateUser:
                    am.Register(req.m_Username, req.m_Password, out msg);
                    break;
                // If we generate a token for a user, we need to create this token for other co-existing authservers
                case RequestType.Authenticate:
                    am.AddSynchronizedToken(req.m_Token, req.m_Username, syncreq.m_ExpTime);
                    break;
                default:
                    break;
            }
        }
        private class AuthManagerMoniterThread
        {
            private BlockingQueue<Request> m_RequestQueue;
            private AuthManager m_AuthManager;
            private int m_ID;
            private BlockingQueue<ReturnRequest> m_ReturnRequestQueue;
            private BlockingQueue<SynchronizeRequest> m_SyncRequestQueue;

            public AuthManagerMoniterThread(int ID, BlockingQueue<Request> bQ, AuthManager authManager, BlockingQueue<ReturnRequest> bQReturn, BlockingQueue<SynchronizeRequest> bQSync)
            {
                m_RequestQueue = bQ;
                m_AuthManager = authManager;
                m_ID = ID;
                m_ReturnRequestQueue = bQReturn;
                m_SyncRequestQueue = bQSync;
            }
            public void proc()
            {
                Request req;
                ReturnRequest retreq;
                SynchronizeRequest syncreq;
#if DEBUG
                Console.WriteLine("Thread " + m_ID + " Started!");
#endif
                while (true)
                {
                    if (m_RequestQueue.size() > 0)
                    {
                        req = m_RequestQueue.deQ();
#if DEBUG
                        Console.WriteLine("Thread " + m_ID + " get request: "
                            + req.m_Username + " "
                            + req.m_Password + " "
                            + req.m_Token + " "
                            + req.m_RequestType);
#endif
                        // Process the requests here
                        // Lock the AuthManager here and process the request
                        lock (m_AuthManager)
                        {
                            
                            ProcessRequest(req, out retreq, out syncreq);
                        }
                        // Lock the 2 queues which need to send out results, and insert them
                        lock (m_ReturnRequestQueue)
                        {
                            m_ReturnRequestQueue.enQ(retreq);
                        }
                        // Only synchronize Authenticate and CreateUser, because they will modify AuthManager's data
                        if (req.m_RequestType == RequestType.Authenticate || req.m_RequestType == RequestType.CreateUser)
                        {
                            lock (m_SyncRequestQueue)
                            {
                                m_SyncRequestQueue.enQ(syncreq);
                            }
                        }
                    }
                    Thread.Sleep(10);
                }
            }
            private void ProcessRequest(Request req, out ReturnRequest retreq, out SynchronizeRequest syncreq)
            {
                AuthImplement authimplement = new AuthImplement(m_AuthManager);
                string token = "";
                DateTime exptime = DateTime.Now;
                bool result = false;
                AuthResult authret = new AuthResult();

                switch (req.m_RequestType) {
                    case RequestType.Authenticate:
                        authret = authimplement.Authenticate(req.m_Username, req.m_Password, out token);
                        authimplement.Validate(token, out exptime);
                        req.m_Token = token;
                        break;
                    case RequestType.CreateUser:
                        authret = authimplement.CreateUser(req.m_Username, req.m_Password, token);
                        break;
                    case RequestType.IsAdmin:
                        break;
                    case RequestType.Validate:
                        result = authimplement.Validate(req.m_Token, out exptime);
                        break;
                }
                
                // Make the ReturnRequest and SynchronizeRequest object
                retreq = new ReturnRequest(authret, token, exptime, result, req.m_Signature);
                syncreq = new SynchronizeRequest(req, m_ID, exptime);
            }
        }
    }
}
