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
                <div class="row-443">
                    <label>Login:</label>
                    <asp:TextBox ID="txtLogin" runat="server" ToolTip="login"/>
                </div>
                <div class="row-443">
                    <label>CPF:</label>
                    <asp:TextBox ID="txtCpf" runat="server" ToolTip="CPF"/>
                </div>
                <div class="row-443">
                    <label>Nome:</label>
                    <asp:TextBox ID="txtNome" runat="server" ToolTip="Nome"/>
                </div>
                <div class="row-443">
                    <label>E-mail:</label>
                    <asp:TextBox ID="txtEmail" runat="server" ToolTip="E-mail"/>
                </div>
                <div class="row-443">
                    <label>Tipo de Usuário:</label>
                    <asp:DropDownList ID="dpTipoUsuario" runat="server">
                        <asp:ListItem Text="Selecione" Value="0"/>
                        <asp:ListItem Text="Administrador" Value="1"/>
                        <asp:ListItem Text="Instrutor" Value="2"/>
                    </asp:DropDownList>
                </div>
                <div class="row-443">
                    <label>Situação:</label>
                    <asp:DropDownList ID="dpSituacao" runat="server">
                        <asp:ListItem Text="Selecione" Value="0"/>
                        <asp:ListItem Text="Ativo" Value="1"/>
                        <asp:ListItem Text="Inativo" Value="2"/>
                    </asp:DropDownList>
                </div>
                <div class="btnsCadastro">
                    <asp:Button ID="btnSalvar" ToolTip="Salvar" runat="server" Text="Salvar" Cssclass="buttons"/>
                    <asp:Button ID="btnVoltar" ToolTip="Voltar" Cssclass="buttons" runat="server" Text="Voltar"/>
                </div>
            </div>
        </div>
</asp:Content>
