﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConsultaRepeticoes.aspx.cs" Inherits="SAcademia.Web.Cadastros.ConsultaRepeticoes" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            window.onload = function () {
                document.getElementById('MainContent_txtPesquisa').onkeypress = function (e) {
                    doClick('MainContent_btnPesquisar', e);
                };
            };
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Consulta de Repetições</h2>
            </div>
            <div class="bg-tabela">
                <div class="filtrar">
                    <label>Digite o nome da repetição para pesquisa:</label>
                    <asp:TextBox ID="txtPesquisa" runat="server"/>
                    <asp:Button ID="btnPesquisar" ToolTip="Pesquisar" runat="server" 
                        Text="Pesquisar" Cssclass="buttons" onclick="btnPesquisar_Click"/>
                    <asp:Button ID="btnLimpar" ToolTip="Limpar" Cssclass="buttons" runat="server" 
                        Text="Limpar" onclick="btnLimpar_Click"/>
                </div>
                <asp:GridView ID="gvConsulta" AutoGenerateColumns="False" CssClass="tabela" 
                    runat="server" DataKeyNames="Codigo" onrowcommand="gvConsulta_RowCommand">
                    <FooterStyle Wrap="False" />
                    <HeaderStyle Wrap="False" />
                    <RowStyle Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField HeaderText="Nome" DataField="Nome"/>
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageEditar" runat="server" ImageUrl="~\img\icon-editar.png"
                                    ToolTip="Editar Ficha" CommandName="Editar" CommandArgument='<%# Eval("Codigo") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
