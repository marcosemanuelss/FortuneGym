<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaCliente.aspx.cs" Inherits="SAcademia.Web.Administrativo.ConsultaCliente" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Clientes do Sistema</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite um nome ou cpf ou matrícula para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" Text="Pesquisar" Cssclass="buttons"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" Text="Limpar"/>
                </div>
                <asp:GridView ID="gvConsulta" CssClass="tabela" runat="server">
                
                </asp:GridView>
                <div class="btnsConsulta">
                    <asp:Button ID="btnNovo" onclick="btnNovo_Click" ToolTip="Novo" runat="server" Text="Novo" Cssclass="buttons"/>
                    <asp:Button ID="btnVoltar" onclick="btnVoltar_Click" ToolTip="Voltar" Cssclass="buttons" runat="server" Text="Voltar"/>
                </div>
            </div>
        </div>
</asp:Content>
