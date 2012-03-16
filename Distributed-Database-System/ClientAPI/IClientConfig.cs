////////////////////////////////////////////////////////////////////////////////
// IClientConfig.cs - Interface for configuring the client apim               //
// version 1.0                                                                //
// Language:     C# 4.0                                                       //
// Platform:     Windows 7                                                    //
// Application:  CSE784 EskimoDB                                              //
// Author:       Anjali Banka, Fall 2011, Syracuse University                 //
//               abanka@syr.edu                                               //
////////////////////////////////////////////////////////////////////////////////

/*
 * Depend files
 * ======================
 * None.
 * 
 * Maintanence
 * ======================
 * 12/08/2011 - first
 * /
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace edu.syr.eskimodb.clientapi
{
  /// <summary>
  /// Interface for configuring the client api 
  /// </summary>
  interface IClientConfig
  {
    /// <summary>
    /// Used the set the url of the authentication server
    /// </summary>
    /// <param name="authServerHostUrl">
    /// Url of the authentication server
    /// </param>
    void SetAuthHostAddress(string authServerHostUrl);

    /// <summary>
    /// Used to set the url of the root server 
    /// </summary>
    /// <param name="rootServerUrl">
    /// The url of the root server
    /// </param>
    void SetRootServer(string rootServerUrl);

    /// <summary>
    /// Call this function to initiate the di framework, and configure the client api 
    /// </summary>
    void ConfigClient();

  }
}
