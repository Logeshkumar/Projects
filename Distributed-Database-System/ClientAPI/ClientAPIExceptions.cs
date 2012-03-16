////////////////////////////////////////////////////////////////////////////////
// ClientAPIExceptions.cs - Handles clientAPI exceptions                      //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Anjali Banka, Fall 2011, Syracuse University                 //
//               abanka@syr.edu                                               //
////////////////////////////////////////////////////////////////////////////////

/*
Module Operations: 
==================
The module is responsible to handle the exceptions raised by the ClientAPI class.
 
Public Interface
=================

 
Build Process
================
 * 
 * 
 Required Files:
===================
 * ClientAPI.cs



Maintenance History:
====================
ver 1.0 : 18 October 2011

*/

using System;

namespace edu.syr.eskimodb.clientapi
{
  [Serializable()]
  public class ClientAPIExceptions : System.Exception
  {
    public ClientAPIExceptions() : base() { }
    public ClientAPIExceptions(string message) : base(message) { }
    public ClientAPIExceptions(string message, System.Exception inner) : base(message, inner) { }
    protected ClientAPIExceptions(System.Runtime.Serialization.SerializationInfo info,
    System.Runtime.Serialization.StreamingContext context) { }

  }
}


