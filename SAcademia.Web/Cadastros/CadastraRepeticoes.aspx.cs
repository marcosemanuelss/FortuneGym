using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Repeticoes;
using Negocio.Repeticoes;

namespace SAcademia.Web.Cadastros
{
    public partial class CadastraRepeticoes : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RepeticaoCadastrada"] != null)
            {
                PreencherEdits((TipoRepeticao)Session["RepeticaoCadastrada"]);
                if (Session["NaoValido"] != null && ((bool)Session["NaoValido"]))
                    Session["RepeticaoCadastrada"] = null;

                Session["NaoValido"] = null;
            }
        }
        
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string Mensagem = "";
            bool Valido = false;
            TipoRepeticao NovaRepeticao = new TipoRepeticao();
            PreencherObjeto(ref NovaRepeticao);

            if (Session["RepeticaoCadastrada"] == null)
            {
                Session["RepeticaoCadastrada"] = NovaRepeticao;
                Valido = new NegRepeticao().InserirRepeticao(NovaRepeticao, ref Mensagem);
            }
            else
            {
                NovaRepeticao.Codigo = ((TipoRepeticao)Session["RepeticaoCadastrada"]).Codigo;
                Valido = new NegRepeticao().AtualizarRepeticao(NovaRepeticao, ref Mensagem);

                if (Valido)
                    AtualizarRepeticao((TipoRepeticao)Session["RepeticaoCadastrada"], NovaRepeticao);
            }

            if (Valido)
                Session["RepeticaoCadastrada"] = null;
            else
                Session["NaoValido"] = true;

            string icon = Valido ? "../img/icon-ok.png" : "../img/icon-erro.png";
            string TelaRetorno = Valido ? "../Cadastros/ConsultaRepeticoes.aspx" : "";
            ((Site)Master).ExecutaResposta(Mensagem, icon, TelaRetorno);
        }
                
        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Session["RepeticaoCadastrada"] = null;
            Response.Redirect("~/Cadastros/ConsultaRepeticoes.aspx");
        }

        #endregion

        #region "Métodos"

        private void PreencherEdits(TipoRepeticao tipoRepeticao)
        {
            throw new NotImplementedException();
        }

        private void PreencherObjeto(ref TipoRepeticao NovaRepeticao)
        {
            throw new NotImplementedException();
        }

        private void AtualizarRepeticao(TipoRepeticao tipoRepeticao, TipoRepeticao NovaRepeticao)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}