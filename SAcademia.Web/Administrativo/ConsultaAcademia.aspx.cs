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
                gvConsulta.DataBind();
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

            switch (e.CommandName)
            {
                case "Parametros":
                    AcademiaParametros parametros = new NegAcademia().ObterParametros(Convert.ToInt32(CodigoAcademia));
                    Session["ParametrosAcademia"] = parametros;
                    Response.Redirect("Parametros.aspx");

                    break;

                case "Editar":
                    List<Academia> lista = (List<Academia>)Session["ListaAcademias"];
                    Session["EditarAcademia"] = lista.Find(delegate(Academia acad) { return acad.Codigo == Convert.ToInt32(CodigoAcademia); });
                    Response.Redirect("CadastraAcademia.aspx");

                    break;
            }

        }
    }
}