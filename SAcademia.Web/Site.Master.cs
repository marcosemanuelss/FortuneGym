using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Usuarios;
using Entidade.Perfil;

namespace SAcademia.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        #region "Eventos"

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    Usuarios usuario = (Usuarios)Session["Usuario"];

                    if (usuario != null)
                    {
                        lblNomeUser.Text = usuario.Nome;
                        AjustarPerfil(usuario.Paginas);
                        AjustarMenu(usuario.CodigoTipo);
                    }

                    Entidade.Academias.Academia academia = (Entidade.Academias.Academia)Session["Academia"];

                    if (academia != null)
                    {
                        ExibirImagem(academia.Logotipo);
                        hddCor.Value = academia.Parametros.Cor;
                        lblNomeAcademia.Text = academia.Nome;
                    }

                    VerificaUsuarioLogado(usuario, Page.Request.FilePath);
                }

                AlterarCor(hddCor.Value);
            }

            protected void btnDesconectar_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        #endregion

        #region "Métodos"

            private void AjustarMenu(int Tipo)
            {
                switch (Tipo)
                {
                    case 1:
                        lnkInicio.Visible = lnkRelatorios.Visible = false;
                        break;
                    case 2:
                        lnkInicio.PostBackUrl = "~/InicioAdmin.aspx";
                        break;
                    case 3:
                        lnkInicio.PostBackUrl = "~/InicioInstrutor.aspx";
                        lnkRelatorios.Visible = false;
                        break;
                    default:
                        lnkInicio.PostBackUrl = "~/Inicio.aspx";
                        break;
                }
            }

            private void ExibirImagem(byte[] imagem)
        {
            Session["Logo"] = imagem;
            logo.Src = "~/Logotipo.aspx";
            //logo.Width = 300;
            logo.Height = 54;
            logo.Attributes.Add("style", "position: relative; left:100px;");
        }

            private void AjustarPerfil(List<Paginas> lista)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Control c = FindControl(lista[i].Nome);
                if (c != null)
                {
                    if ((c is System.Web.UI.HtmlControls.HtmlGenericControl) &&
                        ((System.Web.UI.HtmlControls.HtmlGenericControl)c).InnerText.ToString().Split('"').Length >= 2 &&
                        ((System.Web.UI.HtmlControls.HtmlGenericControl)c).InnerText.ToString().Split('"')[1] == lista[i].Url)
                    {
                        c.Visible = true;
                        c.Parent.Visible = true;
                    }
                }
            }
        }

            public void ExecutaResposta(string Mensagem, string CaminhoImagem, string PaginaDestino)
        {
            //Define o nome e o tipo de scripts de cliente na página.
            String csname1 = "Script";
            Type cstype = this.GetType();

            //Obtém uma referência ClientScriptManager da classe Page.
            ClientScriptManager cs = Page.ClientScript;

            //Verifique se o script de inicialização já está registrado.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                String cstext1 = "mostraPopUpAlert('" + Mensagem + "', '" + CaminhoImagem + "',false,'', '" + PaginaDestino + "');";
                cs.RegisterStartupScript(cstype, csname1, cstext1, true);
            }
        }

            private void AlterarCor(string Cor)
        {
            String csname1 = "PopupScript";
            Type cstype = this.GetType();

            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                String cstext1 = "alteraCor('" + Cor + "');";
                cs.RegisterStartupScript(cstype, csname1, cstext1, true);
            }
        }

            /// <summary>
            /// Verifica se existe um usuário em sessão. Se existir, verificar se a página informada 
            /// pertence ao perfil do usuário. Se não, redirecionar para a página inicial do perfil.
            /// </summary>
            /// <param name="usuario">Session["Usuario"]</param>
            /// <param name="PaginaAcessada">Pagina a ser acessada</param>
            private void VerificaUsuarioLogado(Usuarios usuario, string PaginaAcessada)
            {
                if (usuario == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                else
                {
                    List<Paginas> lista = usuario.Paginas;
                    Paginas pagina = new Paginas();

                    pagina = lista.Find(delegate(Paginas pag) { return pag.Url == PaginaAcessada; });

                    if (pagina == null)
                    {
                        switch (usuario.CodigoTipo)
                        {
                            case 1:
                                Response.Redirect("~/InicioAluno.aspx");
                                break;
                            case 2:
                                Response.Redirect("~/InicioAdmin.aspx");
                                break;
                            case 3:
                                Response.Redirect("~/InicioInstrutor.aspx");
                                break;
                            default:
                                Response.Redirect("~/Inicio.aspx");
                                break;
                        }
                    }
                }
            }

        #endregion
    }
}
