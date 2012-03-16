<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Final.Models.SoftwareRequirement>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th>CRUD</th>
           
            <th>
                SoftReqTitle
            </th>
            <th>
                SoftReqDate
            </th>
            <th>
                SoftReqSt
            </th>
            <th>
                Issue
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
            
             <form style="float:left" method="get" action="/SoftwareReq/Edit/<% =item.SoftReqId %>">
           <input type="submit" value="Edit" />
                </form>
              <form method="get" action="/SoftwareReq/Details/<% =item.SoftReqId %>">
                    <input type="submit" value="Details" />
                 </form>
              <form  method="get" action="/SoftwareReq/Delete/<% =item.SoftReqId %>">
                    <input type="submit" value="Delete" />
               </form>
            <%--    <%: Html.ActionLink("Edit", "Edit", new { id=item.SoftReqId }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.SoftReqId })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.SoftReqId })%>--%>
            </td>
            <td>
                <%: item.SoftReqTitle %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.SoftReqDate.ToShortDateString()) %>
            </td>
            <td>
                <%: item.SoftReqSt %>
            </td>
            <td>
                <%: item.Issue %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

