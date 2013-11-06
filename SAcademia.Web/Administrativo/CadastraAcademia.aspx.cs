using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Academias;
using Negocio.Academias;

namespace SAcademia.Web.Administrativo
{
    public partial class CadastraAcademia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["EditarAcademia"] != null)
                {
                    CarregaCampos((Academia)Session["EditarAcademia"]);
                    Session["EditarAcademia"] = null;
                }
                else
                    CarregaCombo(true);
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrativo/ConsultaAcademia.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            int retorno = 0;
            Academia academia = new Academia();

            if (FUpload.HasFile)
            {
                int tamanho = FUpload.PostedFile.ContentLength;
                byte[] imgbyte = new byte[tamanho];
                HttpPostedFile img = FUpload.PostedFile;
                img.InputStream.Read(imgbyte, 0, tamanho);
                academia.Logotipo = imgbyte;
            }
            if (hddCodigoAcademia.Value != "")
                academia.Codigo = Convert.ToInt32(hddCodigoAcademia.Value);

            academia.CNPJ = txtCnpj.Text.Replace(".", "").Replace("/", "").Replace("-", "");
            academia.Nome = txtNome.Text;
            academia.Email = txtEmail.Text;
            academia.Cep = txtCep.Text.Replace(".", "").Replace("-", "");
            academia.Endereco = txtEndereco.Text;
            academia.Numero = Convert.ToInt32(txtNumero.Text);
            academia.Complemento = txtComplemento.Text;
            academia.Bairro = txtBairro.Text;
            academia.Cidade = txtCidade.Text;
            academia.Uf = txtUf.Text;
            academia.Telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "");
            academia.Ativo = dpSituacao.SelectedIndex == 1 ? true : false;

            if (academia.Codigo == 0)
            {
                retorno = new NegAcademia().InserirAcademia(academia);
                ExibirImagem(academia.Logotipo);
            }
            else
            {
                retorno = new NegAcademia().AtualizarAcademia(academia);
                ExibirImagem(academia.Logotipo);
            }

            if (retorno > 0)
                ((Site)Master).ExecutaResposta("Academia salva com sucesso!", "../img/icon-ok.png", "../Administrativo/ConsultaAcademia.aspx");
            else
                ((Site)Master).ExecutaResposta("Erro ao salvar academia. Cadastro cancelado.", "../img/icon-erro.png", "");
        }

        private void CarregaCampos(Academia academia)
        {
            hddCodigoAcademia.Value = academia.Codigo.ToString();
            txtCnpj.Text = academia.CNPJ;
            txtNome.Text = academia.Nome;
            txtEmail.Text = academia.Email;
            txtCep.Text = academia.Cep;
            txtEndereco.Text = academia.Endereco;
            txtNumero.Text = academia.Numero.ToString();
            txtComplemento.Text = academia.Complemento;
            txtBairro.Text = academia.Bairro;
            txtCidade.Text = academia.Cidade;
            txtUf.Text = academia.Uf;
            txtTelefone.Text = academia.Telefone;
            CarregaCombo(academia.Ativo);

            if (academia.Logotipo != null)
                ExibirImagem(academia.Logotipo);
            
        }

        private void CarregaCombo(bool Ativo)
        {
            dpSituacao.DataSource = new NegAcademia().TipoSituacao();
            dpSituacao.DataBind();

            if (Ativo)
                dpSituacao.SelectedIndex = 1;
            else
                dpSituacao.SelectedIndex = 2;
        }

        private void ExibirImagem(byte[] imagem)
        {
            Session["Logotipo"] = imagem;
            ImagemAcademia.Src = "~/Administrativo/ImagemAcademia.aspx";
            ImagemAcademia.Width = 36;
            ImagemAcademia.Height = 36;
        }
    }
}