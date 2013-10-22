<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Inicio.aspx.cs" Inherits="SAcademia.Web.Inicio.Inicio" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="imgOrgao">
        <h1>Órgão</h1>
        <asp:Image ID="img" runat="server" Height="125px" Width="300px" 
        Visible="False" />
    </div> 
</asp:Content>
