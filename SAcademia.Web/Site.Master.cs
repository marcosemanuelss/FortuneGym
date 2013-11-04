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
    public partial class SiteMaster : System.Web.UI.MasterPage
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
                    lblNomeAcademia.Text = academia.Nome;
            }
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
    }
}
