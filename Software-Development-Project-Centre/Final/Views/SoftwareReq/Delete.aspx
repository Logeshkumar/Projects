<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.SoftwareRequirement>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <h3>Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">SoftReqId</div>
        <div class="display-field"><%: Model.SoftReqId %></div>
        
        <div class="display-label">SoftReqTitle</div>
        <div class="display-field"><%: Model.SoftReqTitle %></div>
        
        <div class="display-label">SoftReqDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.SoftReqDate) %></div>
        
        <div class="display-label">SoftReqSt</div>
        <div class="display-field"><%: Model.SoftReqSt %></div>
        
        <div class="display-label">Issue</div>
        <div class="display-field"><%: Model.Issue %></div>
        
    </fieldset>
    <% using (Html.BeginForm()) { %>
        <p>
		    <input type="submit" value="Delete" /> |
		    <%: Html.ActionLink("Back to List", "Index") %>
        </p>
    <% } %>

</asp:Content>

