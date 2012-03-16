<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.WorkPacRef>" %>

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
                <%: Html.LabelFor(model => model.WorkPacRefTitle) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.WorkPacRefTitle, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.WorkPacRefTitle) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.WorkPacRefDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.WorkPacRefDate) %>
                <%: Html.ValidationMessageFor(model => model.WorkPacRefDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.WorkPacRefDesc) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.WorkPacRefDesc, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.WorkPacRefDesc) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.UserId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.UserId, new { rows = "1", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.UserId) %>
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

