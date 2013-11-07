<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="SAcademia.Web.AlterarSenha" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Sistema Academia - Alterar Senha</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="~/Styles/Principal.css" rel="stylesheet" type="text/css" />
    <link href="~/Scripts/shadowbox/shadowbox.css" rel="stylesheet" type="text/css" />
    <link href="~/Styles/atualizarBrowser.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/shadowbox/shadowbox.js"></script>
    <script type="text/javascript" src="Scripts/jAtualizarBrowser.js"></script>
    <script src="Scripts/jValidateLogin.js" type="text/javascript"></script> 
    <script type="text/javascript">
        Shadowbox.init();
    </script>
    <script type="text/javascript">

        $(function () {
            window.onload = function () {
                document.getElementById('txtSenhaNovaRepeat').onkeypress = function (e) {
                    doClick('btnSalvar', e);
                };
            };
        });

        //FOCUS NO CAMPO DE LOGIN
        $(document).ready(function () {
            $("#txtSenhaAntiga").focus();
        });

        //Função ALERT MENSAGEM PERSONALIZADO
        function mostraPopUpAlert(mensagemAlert, iconeAlert, bool, ID, paginaDestino) {
            var IDNome = "'" + ID + "'";
            var paginaDestinoNome = "'" + paginaDestino + "'";

            $('#Modal').show();
            $('#iconeAlert').attr("src", iconeAlert);
            $('#mensagemAlert').html(mensagemAlert);
            if (bool) {
                var input1 = '<input type="button" class="buttons" id="btnOK" title="OK" value="OK" onclick="confirmaAlert(' + IDNome + ');" />';
                var input2 = '<input type="button" class="buttons" id="btnCancel" title="Cancelar" value="Cancelar" onclick="return fechar();" />';
                $('.btnsAlert').html(input1 + input2);
            } else {
                $('.btnsAlert').html('<input type="button" class="buttons" id="btnOK" title="OK" value="OK" onclick="return fechar(' + paginaDestinoNome + ');" />')
            }
            $("#btnOK").focus();
            return false;
        }

        function confirmaAlert(ID) {
            $('#' + ID).attr("onclick", "return true;");
            $('#' + ID).click();
            fechar();
            return true;
        }

        function fechar(paginaDestino) {
            $('#Modal').hide();

            if (paginaDestino != 'undefined') {
                $(location).attr('href', paginaDestino);
            }
        }
        // END

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
                        <h2 class="cabecalhoAlterarSenha">ALTERAR A SENHA</h2>
                        <div class="row-login">
                            <label>Senha Antiga*:</label>
                            <asp:TextBox ID="txtSenhaAntiga" TextMode="Password" CssClass="required" runat="server"></asp:TextBox>
                        </div>
                        <div class="row-login">
                            <label>Senha Nova*:</label>
                            <asp:TextBox TextMode="Password" ID="txtSenhaNova" CssClass="required" runat="server"></asp:TextBox>
                        </div>
                        <div class="row-login">
                            <label>Repita Senha Nova*:</label>
                            <asp:TextBox TextMode="Password" ID="txtSenhaNovaRepeat" CssClass="required" runat="server"></asp:TextBox>
                        </div>
                        <span class="campObrigatorioLogin">(*) Campo Obrigatório</span>
                        <div class="links">
                            <asp:Button Text="Salvar" ID="btnSalvar" OnClientClick="return valida();" CssClass="btnsLogin" ToolTip="Salvar" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="Modal" style="display: none;">
            <div id="teste" class="mensagemAlert">
            </div>
            <div id="alert" class="boxAlert">
                <img src="" alt="imagem" id="iconeAlert" class="iconeAlert" />
                <p id="mensagemAlert">
                </p>
                <div class="btnsAlert">
                </div>
            </div>
        </div>
    </form>

</body>
</html>

