using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Avisos;
namespace SFF.Web.Cadastros
{
    public partial class ConsultaAnexoAviso : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AvisoCadastrado"] != null)
                {
                    Avisos aviso = (Avisos)Session["AvisoCadastrado"];

                    gvConsulta.DataSource = aviso.Arquivos;
                    gvConsulta.DataBind();
                }
            }
        }

        #endregion
    }
}