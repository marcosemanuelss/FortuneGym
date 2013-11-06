using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio.Academias;
using Entidade.Academias;

namespace SAcademia.Web.Administrativo
{
    public partial class ConsultaAcademia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvConsulta.DataSource = Session["ListaAcademias"];
                gvConsulta.DataBind();
            }
        }

        protected void CarregaGV(string Pesquisa)
        {
            List<Academia> lista = new NegAcademia().ListarAcademias(Pesquisa);
            Session["ListaAcademias"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrativo/CadastraAcademia.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaAcademias"] = null;
            Response.Redirect("~/Inicio.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregaGV(txtPesquisa.Text);
        }

        protected void gvConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string CodigoAcademia = e.CommandArgument.ToString();
            string Mensagem = "";
            string Icone = "";
            bool Valido = false;
            Academia academia = new Academia();
            List<Academia> lista = (List<Academia>)Session["ListaAcademias"];

            switch (e.CommandName)
            {
                case "Parametros":
                    AcademiaParametros parametros = new NegAcademia().ObterParametros(Convert.ToInt32(CodigoAcademia));
                    if (parametros != null)
                        Session["ParametrosAcademia"] = parametros;
                    else
                    {
                        AcademiaParametros param = new AcademiaParametros();
                        param.CodigoAcademia = Convert.ToInt32(CodigoAcademia);
                        Session["ParametrosAcademia"] = param;
                    }
                    Response.Redirect("Parametros.aspx");

                    break;

                case "Editar":
                    Session["EditarAcademia"] = lista.Find(delegate(Academia acad) { return acad.Codigo == Convert.ToInt32(CodigoAcademia); });
                    Response.Redirect("CadastraAcademia.aspx");

                    break;

                case "Bloquear":
                    Valido = new NegAcademia().AlterarSituacao(Convert.ToInt32(CodigoAcademia), false, ref Mensagem);
                    Icone = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                    ((Site)Master).ExecutaResposta(Mensagem, Icone, "");

                    if (Valido)
                    {
                        academia = lista.Find(delegate(Academia acad) { return acad.Codigo == Convert.ToInt32(CodigoAcademia); });
                        academia.Ativo = false;
                        Session["ListaAcademias"] = AtualizaListaAcademia(academia, lista);
                    }
                    break;

                case "Desbloquear":
                    Valido = new NegAcademia().AlterarSituacao(Convert.ToInt32(CodigoAcademia), true, ref Mensagem);
                    Icone = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                    ((Site)Master).ExecutaResposta(Mensagem, Icone, "");

                    if (Valido)
                    {
                        academia = lista.Find(delegate(Academia acad) { return acad.Codigo == Convert.ToInt32(CodigoAcademia); });
                        academia.Ativo = true;
                        Session["ListaAcademias"] = AtualizaListaAcademia(academia, lista);
                    }
                    break;
            }

        }

        protected void gvConsulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<Academia> lista = (List<Academia>)Session["ListaAcademias"];

                ImageButton imgBloquear = (ImageButton)e.Row.Cells[5].FindControl("btnBloquear");
                ImageButton imgDesbloquear = (ImageButton)e.Row.Cells[5].FindControl("btnDesbloquear");

                if (lista[e.Row.DataItemIndex].Ativo)
                {
                    imgBloquear.ToolTip = "Bloquear academia?";
                    imgBloquear.Visible = true;
                    imgDesbloquear.Visible = false;
                    e.Row.Cells[2].Text = "Desbloqueada";
                }
                else
                {
                    imgDesbloquear.ToolTip = "Desbloquear academia?";
                    imgDesbloquear.Visible = true;
                    imgBloquear.Visible = false;
                    e.Row.Cells[2].Text = "Bloqueada";
                }
            }
        }

        private List<Academia> AtualizaListaAcademia(Academia academia, List<Academia> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Codigo == academia.Codigo)
                    lista[i] = academia;
            }

            return lista;
        }
    }
}