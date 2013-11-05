<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SAcademia.Web.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sistema Academia</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="~/Styles/Principal.css" rel="stylesheet" type="text/css" />
    <link href="~/Scripts/shadowbox/shadowbox.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/atualizarBrowser.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/shadowbox/shadowbox.js"></script>
    <script type="text/javascript" src="Scripts/jAtualizarBrowser.js"></script>
    <script type="text/javascript">
        Shadowbox.init();
    </script>
    <script type="text/javascript">

        $(function () {
            window.onload = function () {
                document.getElementById('txtSenha').onkeypress = function (e) {
                    doClick('btnEntrar', e);
                };
            };
        });

        function esqueceuSenha() {
            Shadowbox.open({
                content: '<div id="welcome-msg"><iframe name="interna" scrolling="no" height="180" frameborder="0" width="100%" allowtransparency="true" src="SolicitaSenha.aspx", null, 1); ?>" ></iframe></div>',
                player: "html",
                title: "",
                height: 200,
                width: 520
            });
        }

        //FOCUS NO CAMPO DE LOGIN
        $(document).ready(function () {
            $("#txtLogin").focus();
        });
    </script>
    <!--[if lt IE 9]>
		<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
	<![endif]-->    
	<!-- Adding "maximum-scale=1" fixes the Mobile Safari auto-zoom bug: http://filamentgroup.com/examples/iosScaleBug/ -->
</head>
<body>
    <div id="browser"></div>
    <form id="form" runat="server">
        <div>
            <div id="tudo">
                <div class="descricaosys"><img src="img/softgym.jpg" alt="logo" /></div>
                <div class="centro">
                    <div class="acesso">
                        <h2>ACESSE NOSSO SISTEMA</h2>
                        <div class="row-login">
                            <label>Login:</label>
                            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                        </div>
                        <div class="row-login">
                            <label>Senha:</label>
                            <asp:TextBox TextMode="Password" ID="txtSenha" runat="server"></asp:TextBox>
                        </div>
                        <div class="links">
                            <asp:Button Text="Entrar" ID="btnEntrar" ToolTip="Entrar" runat="server" 
                                onclick="btnEntrar_Click" />
                            <div class="esqueceu-senha"><a href="#" rel="shadowbox:;" onclick="esqueceuSenha();" title="Esqueceu sua senha?">Esqueceu sua senha?</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
    </form>
</body>
</html>
