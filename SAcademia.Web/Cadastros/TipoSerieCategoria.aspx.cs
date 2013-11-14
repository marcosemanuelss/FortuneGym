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
                    ExercicioCategoria valor = AntigaLista.Find(delegate(ExercicioCategoria ex) { return ex.Codigo == Convert.ToInt32(((HiddenField)row.Cells[0].FindControl("Codigo")).Value); });
                    NovaLista.Add(valor);
                }
            }

            SerieTipo tipo = (SerieTipo)Session["SerieTipoVincular"];

            string Mensagem = "";
            bool Valido = false;

            Valido = new NegSerieTipo().VincularTipoCategoria(tipo, NovaLista, ref Mensagem);
            tipo.Categorias = Valido ? NovaLista : tipo.Categorias;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Cadastros/ConsultaTipoSerie.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }

        protected void gvConsulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField Codigo = (HiddenField)e.Row.Cells[0].FindControl("Codigo");

                Codigo.Value = ((ExercicioCategoria)e.Row.DataItem).Codigo.ToString();

                SerieTipo tipo = (SerieTipo)Session["SerieTipoVincular"];

                CheckBox check = (CheckBox)e.Row.Cells[0].FindControl("cbCategoria");

                check.Checked = tipo.Categorias != null &&
                    tipo.Categorias.Find(delegate(ExercicioCategoria eca) { return eca.Codigo == Convert.ToInt32(Codigo.Value); }) != null;
            }
        }
    }
}