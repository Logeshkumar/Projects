using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RESTServiceDemo
{
  [DataContract]
  public class MatchData
  {
    [DataMember]
    public string Home { get; set; }
    [DataMember]
    public string Score { get; set; }
    [DataMember]
    public string Away { get; set; }
  }

  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRESTServiceImpl" in both code and config file together.
  [ServiceContract]
  public interface IRESTMatchService
  {
    [OperationContract]
    [WebInvoke(Method="POST",
               RequestFormat=WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Bare,
               UriTemplate="Match")]
    string CreateMatch(MatchData data);

    [OperationContract]
    [WebInvoke(Method = "GET",
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle=WebMessageBodyStyle.Bare,
               UriTemplate = "Match/{id}")]
    string GetMatchDetail(string id);

    [OperationContract]
    [WebInvoke(Method = "GET",
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Bare,
               UriTemplate = "Match/IsAdmin/{token}")]
    string IsAdmin(string token);

    [OperationContract]
    [WebInvoke(Method = "PUT",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Bare,
               UriTemplate = "Match/{id}")]
    string UpdateMatch(string id, MatchData data);

    [OperationContract]
    [WebInvoke(Method = "DELETE",
               ResponseFormat = WebMessageFormat.Json,
               BodyStyle = WebMessageBodyStyle.Bare,
               UriTemplate = "Match/{id}")]
    string DeleteMatch(string id);
  }
}
