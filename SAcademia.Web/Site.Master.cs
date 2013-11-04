using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Usuarios;

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
                    lblNomeUser.Text = usuario.Nome;

                Entidade.Academias.Academia academia = (Entidade.Academias.Academia)Session["Academia"];

                if (academia != null)
                    lblNomeAcademia.Text = academia.Nome;
            }
        }
    }
}
