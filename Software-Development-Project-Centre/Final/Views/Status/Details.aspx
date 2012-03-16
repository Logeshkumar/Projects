<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.StatusReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">StatusId - <%: Model.StatusId %></div>
        
        <div class="display-label">StatusTitle - <%: Model.StatusTitle %></div>
        
        <div class="display-label">StatusDate - <%: String.Format("{0:g}", Model.StatusDate) %></div>
        
        <div class="display-label">StatusText - <%: Model.StatusText %></div>
        
        <div class="display-label">WorkPacRefId - <%: Model.WorkPacRefId %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.StatusId }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

