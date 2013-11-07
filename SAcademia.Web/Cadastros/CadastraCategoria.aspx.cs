using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Exercicios;
using Negocio.Exercicios;
using Entidade.Usuarios;

namespace SAcademia.Web.Cadastros
{
    public partial class CadastraCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CategoriaCadastrada"] != null)
                {
                    PreencherEdits((ExercicioCategoria)Session["CategoriaCadastrada"]);
                    if (Session["NaoValido"] != null && ((bool)Session["NaoValido"]))
                        Session["CategoriaCadastrada"] = null;

                    Session["NaoValido"] = null;
                }
            }
        }

        private void PreencherEdits(ExercicioCategoria Categoria)
        {
            txtNome.Text = Categoria.Descricao;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["CategoriaCadastrada"] = null;
            Response.Redirect("~/Cadastros/ConsultaCategoria.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Mensagem = "";
            bool Valido = false;
            ExercicioCategoria NovaCategoria = new ExercicioCategoria();
            PreencherObjeto(ref NovaCategoria);

            if (Session["CategoriaCadastrada"] == null)
            {
                Session["CategoriaCadastrada"] = NovaCategoria;
                Valido = new NegCategoria().InserirCategoria(NovaCategoria, ref Mensagem);
            }
            else
            {
                NovaCategoria.Codigo = ((ExercicioCategoria)Session["CategoriaCadastrada"]).Codigo;
                Valido = new NegCategoria().AtualizarCategoria(NovaCategoria, ref Mensagem);

                if (Valido)
                    AtualizarCategoria((ExercicioCategoria)Session["CategoriaCadastrada"], NovaCategoria);
            }

            if (Valido)
                Session["CategoriaCadastrada"] = null;
            else
                Session["NaoValido"] = true;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Cadastros/ConsultaCategoria.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }

        private void AtualizarCategoria(ExercicioCategoria Categoria, ExercicioCategoria NovaCategoria)
        {
            Categoria.Descricao = NovaCategoria.Descricao;

            List<ExercicioCategoria> lista = (List<ExercicioCategoria>)Session["ListaCategorias"];
            ExercicioCategoria CategoriaGrid = lista.Find(delegate(ExercicioCategoria u) { return u.Codigo == Categoria.Codigo; });
            CategoriaGrid = Categoria;
        }

        private void PreencherObjeto(ref ExercicioCategoria NovaCategoria)
        {
            NovaCategoria.CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            NovaCategoria.Descricao = txtNome.Text;
            NovaCategoria.Ativo = true;
        }
    }
}