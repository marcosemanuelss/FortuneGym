<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitaSenha.aspx.cs" Inherits="SAcademia.Web.SolicitaSenha" %>

<%@ Register Src="~/Controls/ucEnviaEmail.ascx" TagName="ucEnviaEmail" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Styles/Principal.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.mask.js"></script>
    <script src="/Scripts/jValidate.js" type="text/javascript"></script> 
    <script type="text/javascript">
        //Função para validar CPF
        function validarCPF(cpf) {
            cpf = cpf.replace(/[^\d]+/g, '');
            if (cpf == '') return true;
            // Elimina CPFs invalidos conhecidos
            if (cpf.length != 11 ||
                cpf == "00000000000" ||
                cpf == "11111111111" ||
                cpf == "22222222222" ||
                cpf == "33333333333" ||
                cpf == "44444444444" ||
                cpf == "55555555555" ||
                cpf == "66666666666" ||
                cpf == "77777777777" ||
                cpf == "88888888888" ||
                cpf == "99999999999")
                return false;
            // Valida 1o digito
            add = 0;
            for (i = 0; i < 9; i++)
                add += parseInt(cpf.charAt(i)) * (10 - i);
            rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != parseInt(cpf.charAt(9)))
                return false;
            // Valida 2o digito
            add = 0;
            for (i = 0; i < 10; i++)
                add += parseInt(cpf.charAt(i)) * (11 - i);
            rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
                rev = 0;
            if (rev != parseInt(cpf.charAt(10)))
                return false;
            return true;
        }

        //FUNÇÃO PARA EXECUTAR O EVENTO DO BOTÃO DE SUBMIT DA PÁGINA, AO PRESSIONAR A TECLA ENTER
        function doClick(buttonName, e) {
            //the purpose of this function is to allow the enter key to 
            //point to the correct button to click.
            var ev = e || window.event;
            var key = ev.keyCode;

            if (key == 13) {
                //Get the button the user wants to have clicked
                var btn = document.getElementById(buttonName);
                if (btn != null) {
                    //If we find the button click it
                    btn.click();
                    ev.preventDefault();
                }
            }
        }

        $(function () {
            window.onload = function () {
                document.getElementById('txtEmail').onkeypress = function (e) {
                    doClick('btnEnviarSenha', e);
                };
            };
        });

        //END
        $(function () {
            $('#txtCpf').focus();
            //MÁSCARAS
            $('#txtCpf').mask('999.999.999-99');
        });

        //Limpa Campo 
        function limpaCampo(ID) {
            $('#' + ID).val("");
        }

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

            parent.closePopUp();

            if (paginaDestino != 'undefined') {
                $(location).attr('href', paginaDestino);
            }
        }
        // END

    </script>
</head>
<body>
    <form id="formEsqueciSenha" runat="server">
    <uc1:ucEnviaEmail ID="ucEnviaEmail1" runat="server" />
    <div>
        <h2 class="senha">ESQUECI MINHA SENHA</h2>
        <div class="bg-tabela">
            <div class="row-login">
                <label>Digite seu CPF*:</label>
                <asp:TextBox runat="server" ID="txtCpf" onBlur="if(!validarCPF(this.value)){limpaCampo(this.id); mostraPopUpAlert('CPF inválido! Digite novamente.','../img/icon-erro.png',false,this.id);}" CssClass="input-senha required"/>
            </div>
            <div class="row-login">
                <label>Digite seu e-mail*:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="input-senha required mail"/>
            </div>
            <div class="btn">
                <asp:Button ID="btnEnviarSenha" OnClientClick="return valida();" runat="server" 
                    Text="Enviar Senha" onclick="btnEnviarSenha_Click" />
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
    </div>
    </form>
        <script type="text/javascript">
            function closePopUp() {
                console.log("test");
                //cocument.querySelector('#welcome-msg').style.display = none;
                parent.Shadowbox.close();
            }
    </script>
</body>
</html>
