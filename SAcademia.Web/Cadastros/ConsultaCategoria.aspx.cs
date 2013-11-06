using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidade.Academias;
using Entidade.Exercicios;
using Negocio.Exercicios;
namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListaCategorias"] != null)
                {
                    gvConsulta.DataSource = (List<ExercicioCategoria>)Session["ListaCategorias"];
                    gvConsulta.DataBind();
                }
            }
        }
        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<ExercicioCategoria> lista = new NegCategoria().ListarCategorias(CodigoAcademia, txtPesquisa.Text);
            Session["ListaCategorias"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaCategorias"] = null;
            Response.Redirect("~/Cadastros/CadastraCategoria.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaCategorias"] = null;
            Response.Redirect("~/Inicio.aspx");
        }
    }
}