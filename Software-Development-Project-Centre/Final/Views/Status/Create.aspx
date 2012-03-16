<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.StatusReport>" %>

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
                <%: Html.LabelFor(model => model.StatusTitle) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.StatusTitle, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.StatusTitle) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StatusDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StatusDate)%>
                <%: Html.ValidationMessageFor(model => model.StatusDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.StatusText) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.StatusText, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.StatusText) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.WorkPacRefId) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.WorkPacRefId)%>
                <%: Html.ValidationMessageFor(model => model.WorkPacRefId) %>
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

