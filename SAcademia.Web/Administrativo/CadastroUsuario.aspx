<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CadastroUsuario.aspx.cs" Inherits="SFF.Web.Administrativo.CadastroUsuario" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript">
        $(function () {
            //MÁSCARAS
            $('#MainContent_txtCpf').mask('999.999.999-99');
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <div class="conteudo">
            <div class="cabecalho">
                <div class="seta-right"></div>
                <h2>Cadastro/Alteração do Usuário</h2>
            </div>
            <div class="bg-tabela">
                <h3>Dados do Usuário</h3>
                <div class="row-290">
                    <label>Login*:</label>
                    <asp:TextBox ID="txtLogin" Cssclass="required" runat="server" ToolTip="login"/>
                </div>
                <div class="row-290">
                    <label>CPF*:</label>
                    <asp:TextBox ID="txtCpf" Cssclass="required" runat="server" ToolTip="CPF" onBlur="if(!validarCPF(this.value)){limpaCampo(this.id); mostraPopUpAlert('CPF inválido! Digite novamente.','../img/icon-erro.png',false,this.id);}"/>
                </div>
                <div class="row-290">
                    <label>Nome*:</label>
                    <asp:TextBox ID="txtNome" Cssclass="required" runat="server" ToolTip="Nome"/>
                </div>
                <div class="row-452">
                    <label>Tipo de Usuário*:</label>
                    <asp:DropDownList ID="dpTipoUsuario" Cssclass="required" runat="server">
                        <asp:ListItem Text="Selecione" Value=""/>
                        <asp:ListItem Text="Administrador" Value="Administrador"/>
                        <asp:ListItem Text="Instrutor" Value="Instrutor"/>
                    </asp:DropDownList>
                </div>
                <div class="row-452">
                    <label>Situação*:</label>
                    <asp:DropDownList ID="dpSituacao" Cssclass="required" runat="server">
                        <asp:ListItem Text="Selecione" Value=""/>
                        <asp:ListItem Text="Ativo" Value="Ativo"/>
                        <asp:ListItem Text="Inativo" Value="Inativo"/>
                    </asp:DropDownList>
                </div>
                <div class="btnsCadastro">
                    <asp:Button ID="btnSalvar" OnClientClick="validaCampos();" ToolTip="Salvar" runat="server" Text="Salvar" Cssclass="buttons"/>
                    <asp:Button ID="btnVoltar" ToolTip="Voltar" Cssclass="buttons" runat="server" 
                        Text="Voltar" onclick="btnVoltar_Click"/>
                </div>
                <span class="campObrigatorio">(*) Campo Obrigatório</span>
            </div>
        </div>
</asp:Content>
