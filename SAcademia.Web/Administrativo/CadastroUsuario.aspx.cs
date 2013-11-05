using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Usuarios;

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
                    PreencherEdits((UsuariosGrid)Session["UsuarioCadastro"]);
                    txtLogin.ReadOnly = true;
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
            Usuarios NovoUsuario = new Usuarios();
            PreencherObjeto(ref NovoUsuario);

            if (Session["UsuarioCadastrado"] == null)
            {
                //Inserir um novo
            }
            else
            {
                //Atualizar existente
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