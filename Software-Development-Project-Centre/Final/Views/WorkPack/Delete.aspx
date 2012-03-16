<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.WorkPacRef>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">WorkPacRefId</div>
        <div class="display-field"><%: Model.WorkPacRefId %></div>
        
        <div class="display-label">WorkPacRefTitle</div>
        <div class="display-field"><%: Model.WorkPacRefTitle %></div>
        
        <div class="display-label">WorkPacRefDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.WorkPacRefDate) %></div>
        
        <div class="display-label">WorkPacRefDesc</div>
        <div class="display-field"><%: Model.WorkPacRefDesc %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

