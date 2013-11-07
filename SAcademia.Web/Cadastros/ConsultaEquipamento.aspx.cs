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
using Entidade.Usuarios;

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
                    gvConsulta.DataSource = (List<ExercicioGrid>)Session["ListaExercicios"];
                    gvConsulta.DataBind();
                }
            }
        }
        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<ExercicioGrid> lista = new NegExercicio().ListarExercicios(CodigoAcademia, txtPesquisa.Text);
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

        protected void gvConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Mensagem = "";
            bool Valido = true;
            string icon = "";

            if (e.CommandName == "Editar")
            {
                List<ExercicioGrid> lista = (List<ExercicioGrid>)Session["ListaExercicios"];
                ExercicioGrid categoria = lista.Find(delegate(ExercicioGrid p) { return p.Codigo == Convert.ToInt32(e.CommandArgument); });
                Session["ExercicioCadastrado"] = categoria;

                Server.Transfer("~/Cadastros/CadastraEquipamento.aspx");
            }
            else if (e.CommandName == "Excluir")
            {
                Usuarios Usuario = ((Usuarios)Session["Usuario"]);
                Valido = new NegExercicio().DesabilitarExercicio(Usuario.CodigoAcademia, Convert.ToInt32(e.CommandArgument), ref Mensagem);

                Session["ListaExercicios"] = null;

                icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                ((Site)Master).ExecutaResposta(Mensagem, icon, "");
            }
        }
    }
}