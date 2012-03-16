<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.BugReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">BugId</div>
        <div class="display-field"><%: Model.BugId %></div>
        
        <div class="display-label">BugWorkPacId</div>
        <div class="display-field"><%: Model.BugWorkPacId %></div>
        
        <div class="display-label">BugTitle</div>
        <div class="display-field"><%: Model.BugTitle %></div>
        
        <div class="display-label">BugDate</div>
        <div class="display-field"><%: Model.BugDate %></div>
        
        <div class="display-label">BugIssue</div>
        <div class="display-field"><%: Model.BugIssue %></div>
        
        <div class="display-label">BugResolution</div>
        <div class="display-field"><%: Model.BugResolution %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

