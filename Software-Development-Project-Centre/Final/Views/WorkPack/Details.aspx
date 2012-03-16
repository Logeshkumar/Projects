<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.WorkPacRef>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">WorkPacRefId - <%: Model.WorkPacRefId %></div>
        
        <div class="display-label">WorkPacRefTitle - <%: Model.WorkPacRefTitle %></div>
        
        <div class="display-label">WorkPacRefDate - <%: String.Format("{0:g}", Model.WorkPacRefDate) %></div>
        
        <div class="display-label">WorkPacRefDesc - <%: Model.WorkPacRefDesc %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.WorkPacRefId }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

