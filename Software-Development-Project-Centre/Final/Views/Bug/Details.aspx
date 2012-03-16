<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.BugReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">BugId - <%: Model.BugId %></div>
        
        <div class="display-label">BugWorkPac - <%: Model.BugWorkPacId %></div>
        
        <div class="display-label">BugTitle - <%: Model.BugTitle %></div>
        
        <div class="display-label">BugDate - <%: Model.BugDate %></div>
        
        <div class="display-label">BugIssue - <%: Model.BugIssue %></div>
        
        <div class="display-label">BugResolution - <%: Model.BugResolution %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new {  id=Model.BugId }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

