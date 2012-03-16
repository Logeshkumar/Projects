<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.WorkPacRef>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

     <% Html.EnableClientValidation(); %>
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
                <%: Html.TextAreaFor(model => model.WorkPacRefDate, String.Format("{0:g}", Model.WorkPacRefDate))%>
                <%: Html.ValidationMessageFor(model => model.WorkPacRefDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.WorkPacRefDesc) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.WorkPacRefDesc, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.WorkPacRefDesc) %>
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

