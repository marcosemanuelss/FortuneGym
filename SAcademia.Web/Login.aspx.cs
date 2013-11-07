using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Usuarios;
using Entidade.Usuarios;
using Entidade.Academias;
using Negocio.Academias;

namespace SAcademia.Web
{
    public partial class Login : System.Web.UI.Page
    {
        #region "Eventos"

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                }
            }

            protected void btnEntrar_Click(object sender, EventArgs e)
            {
                string Mensagem = "";
                bool TrocarSenha = false;

                if (!LogarUsuario(txtLogin.Text, txtSenha.Text, ref Mensagem, ref TrocarSenha))
                    ExecutaResposta(Mensagem, "../img/icon-erro.png", "");
                else
                {
                    if (TrocarSenha)
                        Response.Redirect("~/TrocaSenha.aspx");
                    else
                        Response.Redirect("~/Default.aspx");
                }
            }

        #endregion

        #region "Métodos"

            private void ExecutaResposta(string Mensagem, string CaminhoImagem, string PaginaDestino)
            {
                // Define the name and type of the client scripts on the page.
                String csname1 = "ScriptPopUp";
                Type cstype = this.GetType();

                // Get a ClientScriptManager reference from the Page class.
                ClientScriptManager cs = Page.ClientScript;

                // Check to see if the startup script is already registered.
                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {
                    String cstext1 = "mostraPopUpAlert('" + Mensagem + "', '" + CaminhoImagem + "',false,'', '" + PaginaDestino + "');";
                    cs.RegisterStartupScript(cstype, csname1, cstext1, true);
                }
            }

            private bool LogarUsuario(string Login, string Senha, ref string Mensagem, ref bool TrocarSenha)
            {
                if (Login.Equals("") && Senha.Equals(""))
                {
                    Mensagem = "Favor informar Login e Senha.";
                    return false;
                }
                if (Senha.Equals(""))
                {
                    Mensagem = "Favor informar Senha.";
                    return false;
                }

                Usuarios usuario = new NegUsuario().Logar(Login, Senha);

                if (usuario == null)
                {
                    Mensagem = "Login ou senha inválidos.";
                    return false;
                }
                else
                {
                    Academia academia = new NegAcademia().Obter(usuario.CodigoAcademia);

                    Session["Academia"] = academia;
                    Session["Usuario"] = usuario;

                    if (usuario.AlteraSenha)
                        TrocarSenha = true;

                    return true;
                }
            }

        #endregion
    }
}