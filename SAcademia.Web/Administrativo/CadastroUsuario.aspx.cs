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
        #region "Eventos"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioCadastrado"] != null)
                {
                    PreencherEdits((UsuariosGrid)Session["UsuarioCadastrado"]);
                    if (Session["NaoValido"] == null || (!(bool)Session["NaoValido"]))
                        txtLogin.Enabled = false;
                    else
                        Session["UsuarioCadastrado"] = null;

                    Session["NaoValido"] = null;
                }
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["UsuarioCadastrado"] = null;
            Response.Redirect("~/Administrativo/ConsultaUsuario.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Mensagem = "";
            bool Valido = false;
            Usuarios NovoUsuario = new Usuarios();
            PreencherObjeto(ref NovoUsuario);

            if (Session["UsuarioCadastrado"] == null)
            {
                Session["UsuarioCadastrado"] = AtualizarUsuario(NovoUsuario);
                Valido = new NegUsuario().InserirUsuario(NovoUsuario, ref Mensagem);
            }
            else
            {
                NovoUsuario.Codigo = ((UsuariosGrid)Session["UsuarioCadastrado"]).Codigo;
                Valido = new NegUsuario().AtualizarUsuario(NovoUsuario, ((Usuarios)Session["Usuario"]).Codigo, ref Mensagem);

                if (Valido)
                    AtualizarUsuario((UsuariosGrid)Session["UsuarioCadastrado"], NovoUsuario);
            }

            if (Valido)
                Session["UsuarioCadastrado"] = null;
            else
                Session["NaoValido"] = true;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Administrativo/ConsultaUsuario.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }
        #endregion

        #region "Métodos"
        private void AtualizarUsuario(UsuariosGrid Usuario, Usuarios NovoUsuario)
        {
            Usuario.Nome = NovoUsuario.Nome;
            Usuario.Situcacao = NovoUsuario.Ativo ? "Ativo" : "Inativo";
            Usuario.CodigoTipo = NovoUsuario.CodigoTipo;
            Usuario.DescricaoTipo = dpTipoUsuario.Text;

            //List<UsuariosGrid> lista = (List<UsuariosGrid>)Session["ListaUsuarios"];
            //UsuariosGrid UsuarioGrid = lista.Find(delegate(UsuariosGrid u) { return u.Codigo == Usuario.Codigo; });
            //UsuarioGrid = Usuario;
        }

        private UsuariosGrid AtualizarUsuario(Usuarios NovoUsuario)
        {
            UsuariosGrid Usuario = new UsuariosGrid();
            Usuario.Nome = NovoUsuario.Nome;
            Usuario.Situcacao = NovoUsuario.Ativo ? "Ativo" : "Inativo";
            Usuario.CodigoTipo = NovoUsuario.CodigoTipo;
            Usuario.DescricaoTipo = dpTipoUsuario.Text;

            return Usuario;
        }


        private void PreencherEdits(UsuariosGrid UsuariosEdit)
        {
            dpTipoUsuario.SelectedValue = UsuariosEdit.CodigoTipo.ToString();
            txtCpf.Text = UsuariosEdit.Cpf;
            dpSituacao.SelectedValue = UsuariosEdit.Situcacao;
            txtLogin.Text = UsuariosEdit.Login;
            txtNome.Text = UsuariosEdit.Nome;
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
        #endregion
    }
}