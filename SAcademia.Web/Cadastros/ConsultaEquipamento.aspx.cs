using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidade.Exercicios;
using Entidade.Academias;
using Negocio.Exercicios;

namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaEquipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListaExercicios"] != null)
                {
                    gvConsulta.DataSource = (List<Exercicio>)Session["ListaExercicios"];
                    gvConsulta.DataBind();
                }
            }
        }
        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<Exercicio> lista = new NegExercicio().ListarExercicios(CodigoAcademia, txtPesquisa.Text);
            Session["ListaExercicios"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaExercicios"] = null;
            Response.Redirect("~/Cadastros/CadastraEquipamento.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaExercicios"] = null;
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
    }
}