<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitaSenha.aspx.cs" Inherits="SAcademia.Web.SolicitaSenha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Principal.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="formEsqueciSenha" runat="server">
    <div>
        <h2 class="senha">ESQUECI MINHA SENHA</h2>
        <asp:Label ID="mensagemLabel" runat="server"></asp:Label>
        <div class="row-login">
            <label>Digite seu e-mail:</label>
            <asp:TextBox runat="server" ID="txtEmail" MaxLength="50"/>
        </div>
        <div class="btn">
            <asp:Button ID="btnEnviarSenha" runat="server" Text="Enviar Senha" />
        </div>
    </div>
    </form>
</body>
</html>
