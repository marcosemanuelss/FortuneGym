using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Usuarios;
using Negocio.Usuarios;

namespace SAcademia.Web
{
    public partial class AlterarSenha : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = (Usuarios)Session["Usuario"];

            if (VerificaSenhaAntiga(txtSenhaAntiga.Text, usuario.Senha, usuario.SenhaSalt))
            {
                SalvarNovaSenha(usuario.CodigoAcademia, usuario.Codigo, txtSenhaNova.Text);
            }
            else
            {
                ExecutaResposta("Favor digite a senha anterior correta.", "../img/icon-erro.png", "");
            }
        }

        #endregion

        #region "Métodos"

        private string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        private bool VerificaSenhaAntiga(string SenhaAntiga, string SenhaAntigaUsuario, string SenhaAntigaSalt)
        {
            //Senha digitada
            string SenhaOld = getMD5Hash(SenhaAntiga + SenhaAntigaSalt);

            if (!SenhaOld.Equals(SenhaAntigaUsuario))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void SalvarNovaSenha(int CodigoAcademia, int CodigoUsuario, string NovaSenha)
        {
            string Mensagem = "";
            string Icone = "";
            string PaginaRetorno = "";
            bool Valido = new NegUsuario().AlterarSenhaUsuario(CodigoAcademia, CodigoUsuario, NovaSenha, ref Mensagem);

            if (Valido)
            {
                Icone = "../img/icon-ok.png";
                PaginaRetorno = "Login.aspx";
            }
            else
            {
                Icone = "../img/icon-erro.png";
            }

            ExecutaResposta(Mensagem, Icone, PaginaRetorno);    
        }

        private void ExecutaResposta(string Mensagem, string CaminhoImagem, string PaginaDestino)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "ScriptAlterarSenha";
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

        #endregion
    }
}