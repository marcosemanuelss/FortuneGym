using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Academias;
using Entidade.Fichas;
using Negocio.Fichas;

namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaFicha : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvConsulta.DataSource = Session["ListaFichas"];
                gvConsulta.DataBind();
            }
        }

        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<Ficha> lista = new NegFicha().ListarFicha(CodigoAcademia, txtPesquisa.Text);
            Session["ListaFichas"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaFichas"] = null;
            Response.Redirect("~/Cadastros/CadastroFicha.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaFichas"] = null;
            Response.Redirect("~/Default.aspx");
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

        #endregion
    }
}