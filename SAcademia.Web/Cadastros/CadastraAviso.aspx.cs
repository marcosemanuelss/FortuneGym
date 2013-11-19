using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Avisos;
using Negocio.Avisos;
using Entidade.Usuarios;
using Negocio.Usuarios;
namespace SAcademia.Web.Cadastros
{
    public partial class CadastraAviso : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AvisoCadastrado"] != null)
                {
                    PreencherEdits((Avisos)Session["AvisoCadastrado"]);
                    if (Session["NaoValido"] != null && ((bool)Session["NaoValido"]))
                        Session["AvisoCadastrado"] = null;

                    Session["NaoValido"] = null;
                }

                AtualizarSessaoListaTipoUsuario();
                AtualizarDropDownPerfil();
            }
        }

        protected void btnAdicionarPerfil_Click(object sender, EventArgs e)
        {
            if (dpAssociarPerfil.SelectedIndex != -1)
            {
                AvisosVisao visao = new AvisosVisao();

                visao.CodigoTipoUsuario = Convert.ToInt32(dpAssociarPerfil.SelectedValue);
                visao.Descricao = dpAssociarPerfil.SelectedItem.Text;

                List<AvisosVisao> lista = (List<AvisosVisao>)Session["VisaoAviso"];
                if (lista == null)
                {
                    lista = new List<AvisosVisao>();
                }

                lista.Add(visao);

                Session["VisaoAviso"] = lista;
                CarregarGridVisao();
                AtualizarDropDownPerfil();
            }
            else
            {
                string icon = "../img/icon-atencao.png";
                string TelaRetorno = "";
                ((Site)Master).ExecutaResposta("Não existe mais perfil para ser selecionado.", icon, TelaRetorno);
            }
        }

        protected void btnAdicionarAnexo_Click(object sender, EventArgs e)
        {
            if (FUpload.HasFile)
            {
                int tamanho = FUpload.PostedFile.ContentLength;
                byte[] imgbyte = new byte[tamanho];
                HttpPostedFile img = FUpload.PostedFile;
                img.InputStream.Read(imgbyte, 0, tamanho);

                int ponto = FUpload.FileName.ToString().LastIndexOf('.');
                AvisosArquivos Arquivo = new AvisosArquivos();

                Arquivo.Extensao = FUpload.FileName.ToString().Substring(ponto, 4);
                Arquivo.Arquivo = imgbyte;
                Arquivo.Descricao = FUpload.FileName.Substring(0, ponto);

                if (Session["ArquivosAviso"] == null)
                    Session["ArquivosAviso"] = new List<AvisosArquivos>();

                List<AvisosArquivos> ListaArquivo = (List<AvisosArquivos>)Session["ArquivosAviso"];
                ListaArquivo.Add(Arquivo);

                CarregarGridArquivo();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Mensagem = "";
            bool Valido = false;
            Avisos NovoAviso = new Avisos();
            PreencherObjeto(ref NovoAviso);

            if (Session["AvisoCadastrado"] == null)
            {
                Session["AvisoCadastrado"] = NovoAviso;
                NovoAviso.CodigoUsuarioCadastro = ((Usuarios)Session["Usuario"]).Codigo;
                Valido = new NegAvisos().InserirAviso(NovoAviso, ref Mensagem);
            }
            else
            {
                NovoAviso.Codigo = ((Avisos)Session["AvisoCadastrado"]).Codigo;
                Valido = new NegAvisos().AtualizarAviso(NovoAviso, ((Usuarios)Session["Usuario"]).Codigo, ref Mensagem);

                if (Valido)
                    AtualizarRepeticao((Avisos)Session["AvisoCadastrado"], NovoAviso);
            }

            if (Valido)
                Session["AvisoCadastrado"] = null;
            else
                Session["NaoValido"] = true;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Cadastros/ConsultaAviso.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }
        
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["AvisoCadastrado"] = null;
            Session["ListaUsuarioTipo"] = null;
            Response.Redirect("~/Cadastros/ConsultaAviso.aspx");
        }

        protected void gvPerfisAdd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remover")
            {
                string icon = "../img/icon-ok.png";
                string TelaRetorno = "";
                string Mensagem = "";

                List<AvisosVisao> visao = (List<AvisosVisao>)Session["VisaoAviso"];
                int Index = visao.FindIndex(delegate(AvisosVisao av) { return av.CodigoTipoUsuario == Convert.ToInt32(e.CommandArgument); });

                if (Index >= 0)
                {
                    visao.RemoveAt(Index);

                    Session["VisaoAviso"] = visao;

                    CarregarGridVisao();
                    AtualizarDropDownPerfil();

                    icon = "../img/icon-ok.png";
                    Mensagem = "Perfil de usuário removido com sucesso.";
                }
                else
                {
                    icon = "../img/icon-error.png";
                    Mensagem = "Não foi possivel remover o perfil do usuário.";
                }

                ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
            }
        }

        protected void gvAnexos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string icon = "../img/icon-ok.png";
            string TelaRetorno = "";
            string Mensagem = "";

            List<AvisosArquivos> arqui = null;

            if (e.CommandName == "Remover")
            {
                arqui = (List<AvisosArquivos>)Session["ArquivosAviso"];
                int Index = arqui.FindIndex(delegate(AvisosArquivos ar) { return ar.Codigo == Convert.ToInt32(e.CommandArgument); });

                if (Index >= 0)
                {
                    arqui.RemoveAt(Index);

                    Session["ArquivosAviso"] = arqui;

                    CarregarGridArquivo();

                    icon = "../img/icon-ok.png";
                    Mensagem = "Arquivo removido com sucesso.";
                }
                else
                {
                    icon = "../img/icon-error.png";
                    Mensagem = "Não foi possivel remover o arquivo.";
                }

                ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
            }
            else if (e.CommandName == "Download")
            {
                arqui = (List<AvisosArquivos>)Session["ArquivosAviso"];
                AvisosArquivos arq = arqui.Find(delegate(AvisosArquivos a) { return a.Codigo == Convert.ToInt32(e.CommandArgument); });

                Session["ArquivoDownload"] = arq.Arquivo;
                
                Response.Redirect("~/DownloadArquivo.ashx?Descricao=" + arq.Descricao + "&Extensao=" + arq.Extensao);
            }
        }

        #endregion

        #region "Métodos"

        private void AtualizarRepeticao(Avisos Avisos, Avisos NovoAviso)
        {
            Avisos.Titulo = NovoAviso.Titulo;
            Avisos.Descricao = NovoAviso.Descricao;

            Avisos.Visao = NovoAviso.Visao;
            Avisos.Arquivos = NovoAviso.Arquivos;
        }

        private void PreencherObjeto(ref Avisos NovoAviso)
        {
            NovoAviso.CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            NovoAviso.Titulo = txtTitulo.Text;
            NovoAviso.Descricao = txtDescricao.Text;

            NovoAviso.Visao = (List<AvisosVisao>)Session["VisaoAviso"];
            NovoAviso.Arquivos = (List<AvisosArquivos>)Session["ArquivosAviso"];
        }

        private void CarregarGridArquivo()
        {
            if (Session["ArquivosAviso"] != null)
            {
                gvAnexos.DataSource = (List<AvisosArquivos>)Session["ArquivosAviso"];
                gvAnexos.DataBind();
            }
        }

        private void CarregarGridVisao()
        {
            if (Session["VisaoAviso"] != null)
            {
                gvPerfisAdd.DataSource = (List<AvisosVisao>)Session["VisaoAviso"];
                gvPerfisAdd.DataBind();
            }
        }

        private void CarregarUsuarioTipo()
        {
            dpAssociarPerfil.DataTextField = "Nome";
            dpAssociarPerfil.DataValueField = "Codigo";
            dpAssociarPerfil.DataSource = (List<UsuarioTipo>)Session["ListaUsuarioTipo"]; ;
            dpAssociarPerfil.DataBind();
        }

        private void PreencherEdits(Avisos NovoAvisos)
        {
            txtTitulo.Text = NovoAvisos.Titulo;
            txtDescricao.Text = NovoAvisos.Descricao;

            if (NovoAvisos.Visao != null)
            {
                Session["VisaoAviso"] = NovoAvisos.Visao;
                CarregarGridVisao();
            }

            if (NovoAvisos.Arquivos != null)
            {
                Session["ArquivosAviso"] = NovoAvisos.Arquivos;
                CarregarGridArquivo();
            }
        }

        private void AtualizarSessaoListaTipoUsuario()
        {
            int CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            List<UsuarioTipo> lista = new NegUsuario().ListarUsuarioTipo();
            Session["ListaUsuarioTipo"] = lista;
        }

        private void AtualizarDropDownPerfil()
        {
            AtualizarSessaoListaTipoUsuario();

            if (Session["VisaoAviso"] != null && ((List<AvisosVisao>)Session["VisaoAviso"]).Count != 0)
            {
                List<AvisosVisao> Visao = (List<AvisosVisao>)Session["VisaoAviso"];
                List<UsuarioTipo> Tipo = (List<UsuarioTipo>)Session["ListaUsuarioTipo"];

                for (int i = 0; i < Visao.Count; i++)
                {
                    int Index = Tipo.FindIndex(delegate(UsuarioTipo t) { return t.Codigo == Visao[i].CodigoTipoUsuario; });

                    if (Index != -1)
                        Tipo.RemoveAt(Index);
                }

                Session["ListaUsuarioTipo"] = Tipo;
            }

            CarregarUsuarioTipo();
        }

        #endregion

    }
}