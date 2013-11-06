using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidade.Usuarios;
using Negocio.Usuarios;
using Entidade.Academias;
namespace SAcademia.Web.Administrativo
{
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListaUsuarios"] != null)
                {
                    gvConsulta.DataSource = (List<UsuariosGrid>)Session["ListaUsuarios"];
                    gvConsulta.DataBind();
                }
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Session["ListaUsuarios"] = null;
            Response.Redirect("~/Administrativo/CadastroUsuario.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ListaUsuarios"] = null;
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

            if (e.CommandName == "Editar")
            {
                List<UsuariosGrid> lista = (List<UsuariosGrid>)Session["ListaUsuarios"];
                UsuariosGrid usuario = lista.Find(delegate(UsuariosGrid p) { return p.Codigo == Convert.ToInt32(e.CommandArgument); });
                Session["UsuarioCadastrado"] = usuario;

                Server.Transfer("~/Administrativo/CadastroUsuario.aspx");
            }
            else if (e.CommandName == "Senha")
            {
                Valido = new NegUsuario().RedefinirSenha(((Usuarios)Session["Usuario"]).CodigoAcademia, Convert.ToInt32(e.CommandArgument), ((Usuarios)Session["Usuario"]).Codigo, ref Mensagem);

                icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                ((Site)Master).ExecutaResposta(Mensagem, icon, "");
            }
            else if (e.CommandName == "Bloquear" || e.CommandName == "Desbloquear")
            {
                Valido = new NegUsuario().BloquearUsuario(((Usuarios)Session["Usuario"]).CodigoAcademia, Convert.ToInt32(e.CommandArgument), ((Usuarios)Session["Usuario"]).Codigo, ref Mensagem);

                List<UsuariosGrid> lista = (List<UsuariosGrid>)Session["ListaUsuarios"];
                UsuariosGrid usuario = lista.Find(delegate(UsuariosGrid p) { return p.Codigo == Convert.ToInt32(e.CommandArgument); });
                usuario.Situcacao = usuario.Situcacao.ToUpper() == "ATIVO" ? "Inativo" : "Ativo";

                icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
                ((Site)Master).ExecutaResposta(Mensagem, icon, "");
            }
        }

        protected void gvConsulta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton ibBloqueio = ((ImageButton)e.Row.Cells[6].FindControl("bloqueioImageButton"));
                ImageButton ibDesloqueio = ((ImageButton)e.Row.Cells[6].FindControl("desbloqueioImageButton"));
                string Situacao = ((List<UsuariosGrid>)gvConsulta.DataSource)[e.Row.DataItemIndex].Situcacao;

                ibBloqueio.Visible = Situacao.ToUpper() == "ATIVO";
                ibDesloqueio.Visible = !ibBloqueio.Visible;
            }
        }

        #endregion

        #region "Métodos"

        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<UsuariosGrid> lista = new NegUsuario().ListarUsuarios(CodigoAcademia, txtPesquisa.Text);
            Session["ListaUsuarios"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        #endregion
    }
}