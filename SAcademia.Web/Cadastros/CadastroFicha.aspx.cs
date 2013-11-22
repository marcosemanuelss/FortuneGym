using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Fichas;
using Entidade.Academias;
using Entidade.Fichas;
using Entidade.Exercicios;
using Negocio.Repeticoes;
using Negocio.Usuarios;

namespace SAcademia.Web.Cadastros
{
    public partial class CadastroFicha : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherSeries();

                Session["ListaRepeticoes"] = new NegRepeticao().ListarRepeticoes(((Academia)Session["Academia"]).Codigo, "");
            }
        }

        #endregion

        #region "Métodos"

        private void PreencherSeries()
        {
            dpSerie.DataValueField = "Codigo";
            dpSerie.DataTextField = "Nome";

            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<SerieTipo> Serie = new NegSerieTipo().ListarTipos(CodigoAcademia);
            Session["Series"] = Serie;
            dpSerie.DataSource = Serie;
            dpSerie.DataBind();

            PreencherGridExercicio();
        }

        #endregion

        protected void btnProcurarMatricula_Click(object sender, EventArgs e)
        {
            ucModalPopupPesquisaMatricula1.Call("~/Default.aspx", "~/Default.aspx");
        }

        protected void dpSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherGridExercicio();
        }

        private void PreencherGridExercicio()
        {
            if (dpSerie.SelectedIndex != -1)
            {
                List<SerieTipo> serie = (List<SerieTipo>)Session["Series"];
                int Index = serie.FindIndex(delegate(SerieTipo se) { return se.Codigo == Convert.ToInt32(dpSerie.SelectedValue); });

                if (Index >= 0)
                {
                    Session["ExercicioGrid"] = serie[Index].Exercicios;
                    gvSeries.DataSource = serie[Index].Exercicios;
                }
                else
                {
                    gvSeries.DataSource = null;
                }

                gvSeries.DataBind();
            }
        }

        private void AtualizarExercicio()
        {
            if (dpSerie.SelectedIndex != -1)
            {
                List<SerieTipo> serie = (List<SerieTipo>)Session["Series"];
                int Index = serie.FindIndex(delegate(SerieTipo se) { return se.Codigo == Convert.ToInt32(dpSerie.SelectedValue); });

                if (Index >= 0)
                {
                    serie[Index].Exercicios = (List<ExercicioFichaGrid>)Session["ExercicioGrid"];
                    PreencherGridExercicio();
                }
            }
        }

        protected void btnAdicionarExercicios_Click(object sender, EventArgs e)
        {
            List<ExercicioFichaGrid> NovaLista = (List<ExercicioFichaGrid>)Session["ExercicioAluno"];

            if(NovaLista == null)
                NovaLista = new List<ExercicioFichaGrid>();

            List<ExercicioFichaGrid> AntigaLista = (List<ExercicioFichaGrid>)Session["ExercicioGrid"];

            foreach (GridViewRow row in gvSeries.Rows)
            {
                if (((CheckBox)row.FindControl("cbExercicio")).Checked)
                {
                    ExercicioFichaGrid valor = AntigaLista.Find(delegate(ExercicioFichaGrid ex) { return ex.Codigo == Convert.ToInt32(((HiddenField)row.Cells[0].FindControl("Codigo")).Value); });
                    NovaLista.Add(valor);
                    AntigaLista.Remove(valor);
                }
            }

            Session["ExercicioAluno"] = NovaLista;
            CarregarGridExercicioAluno();
            AtualizarExercicio();
        }

        private void CarregarGridExercicioAluno()
        {
            gvExerciciosAdicionados.DataSource = Session["ExercicioAluno"];
            gvExerciciosAdicionados.DataBind();
        }

        protected void gvSeries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField Codigo = (HiddenField)e.Row.Cells[0].FindControl("Codigo");

                Codigo.Value = ((ExercicioFichaGrid)e.Row.DataItem).Codigo.ToString();
            }
        }

        protected void gvExerciciosAdicionados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList Combo = (DropDownList)e.Row.Cells[1].FindControl("dpRepeticao");

                Combo.DataSource = Session["ListaRepeticoes"];
                Combo.DataBind();
                //Combo.SelectedValue = ((ExercicioFichaGrid)e.Row.DataItem).Codigo.ToString();
            }
        }

        protected void gvExerciciosAdicionados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remover")
            {
                List<ExercicioFichaGrid> NovaLista = (List<ExercicioFichaGrid>)Session["ExercicioAluno"];
                List<ExercicioFichaGrid> AntigaLista = (List<ExercicioFichaGrid>)Session["ExercicioGrid"];

                ExercicioFichaGrid valor = NovaLista.Find(delegate(ExercicioFichaGrid ex) { return ex.Codigo == Convert.ToInt32(e.CommandArgument); });
                AntigaLista.Add(valor);
                NovaLista.Remove(valor);

                CarregarGridExercicioAluno();
                AtualizarExercicio();
            }
        }

        [System.Web.Services.WebMethod]
        public static Boolean ValidaUnicoCPF(int CodigoAcademia, string Filtro, ref int Codigo, ref string Matricula, ref string Nome, ref bool IsFichaAtiva)
        {
            Nome = "";
            Codigo = 0;
            Matricula = "";
            IsFichaAtiva = false;
            List < Entidade.Usuarios.Usuarios> Retorno = new NegUsuario().ObterDadosUsuarioFicha(CodigoAcademia, Filtro, ref Codigo, ref Matricula, ref Nome, ref IsFichaAtiva);

            HttpContext.Current.Session["ListaUsuarioAux"] = Retorno;

            return Retorno.Count == 1;
        }
    }
}