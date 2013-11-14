using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Repeticoes;
using Entidade.Academias;
using Negocio.Repeticoes;

namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaRepeticoes : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvConsulta.DataSource = Session["ListaRepeticao"];
                gvConsulta.DataBind();
            }
        }

        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<TipoRepeticao> lista = new NegRepeticao().ListarRepeticoes(CodigoAcademia, txtPesquisa.Text);
            Session["ListaRepeticao"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaRepeticao"] = null;
            Response.Redirect("~/Cadastros/CadastraRepeticoes.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaRepeticao"] = null;
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
                List<TipoRepeticao> lista = (List<TipoRepeticao>)Session["ListaRepeticao"];
                TipoRepeticao categoria = lista.Find(delegate(TipoRepeticao p) { return p.Codigo == Convert.ToInt32(e.CommandArgument); });
                Session["RepeticaoCadastrada"] = categoria;

                Server.Transfer("~/Cadastros/CadastraRepeticoes.aspx");
            }
        }

        #endregion
    }
}