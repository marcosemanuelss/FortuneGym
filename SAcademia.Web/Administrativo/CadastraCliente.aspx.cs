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
    public partial class CadastraCliente : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ClienteCadastrado"] != null)
                {
                    PreencherEdits((ClientesGrid)Session["ClienteCadastrado"]);
                    if (Session["NaoValido"] == null || (!(bool)Session["NaoValido"]))
                        txtLogin.Enabled = false;
                    else
                        Session["ClienteCadastrado"] = null;
                        
                    Session["NaoValido"] = null;
                }
            }
        }
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["ClienteCadastrado"] = null;
            Response.Redirect("~/Administrativo/ConsultaCliente.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Mensagem = "";
            bool Valido = false;
            Usuarios NovoUsuario = new Usuarios();
            PreencherObjeto(ref NovoUsuario);

            if (Session["ClienteCadastrado"] == null)
            {
                Session["ClienteCadastrado"] = AtualizarCliente(NovoUsuario);
                Valido = new NegCliente().InserirCliente(NovoUsuario, ref Mensagem);
            }
            else
            {
                NovoUsuario.Codigo = ((ClientesGrid)Session["ClienteCadastrado"]).Codigo;
                Valido = new NegCliente().AtualizarCliente(NovoUsuario, ((Usuarios)Session["Usuario"]).Codigo, ref Mensagem);

                if (Valido)
                    AtualizarCliente((ClientesGrid)Session["ClienteCadastrado"], NovoUsuario);
            }

            if (Valido)
                Session["ClienteCadastrado"] = null;
            else
                Session["NaoValido"] = true;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Administrativo/ConsultaCliente.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }

        #endregion

        #region "Métodos"

        private void AtualizarCliente(ClientesGrid Cliente, Usuarios NovoUsuario)
        {
            Cliente.Nome = NovoUsuario.Nome;
            Cliente.Situcacao = NovoUsuario.Ativo ? "Ativo" : "Inativo";
            Cliente.CodigoTipo = NovoUsuario.CodigoTipo;
            Cliente.Codigo = NovoUsuario.Codigo;
            Cliente.CodigoAcademia = NovoUsuario.CodigoAcademia;
            Cliente.CodigoTipo = NovoUsuario.CodigoTipo;
            Cliente.Cpf = NovoUsuario.Cpf;
            Cliente.Login = NovoUsuario.Login;

            Cliente.Bairro = NovoUsuario.Complemento.Bairro;
            Cliente.Celular = NovoUsuario.Complemento.Celular;
            Cliente.Cep = NovoUsuario.Complemento.Cep;
            Cliente.Cidade = NovoUsuario.Complemento.Cidade;
            Cliente.Complemento = NovoUsuario.Complemento.Complemento;
            Cliente.DataNascimento = NovoUsuario.Complemento.DataNascimento;
            Cliente.Email = NovoUsuario.Complemento.Email;
            Cliente.Endereco = NovoUsuario.Complemento.Endereco;
            Cliente.Estado = NovoUsuario.Complemento.Uf;
            Cliente.Matricula = NovoUsuario.Complemento.Matricula;
            Cliente.Numero = (int)NovoUsuario.Complemento.Numero;
            Cliente.Telefone = NovoUsuario.Complemento.Telefone;

            Cliente.DescricaoTipo = "Aluno";

            List<ClientesGrid> lista = (List<ClientesGrid>)Session["ListaClientes"];
            ClientesGrid ClienteGrid = lista.Find(delegate(ClientesGrid u) { return u.Codigo == Cliente.Codigo; });
            ClienteGrid = Cliente;
        }

        private ClientesGrid AtualizarCliente(Usuarios NovoUsuario)
        {
            ClientesGrid Cliente = new ClientesGrid();
            Cliente.Nome = NovoUsuario.Nome;
            Cliente.Situcacao = NovoUsuario.Ativo ? "Ativo" : "Inativo";
            Cliente.CodigoTipo = NovoUsuario.CodigoTipo;
            Cliente.Codigo = NovoUsuario.Codigo;
            Cliente.CodigoAcademia = NovoUsuario.CodigoAcademia;
            Cliente.CodigoTipo = NovoUsuario.CodigoTipo;
            Cliente.Cpf = NovoUsuario.Cpf;
            Cliente.Login = NovoUsuario.Login;

            Cliente.Bairro = NovoUsuario.Complemento.Bairro;
            Cliente.Celular = NovoUsuario.Complemento.Celular;
            Cliente.Cep = NovoUsuario.Complemento.Cep;
            Cliente.Cidade = NovoUsuario.Complemento.Cidade;
            Cliente.Complemento = NovoUsuario.Complemento.Complemento;
            Cliente.DataNascimento = NovoUsuario.Complemento.DataNascimento;
            Cliente.Email = NovoUsuario.Complemento.Email;
            Cliente.Endereco = NovoUsuario.Complemento.Endereco;
            Cliente.Estado = NovoUsuario.Complemento.Uf;
            Cliente.Matricula = NovoUsuario.Complemento.Matricula;
            Cliente.Numero = (int)NovoUsuario.Complemento.Numero;
            Cliente.Telefone = NovoUsuario.Complemento.Telefone;

            Cliente.DescricaoTipo = "Aluno";

            return Cliente;
        }


        private void PreencherEdits(ClientesGrid ClientesEdit)
        {
            txtCpf.Text = ClientesEdit.Cpf;
            dpSituacao.SelectedValue = ClientesEdit.Situcacao;
            txtLogin.Text = ClientesEdit.Login;
            txtNome.Text = ClientesEdit.Nome;

            txtMatricula.Text = ClientesEdit.Matricula;
            txtDtNascimento.Text = ClientesEdit.DataNascimento.Value.ToShortDateString();
            txtCep.Text = ClientesEdit.Cep;
            txtEndereco.Text = ClientesEdit.Endereco;
            txtNumero.Text = ClientesEdit.Numero.ToString();
            txtComplemento.Text = ClientesEdit.Complemento;
            txtBairro.Text = ClientesEdit.Bairro;
            txtCidade.Text = ClientesEdit.Cidade;
            dpUf.SelectedValue = ClientesEdit.Estado;
            txtTelRes.Text = ClientesEdit.Telefone;
            txtTelCel.Text = ClientesEdit.Celular;
            txtEmail.Text = ClientesEdit.Email;
        }


        private void PreencherObjeto(ref Usuarios NovoUsuario)
        {
            NovoUsuario.CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            NovoUsuario.CodigoTipo = 1;
            NovoUsuario.Cpf = txtCpf.Text.Replace("_", "").Replace("-", "").Replace(".", "");
            NovoUsuario.DataCadastro = DateTime.Now;
            NovoUsuario.Ativo = dpSituacao.SelectedValue.ToString() == "Ativo";
            NovoUsuario.Login = txtLogin.Text;
            NovoUsuario.Nome = txtNome.Text;

            UsuarioComplemento Complemento = new UsuarioComplemento();
            Complemento.Matricula = txtMatricula.Text;
            Complemento.DataNascimento = Convert.ToDateTime(txtDtNascimento.Text);
            Complemento.Cep = txtCep.Text.Replace("_", "").Replace(".", "").Replace("-", "");
            Complemento.Endereco = txtEndereco.Text;
            Complemento.Numero = Convert.ToInt32(txtNumero.Text);
            Complemento.Complemento = txtComplemento.Text;
            Complemento.Bairro = txtBairro.Text;
            Complemento.Cidade = txtCidade.Text;
            Complemento.Uf = dpUf.SelectedValue;
            Complemento.Telefone = txtTelRes.Text.Replace("(", "").Replace(")", "").Replace("-", "");
            Complemento.Celular = txtTelCel.Text.Replace("(", "").Replace(")", "").Replace("-", "");
            Complemento.Email = txtEmail.Text;

            NovoUsuario.Complemento = Complemento;
        }

        #endregion
    }
}