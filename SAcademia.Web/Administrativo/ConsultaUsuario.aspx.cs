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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<UsuariosGrid> lista = new NegUsuario().ListarUsuarios(CodigoAcademia, txtPesquisa.Text);
            Session["ListaUsuarios"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
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
            if (e.CommandName == "Editar")
            {
                List<UsuariosGrid> lista = (List<UsuariosGrid>)Session["ListaUsuarios"];
                UsuariosGrid usuario = lista.Find(delegate(UsuariosGrid p) { return p.Codigo == Convert.ToInt32(e.CommandArgument); });
                Session["ListaUsuarios"] = null;
                Session["UsuarioCadastrado"] = usuario;

                Server.Transfer("~/Administrativo/CadastroUsuario.aspx");
            }
            else if (e.CommandName == "Senha")
            {
                string Mensagem = "";
                new NegUsuario().RedefinirSenha(((Usuarios)Session["Usuario"]).CodigoAcademia, Convert.ToInt32(e.CommandArgument), ((Usuarios)Session["Usuario"]).Codigo, ref Mensagem);
            }
            else if (e.CommandName == "Bloquear" || e.CommandName == "Desbloquear")
            {
                new NegUsuario().BloquearUsuario(((Usuarios)Session["Usuario"]).CodigoAcademia, Convert.ToInt32(e.CommandArgument), ((Usuarios)Session["Usuario"]).Codigo);
            }
        }
    }
}