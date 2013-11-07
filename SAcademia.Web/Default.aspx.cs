using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Usuarios;

namespace SAcademia.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        #region "Eventos"

            protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarTipoUsuario(((Usuarios)Session["Usuario"]).CodigoTipo);
            }
        }

        #endregion

        #region "Métodos"

            private void ValidarTipoUsuario(int TipoUsuario)
            {
                switch(TipoUsuario)
                {
                    case 1:
                        Response.Redirect("InicioAluno.aspx");
                        break;
                    case 2:
                        Response.Redirect("InicioAdmin.aspx");
                        break;
                    case 3:
                        Response.Redirect("InicioInstrutor.aspx");
                        break;
                    default:
                        Response.Redirect("Inicio.aspx");
                        break;
                }
            }

        #endregion
    }
}
