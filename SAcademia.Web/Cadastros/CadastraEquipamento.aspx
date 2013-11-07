<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastraEquipamento.aspx.cs" Inherits="SAcademia.Web.Cadastros.CadastraEquipamento" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="conteudo">
        <div class="cabecalho">
            <div class="seta-right">
            </div>
            <h2>
                Cadastro/Alteração de Exercícios</h2>
        </div>
        <div class="bg-tabela">
            <h3>
                Dados do Exercício</h3>
            <div class="row-452">
                <label>
                    Nome*:</label>
                <asp:TextBox ID="txtNome" Cssclass="required" runat="server" ToolTip="Nome" />
            </div> 
            <div class="row-452">
                <label>
                    Categoria de Equipamento*:</label>
                <asp:DropDownList ID="dpCategoria" Cssclass="required" runat="server">
                    <asp:ListItem Text="Selecione" Value="" />
                    <asp:ListItem Text="Categoria x" Value="Categoria x" />
                </asp:DropDownList>
            </div>           
            <div class="btnsCadastro">
                <asp:Button ID="btnSalvar" OnClientClick="return valida();" ToolTip="Salvar" 
                    runat="server" Text="Salvar" CssClass="buttons" 
                    onclick="btnSalvar_Click" />
                <asp:Button ID="btnVoltar" ToolTip="Voltar" CssClass="buttons" runat="server" 
                    Text="Voltar" onclick="btnVoltar_Click" />
            </div>
            <span class="campObrigatorio">(*) Campo Obrigatório</span>
        </div>
    </div>   
</asp:Content>
