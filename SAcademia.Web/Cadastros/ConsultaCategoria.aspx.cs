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
using Entidade.Usuarios;
namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaCategoria : System.Web.UI.Page
    {
        #region "Eventos"

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

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaCategorias"] = null;
            Response.Redirect("~/Cadastros/CadastraCategoria.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaCategorias"] = null;
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
            string Mensagem = "";
            bool Valido = true;
            string icon = "";

            if (e.CommandName == "Editar")
            {
                List<ExercicioCategoria> lista = (List<ExercicioCategoria>)Session["ListaCategorias"];
                ExercicioCategoria categoria = lista.Find(delegate(ExercicioCategoria p) { return p.Codigo == Convert.ToInt32(e.CommandArgument); });
                Session["CategoriaCadastrada"] = categoria;

                Server.Transfer("~/Cadastros/CadastraCategoria.aspx");
            }
            else if (e.CommandName == "Excluir")
            {
                Valido = new NegCategoria().DesabilitarCategoria(((Usuarios)Session["Usuario"]).CodigoAcademia, Convert.ToInt32(e.CommandArgument), ref Mensagem);

                Session["ListaCategorias"] = null;

                icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                ((Site)Master).ExecutaResposta(Mensagem, icon, "");
            }
        }

        #endregion

        #region "Métodos"

        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<ExercicioCategoria> lista = new NegCategoria().ListarCategorias(CodigoAcademia, txtPesquisa.Text);
            Session["ListaCategorias"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        #endregion
    }
}