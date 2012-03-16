<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Final.Models.SoftwareRequirement>" %>

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
                <%: Html.LabelFor(model => model.SoftReqTitle) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.SoftReqTitle, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.SoftReqTitle) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SoftReqDate) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.SoftReqDate, String.Format("{0:d}", Model.SoftReqDate))%>
                <%: Html.ValidationMessageFor(model => model.SoftReqDate) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.SoftReqSt) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.SoftReqSt, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.SoftReqSt) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Issue) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Issue, new { rows = "5", cols = "100" })%>
                <%: Html.ValidationMessageFor(model => model.Issue) %>
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

