<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Final.Models.BugReport>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
          
            <th>
                BugWorkPac
            </th>
            <th>
                BugTitle
            </th>
            <th>
                BugDate
            </th>
            <th>
                BugIssue
            </th>
            <th>
                BugResolution
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
               <%-- <%: Html.ActionLink("Edit", "Edit", new {  id=item.BugId }) %> |--%>
                <%: Html.ActionLink("Details", "Details", new {  id=item.BugId })%> <%--|--%>
              <%--  <%: Html.ActionLink("Delete", "Delete", new {  id=item.BugId })%>--%>
            </td>
            <td>
                <%: item.BugWorkPacId %>
            </td>
            <td>
                <%: item.BugTitle %>
            </td>
            <td>
                <%: item.BugDate %>
            </td>
            <td>
                <%: item.BugIssue %>
            </td>
            <td>
                <%: item.BugResolution %>
            </td>
        </tr>
    
    <% } %>

    </table>
<%--
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>--%>

</asp:Content>

