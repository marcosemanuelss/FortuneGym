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
        #region "Eventos"

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

        #endregion

        #region "Métodos"

        private void Salvar()
        {
            string Mensagem = "";
            string PaginaRetorno = "";
            string Icone = "";
            bool Valido = false;

            Academia academia = new Academia();

            if (FUpload.HasFile)
            {
                int tamanho = FUpload.PostedFile.ContentLength;
                byte[] imgbyte = new byte[tamanho];
                HttpPostedFile img = FUpload.PostedFile;
                img.InputStream.Read(imgbyte, 0, tamanho);
                academia.Logotipo = imgbyte;
            }
            else
            {
                if (Session["LogotipoAcademia"] != null)
                {
                    academia.Logotipo = (byte[])Session["LogotipoAcademia"];
                }
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
                Valido = new NegAcademia().InserirAcademia(academia, ref Mensagem);
                ExibirImagem(academia.Logotipo);
            }
            else
            {
                Valido = new NegAcademia().AtualizarAcademia(academia, ref Mensagem);
                ExibirImagem(academia.Logotipo);
                AtualizaLista(academia);
            }

            Icone = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            PaginaRetorno =  Valido ? "../Administrativo/ConsultaAcademia.aspx" : "";

            ((Site)Master).ExecutaResposta(Mensagem, Icone, PaginaRetorno);
        }

        private void AtualizaLista(Academia academia)
        {
            if (Session["ListaAcademias"] != null)
            {
                List<Academia> lista = (List<Academia>)Session["ListaAcademias"];
                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].Codigo == academia.Codigo)
                        lista[i] = academia;
                }
            }
        }

        private void CarregaCampos(Academia academia)
        {
            hddCodigoAcademia.Value = academia.Codigo.ToString();
            Session["LogotipoAcademia"] = academia.Logotipo;
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

        #endregion
    }
}