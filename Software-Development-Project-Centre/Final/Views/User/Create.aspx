<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.aspnet_User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.ApplicationId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.ApplicationId)%>
                <%: Html.ValidationMessageFor(model => model.ApplicationId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.UserId)%>
                <%: Html.ValidationMessageFor(model => model.UserId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.UserName)%>
                <%: Html.ValidationMessageFor(model => model.UserName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LoweredUserName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.LoweredUserName)%>
                <%: Html.ValidationMessageFor(model => model.LoweredUserName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.MobileAlias) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.MobileAlias)%>
                <%: Html.ValidationMessageFor(model => model.MobileAlias) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.IsAnonymous) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.IsAnonymous)%>
                <%: Html.ValidationMessageFor(model => model.IsAnonymous) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LastActivityDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.LastActivityDate)%>
                <%: Html.ValidationMessageFor(model => model.LastActivityDate) %>
            </div>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

