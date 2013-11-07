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
    public partial class CadastraEquipamento : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;

                PreencherDropDown(CodigoAcademia);

                if (Session["ExercicioCadastrado"] != null)
                {
                    PreencherEdits((ExercicioGrid)Session["ExercicioCadastrado"]);
                    if (Session["NaoValido"] != null && ((bool)Session["NaoValido"]))
                        Session["ExercicioCadastrado"] = null;

                    Session["NaoValido"] = null;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Mensagem = "";
            bool Valido = false;
            ExercicioGrid NovoExercicio = new ExercicioGrid();
            PreencherObjeto(ref NovoExercicio);

            if (Session["ExercicioCadastrado"] == null)
            {
                Session["ExercicioCadastrado"] = NovoExercicio;
                Valido = new NegExercicio().InserirExercicio(NovoExercicio, ref Mensagem);
            }
            else
            {
                NovoExercicio.Codigo = ((ExercicioGrid)Session["ExercicioCadastrado"]).Codigo;
                Valido = new NegExercicio().AtualizarExercicio(NovoExercicio, ref Mensagem);

                if (Valido)
                    AtualizarExercicio(NovoExercicio);
            }

            if (Valido)
                Session["ExercicioCadastrado"] = null;
            else
                Session["NaoValido"] = true;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Cadastros/ConsultaEquipamento.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

            Session["ExercicioCadastrado"] = null;
            Response.Redirect("~/Cadastros/ConsultaEquipamento.aspx");
        }

        #endregion 

        #region "Métodos"

        private void PreencherEdits(ExercicioGrid Exercicio)
        {
            txtNome.Text = Exercicio.Nome;
            dpCategoria.SelectedValue = Exercicio.CodigoCategoria.ToString();
        }

        private void PreencherObjeto(ref ExercicioGrid NovoExercicio)
        {
            NovoExercicio.CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            NovoExercicio.Nome = txtNome.Text;
            NovoExercicio.CodigoCategoria = Convert.ToInt32(dpCategoria.SelectedValue);
            NovoExercicio.Categoria = dpCategoria.SelectedItem.Text;
            NovoExercicio.Ativo = true;
        }

        private void AtualizarExercicio(ExercicioGrid NovoExercicio)
        {
            int Codigo = NovoExercicio.Codigo;
            List<ExercicioGrid> lista = (List<ExercicioGrid>)Session["ListaExercicios"];
            int CategoriaGrid = lista.FindIndex(delegate(ExercicioGrid u) { return u.Codigo == Codigo; });

            if (CategoriaGrid >= 0)
                lista[CategoriaGrid] = NovoExercicio;
            
        }

        private void PreencherDropDown(int CodigoAcademia)
        {
            dpCategoria.DataValueField = "Codigo";
            dpCategoria.DataTextField = "Descricao";

            dpCategoria.DataSource = new NegCategoria().ListarCategorias(CodigoAcademia, "");
            dpCategoria.DataBind();
        }
        
        #endregion
    }
}