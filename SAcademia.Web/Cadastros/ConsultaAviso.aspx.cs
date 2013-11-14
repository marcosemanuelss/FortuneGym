using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Academias;
using Entidade.Usuarios;
using Entidade.Avisos;
using Negocio.Avisos;

namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaAviso : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvConsulta.DataSource = Session["ListaAvisos"];
                gvConsulta.DataBind();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaAvisos"] = null;
            Response.Redirect("~/Cadastros/CadastraAviso.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaAvisos"] = null;
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
        }

        #endregion

        #region "Métodos"


        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            int TipoUsuario = ((Usuarios)Session["Usuario"]).CodigoTipo;
            List<Avisos> lista = new NegAvisos().ListarAvisos(CodigoAcademia, txtPesquisa.Text, TipoUsuario);
            Session["ListaAvisos"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        #endregion
    }
}