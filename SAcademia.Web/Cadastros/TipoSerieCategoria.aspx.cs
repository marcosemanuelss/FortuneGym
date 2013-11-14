using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Exercicios;
using Entidade.Usuarios;
using Entidade.Exercicios;
using Negocio.Fichas;
using Entidade.Fichas;

namespace SAcademia.Web.Cadastros
{
    public partial class TipoSerieCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
                List<ExercicioCategoria> lista = new NegCategoria().ListarCategorias(CodigoAcademia, "");
                Session["ListaCategoriasVinculo"] = lista;
                gvConsulta.DataSource = lista;
                gvConsulta.DataBind();
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["SerieTipoVincular"] = null;
            Response.Redirect("~/Cadastros/ConsultaTipoSerie.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            List<ExercicioCategoria> NovaLista = new List<ExercicioCategoria>();
            List<ExercicioCategoria> AntigaLista = (List<ExercicioCategoria>)Session["ListaCategoriasVinculo"];
            foreach (GridViewRow row in gvConsulta.Rows)
            {
                if (((CheckBox)row.FindControl("cbCategoria")).Checked)
                {
                    ExercicioCategoria valor = AntigaLista.Find(delegate(ExercicioCategoria ex) { return ex.Codigo == Convert.ToInt32(row.Cells[2].Val); });
                    NovaLista.Add(valor);
                }
            }

            string Mensagem = "";
            new NegSerieTipo().VincularTipoCategoria((SerieTipo)Session["SerieTipoVincular"], NovaLista, ref Mensagem);
        }

        protected void gvConsulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<ExercicioCategoria> lista = (List<ExercicioCategoria>)Session["ListaCategoriasVinculo"];

                HiddenField Codigo = (HiddenField)e.Row.Cells[2].FindControl("Codigo");

                Codigo.Value = lista[e.Row.DataItemIndex].Codigo.ToString();
            }
        }
    }
}