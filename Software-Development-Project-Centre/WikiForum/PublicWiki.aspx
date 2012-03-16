<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PublicWiki.aspx.cs" Inherits="WikiForum.PublicWiki" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" 
        style="margin-bottom: 0px" Width="282px">
    </asp:DropDownList>
</p>
<p>
    <asp:TextBox ID="TextBox1" runat="server" Height="233px" TextMode="MultiLine" 
        Width="703px"></asp:TextBox>
</p>
    <p>
        &nbsp;</p>
<p>
    <asp:TextBox ID="TextBox2" runat="server" Height="130px" Width="705px"></asp:TextBox>
    &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
<p>
    <asp:Button ID="Button1" runat="server" Text="View Discussion" Width="164px" 
        onclick="Button1_Click1" />
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Save" 
            Width="163px" />
</p>
<p>
</p>
</asp:Content>
