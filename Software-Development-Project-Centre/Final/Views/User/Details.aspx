<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.aspnet_User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">ApplicationId</div>
        <div class="display-field"><%: Model.ApplicationId %></div>
        
        <div class="display-label">UserId</div>
        <div class="display-field"><%: Model.UserId %></div>
        
        <div class="display-label">UserName</div>
        <div class="display-field"><%: Model.UserName %></div>
        
        <div class="display-label">LoweredUserName</div>
        <div class="display-field"><%: Model.LoweredUserName %></div>
        
        <div class="display-label">MobileAlias</div>
        <div class="display-field"><%: Model.MobileAlias %></div>
        
        <div class="display-label">IsAnonymous</div>
        <div class="display-field"><%: Model.IsAnonymous %></div>
        
        <div class="display-label">LastActivityDate</div>
        <div class="display-field"><%: String.Format("{0:g}", Model.LastActivityDate) %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.UserId }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

