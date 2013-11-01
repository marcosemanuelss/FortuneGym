﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaCategoria.aspx.cs" Inherits="SAcademia.Web.Cadastros.ConsultaCategoria" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Categoria de Equipamentos</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite uma categoria para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" Text="Pesquisar" Cssclass="buttons"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" Text="Limpar"/>
                </div>
                <asp:GridView ID="gvConsulta" CssClass="tabela" runat="server">
                
                </asp:GridView>
                <div class="btnsConsulta">
                    <asp:Button ID="btnNovo" ToolTip="Novo" runat="server" Text="Novo" 
                        Cssclass="buttons" onclick="btnNovo_Click"/>
                    <asp:Button ID="btnVoltar" ToolTip="Voltar" Cssclass="buttons" runat="server" 
                        Text="Voltar" onclick="btnVoltar_Click"/>
                </div>
            </div>
        </div>
</asp:Content>