using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Academias;
using Entidade.Usuarios;
using Entidade.Avisos;
using Negocio.Avisos;

namespace SAcademia.Web.Cadastros
{
    public partial class ConsultaAviso : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvConsulta.DataSource = Session["ListaAvisos"];
                gvConsulta.DataBind();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaAvisos"] = null;
            Response.Redirect("~/Cadastros/CadastraAviso.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaAvisos"] = null;
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

            List<Avisos> lista = null;
            Avisos aviso = null;

            switch (e.CommandName)
            {
                case "Editar" :
                    lista = (List<Avisos>)Session["ListaAvisos"];
                    aviso = lista.Find(delegate(Avisos av) { return av.Codigo == Convert.ToInt32(e.CommandArgument); });
                    Session["AvisoCadastrado"] = aviso;

                    Server.Transfer("~/Cadastros/CadastraAviso.aspx");
                    break;

                //case "Visao":
                //    lista = (List<Avisos>)Session["ListaAvisos"];
                //    aviso = lista.Find(delegate(Avisos av) { return av.Codigo == Convert.ToInt32(e.CommandArgument); });
                //    Session["AvisoCadastrado"] = aviso;

                //    Server.Transfer("~/Cadastros/AssociaAvisoPerfil.aspx");
                //    break;

                //case "Ver":
                //    lista = (List<Avisos>)Session["ListaAvisos"];
                //    aviso = lista.Find(delegate(Avisos av) { return av.Codigo == Convert.ToInt32(e.CommandArgument); });
                //    Session["AvisoCadastrado"] = aviso;

                //    Server.Transfer("~/Cadastros/ConsultaAnexoAviso.aspx");
                //    break;

                case "Excluir":
                     Valido = new NegAvisos().DesabilitarAviso(((Usuarios)Session["Usuario"]).CodigoAcademia, Convert.ToInt32(e.CommandArgument), ((Usuarios)Session["Usuario"]).Codigo, ref Mensagem);

                     Session["ListaAvisos"] = null;

                    icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                    ((Site)Master).ExecutaResposta(Mensagem, icon, "");
                    break;
            }
            
            
        }

        #endregion

        #region "Métodos"


        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            int TipoUsuario = ((Usuarios)Session["Usuario"]).CodigoTipo;
            List<Avisos> lista = new NegAvisos().ListarAvisos(CodigoAcademia, txtPesquisa.Text, TipoUsuario);
            Session["ListaAvisos"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        #endregion
    }
}