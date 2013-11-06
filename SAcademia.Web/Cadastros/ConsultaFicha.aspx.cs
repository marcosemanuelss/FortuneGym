using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaFicha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CarregaGV()
        {
            
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaFichas"] = null;
            Response.Redirect("~/Cadastros/CadastroFicha.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaFichas"] = null;
            Response.Redirect("~/Inicio.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregaGV();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = String.Empty;
            CarregaGV();
        }

        protected void gvConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                
            }
            else if (e.CommandName == "Bloquear" || e.CommandName == "Desbloquear")
            {
                
            }
        }
    }
}