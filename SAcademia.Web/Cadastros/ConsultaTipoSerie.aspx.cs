using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Academias;
using Entidade.Fichas;
using Negocio.Fichas;
using Entidade.Usuarios;

namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaTipoSerie : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvConsulta.DataSource = Session["ListaSeriesTipo"];
                gvConsulta.DataBind();
            }
        }
        
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaSeriesTipo"] = null;
            Response.Redirect("~/Cadastros/CadastraTipoSerie.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaSeriesTipo"] = null;
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
                List<SerieTipo> lista = (List<SerieTipo>)Session["ListaSeriesTipo"];
                SerieTipo categoria = lista.Find(delegate(SerieTipo p) { return p.Codigo == Convert.ToInt32(e.CommandArgument); });
                Session["SerieTipoCadastrada"] = categoria;

                Server.Transfer("~/Cadastros/CadastraTipoSerie.aspx");
            }
            else if (e.CommandName == "Excluir")
            {
                Valido = new NegSerieTipo().DesabilitarTipo(((Usuarios)Session["Usuario"]).CodigoAcademia, Convert.ToInt32(e.CommandArgument), ref Mensagem);

                Session["ListaSeriesTipo"] = null;

                icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                ((Site)Master).ExecutaResposta(Mensagem, icon, "");
            }
            else if (e.CommandName == "Vincular Categoria")
            {
                Server.Transfer("~/Cadastros/TipoSerieCategoria.aspx");
            }
        }

        #endregion

        #region "Métodos"

        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<SerieTipo> lista = new NegSerieTipo().ListarTipos(CodigoAcademia, txtPesquisa.Text);
            Session["ListaSeriesTipo"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        #endregion

    }
}