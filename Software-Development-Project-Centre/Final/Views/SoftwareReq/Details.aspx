<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.SoftwareRequirement>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">SoftReqId - <%: Model.SoftReqId %></div>
        
        <div class="display-label">SoftReqTitle - <%: Model.SoftReqTitle %></div>
        
        <div class="display-label">SoftReqDate - <%: String.Format("{0:g}", Model.SoftReqDate) %></div>
        
        <div class="display-label">SoftReqSt - <%: Model.SoftReqSt %></div>
        
        <div class="display-label">Issue - <%: Model.Issue %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.SoftReqId }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

