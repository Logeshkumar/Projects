<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Final.Models.WorkPacRef>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th>CRUD</th>
           
            <th>
                WorkPacRefTitle
            </th>
            <th>
                WorkPacRefDate
            </th>
            <th>
                WorkPacRefDesc
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td><form style="float:left" method="get" action="/WorkPack/Edit/<% =item.WorkPacRefId %>">
           <input type="submit" value="Edit" />
                </form>
              <form method="get" action="/WorkPack/Details/<% =item.WorkPacRefId %>">
                    <input type="submit" value="Details" />
                 </form>
              <form  method="get" action="/WorkPack/Delete/<% =item.WorkPacRefId %>">
                    <input type="submit" value="Delete" />
               </form>

             <%--   <%: Html.ActionLink("Edit", "Edit", new { id=item.WorkPacRefId }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.WorkPacRefId })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.WorkPacRefId })%>--%>
            </td>
            
            <td>
                <%: item.WorkPacRefTitle %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.WorkPacRefDate.ToShortDateString()) %>
            </td>
            <td>
                <%: item.WorkPacRefDesc %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

