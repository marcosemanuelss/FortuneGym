using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaTipoSerie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGV();
        }
        protected void CarregaGV()
        {
            
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cadastros/CadastraTipoSerie.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
    }
}