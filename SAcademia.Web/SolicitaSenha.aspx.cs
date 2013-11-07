using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Usuarios;

namespace SAcademia.Web
{
    public partial class SolicitaSenha : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviarSenha_Click(object sender, EventArgs e)
        {
            ValidaUsuarioCPF(txtCpf.Text.Replace(".","").Replace("-",""));
        }

        private void ValidaUsuarioCPF(string CPF)
        {
            string Mensagem = "";
            string Icone = "";
            //string Pagina = "";

            bool Valido = new NegUsuario().ObterUsuario(CPF, ref Mensagem);

            if (Valido)
            {
                EnviarEmail(txtCpf.Text, txtEmail.Text);
                Icone = "../img/icon-ok.png";
                //Pagina = "Login.aspx";
            }
            else
            {
                Icone = "../img/icon-erro.png";
            }

            ExecutaResposta(Mensagem, Icone, "");
        }

        private void EnviarEmail(string CPF, string Email)
        {
            string Mensagem = "O usuário de CPF: " + CPF + ", solicitou uma troca senha às " + DateTime.Now.ToShortTimeString() +
                              " do dia " + DateTime.Now.ToShortDateString() + " \n";
            Mensagem += "Nova senha para acesso: trocar@123 \n";

            ucEnviaEmail1.SendMail(
                "smtp.gmail.com",
                587,
                true,
                Email,
                "fortunee.gym@gmail.com",
                "teste@123",
                "Suporte SoftGym",
                "Solicitação de senha",
                Mensagem
                );
        }

        private void ExecutaResposta(string Mensagem, string CaminhoImagem, string PaginaDestino)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "ScriptPopUpSenha";
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
    }
}