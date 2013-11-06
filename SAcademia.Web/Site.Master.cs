using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Usuarios;
using Entidade.Perfil;

namespace SAcademia.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuarios usuario = (Usuarios)Session["Usuario"];

                if (usuario != null)
                {
                    lblNomeUser.Text = usuario.Nome;
                    AjustarPerfil(usuario.Paginas);
                }

                Entidade.Academias.Academia academia = (Entidade.Academias.Academia)Session["Academia"];

                if (academia != null)
                {
                    if (Page.Request.RawUrl != "/Inicio.aspx")
                    {
                        ExibirImagem(academia.Logotipo);
                    }
                    else
                    {
                        logo.Src = "/img/softgym.jpg";
                    }
                    hddCor.Value = academia.Parametros.Cor;
                    lblNomeAcademia.Text = academia.Nome;
                }
            }
            AlterarCor(hddCor.Value);
        }

        private void ExibirImagem(byte[] imagem)
        {
            Session["Logo"] = imagem;
            logo.Src = "~/Logotipo.aspx";
            //logo.Width = 300;
            logo.Height = 54;
            logo.Attributes.Add("style", "position: relative; left:100px;");
        }

        protected void btnDesconectar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        private void AjustarPerfil(List<Paginas> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Control c = FindControl(lista[i].Nome);
                if (c != null)
                {
                    if ((c is System.Web.UI.HtmlControls.HtmlGenericControl) &&
                        ((System.Web.UI.HtmlControls.HtmlGenericControl)c).InnerText.ToString().Split('"').Length >= 2 &&
                        ((System.Web.UI.HtmlControls.HtmlGenericControl)c).InnerText.ToString().Split('"')[1] == lista[i].Url)
                    {
                        c.Visible = true;
                        c.Parent.Visible = true;
                    }
                }
            }
        }

        public void ExecutaResposta(string Mensagem, string CaminhoImagem, string PaginaDestino)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "Script";
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

        private void AlterarCor(string Cor)
        {
            // Define the name and type of the client scripts on the page.
            String csname1 = "PopupScript";
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                String cstext1 = "alteraCor('" + Cor + "');";
                cs.RegisterStartupScript(cstype, csname1, cstext1, true);
            }
        }


    }
}
