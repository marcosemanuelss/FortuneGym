using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Usuarios;
using Negocio.Usuarios;

namespace SAcademia.Web.Administrativo
{
    public partial class CadastroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioCadastrado"] != null)
                {
                    PreencherEdits((UsuariosGrid)Session["UsuarioCadastrado"]);
                    txtLogin.Enabled = false;
                }
            }
        }

        private void PreencherEdits(UsuariosGrid UsuariosEdit)
        {
            dpTipoUsuario.SelectedValue = UsuariosEdit.CodigoTipo.ToString();
            txtCpf.Text = UsuariosEdit.Cpf;
            dpSituacao.SelectedValue = UsuariosEdit.Situcacao;
            txtLogin.Text = UsuariosEdit.Login;
            txtNome.Text = UsuariosEdit.Nome;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["UsuarioCadastrado"] = null;
            Response.Redirect("~/Administrativo/ConsultaUsuario.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Messagem = "";
            Usuarios NovoUsuario = new Usuarios();
            PreencherObjeto(ref NovoUsuario);

            if (Session["UsuarioCadastrado"] == null)
            {
                new NegUsuario().InserirUsuario(NovoUsuario, ref Messagem);
            }
            else
            {
                new NegUsuario().AtualizarUsuario(NovoUsuario, ((Usuarios)Session["Usuario"]).Codigo, ref Messagem);
            }

            Session["UsuarioCadastrado"] = null;
            Response.Redirect("~/Administrativo/ConsultaUsuario.aspx");
        }

        private void PreencherObjeto(ref Usuarios NovoUsuario)
        {
            NovoUsuario.CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            NovoUsuario.CodigoTipo = Convert.ToInt32(dpTipoUsuario.SelectedValue);
            NovoUsuario.Cpf = txtCpf.Text.Replace("_","").Replace("-","").Replace(".","");
            NovoUsuario.DataCadastro = DateTime.Now;
            NovoUsuario.Ativo = dpSituacao.SelectedValue.ToString() == "Ativo";
            NovoUsuario.Login = txtLogin.Text;
            NovoUsuario.Nome = txtNome.Text;
        }
    }
}