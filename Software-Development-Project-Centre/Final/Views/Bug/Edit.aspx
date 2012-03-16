<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.BugReport>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            <legend>Fields</legend>
            
     
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BugWorkPacId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.BugWorkPacId, new { rows = "2", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.BugWorkPacId) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BugTitle) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.BugTitle, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.BugTitle) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BugDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.BugDate)%>
                <%: Html.ValidationMessageFor(model => model.BugDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BugIssue) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.BugIssue, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.BugIssue) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.BugResolution) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.BugResolution, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.BugResolution) %>
            </div>
            
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

