<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Final.Models.StatusReport>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th>CRUD</th>
            <th>
                StatusId
            </th>
            <th>
                StatusTitle
            </th>
            <th>
                StatusDate
            </th>
            <th>
                StatusText
            </th>
            <th>
                WorkPacRefId
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <form style="float:left" method="get" action="/Status/Edit/<% =item.StatusId %>">
           <input type="submit" value="Edit" />
                </form>
              <form method="get" action="/Status/Details/<% =item.StatusId %>">
                    <input type="submit" value="Details" />
                 </form>
              <form  method="get" action="/Status/Delete/<% =item.StatusId %>">
                    <input type="submit" value="Delete" />
               </form>
<%--                <%: Html.ActionLink("Edit", "Edit", new { id=item.StatusId }) %> |
                <%: Html.ActionLink("Details", "Details", new { id=item.StatusId })%> |
                <%: Html.ActionLink("Delete", "Delete", new { id=item.StatusId })%>--%>
            </td>
            <td>
                <%: item.StatusId %>
            </td>
            <td>
                <%: item.StatusTitle %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.StatusDate.ToShortDateString()) %>
            </td>
            <td>
                <%: item.StatusText %>
            </td>
            <td>
                <%: item.WorkPacRefId %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

