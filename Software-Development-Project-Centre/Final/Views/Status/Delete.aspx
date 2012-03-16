<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.StatusReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">StatusId</div>
        <div class="display-field"><%: Model.StatusId %></div>
        
        <div class="display-label">StatusTitle</div>
        <div class="display-field"><%: Model.StatusTitle %></div>
        
        <div class="display-label">StatusDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.StatusDate) %></div>
        
        <div class="display-label">StatusText</div>
        <div class="display-field"><%: Model.StatusText %></div>
        
        <div class="display-label">WorkPacRefId</div>
        <div class="display-field"><%: Model.WorkPacRefId %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

