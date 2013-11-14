using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Fichas;
using Negocio.Fichas;
using Entidade.Usuarios;

namespace SAcademia.Web.Cadastros
{
    public partial class CadastraTipoSerie : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["SerieTipoCadastrada"] != null)
                {
                    PreencherEdits((SerieTipo)Session["SerieTipoCadastrada"]);
                    if (Session["NaoValido"] != null && ((bool)Session["NaoValido"]))
                        Session["SerieTipoCadastrada"] = null;

                    Session["NaoValido"] = null;
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Mensagem = "";
            bool Valido = false;
            SerieTipo NovoTipo = new SerieTipo();
            PreencherObjeto(ref NovoTipo);

            if (Session["SerieTipoCadastrada"] == null)
            {
                Session["SerieTipoCadastrada"] = NovoTipo;
                Valido = new NegSerieTipo().InserirTipo(NovoTipo, ref Mensagem);
            }
            else
            {
                NovoTipo.Codigo = ((SerieTipo)Session["SerieTipoCadastrada"]).Codigo;
                Valido = new NegSerieTipo().AtualizarTipo(NovoTipo, ref Mensagem);

                if (Valido)
                    AtualizarCategoria(NovoTipo);
            }

            if (Valido)
                Session["SerieTipoCadastrada"] = null;
            else
                Session["NaoValido"] = true;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Cadastros/ConsultaTipoSerie.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

            Session["SerieTipoCadastrada"] = null;
            Response.Redirect("~/Cadastros/ConsultaTipoSerie.aspx");
        }

        #endregion

        #region "Métodos"

        private void PreencherEdits(SerieTipo SerieTipo)
        {
            txtNome.Text = SerieTipo.Nome;
        }

        private void PreencherObjeto(ref SerieTipo NovoTipo)
        {
            NovoTipo.CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            NovoTipo.Nome = txtNome.Text;
            NovoTipo.Ativo = true;
        }

        private void AtualizarCategoria(SerieTipo NovoTipo)
        {
            List<SerieTipo> lista = (List<SerieTipo>)Session["ListaSeriesTipo"];
            int IndexLista = lista.FindIndex(delegate(SerieTipo u) { return u.Codigo == NovoTipo.Codigo; });

            if (IndexLista >= 0)
                lista[IndexLista] = NovoTipo;
        }

        #endregion
    }
}