using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Repeticoes;
using Negocio.Repeticoes;
using Entidade.Usuarios;

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

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Repeticao repeticao = new Repeticao();

            repeticao.QtdVezes = Convert.ToInt32(txtNumVezesCombinada.Text);
            repeticao.QtdRepeticao = Convert.ToInt32(txtRepetCombinada.Text);
            repeticao.Variacao = dpVariacaoCombinada.SelectedValue;

            List<Repeticao> lista = (List<Repeticao>)Session["RepeticaoComposta"];
            if (lista == null)
            {
                lista = new List<Repeticao>();
            }

            lista.Add(repeticao);

            Session["RepeticaoComposta"] = lista;
            CarregarGridComposta();
        }

        #endregion

        #region "Métodos"

        private void PreencherEdits(TipoRepeticao TipoRepeticao)
        {
            txtNome.Text = TipoRepeticao.Nome;
            rbtipoCombinacao.SelectedValue = TipoRepeticao.Tipo;

            if (TipoRepeticao.Tipo == "S")
            {
                txtNumVezesSimples.Text = TipoRepeticao.Repeticoes[0].QtdVezes.ToString();
                txtRepetSimples.Text = TipoRepeticao.Repeticoes[0].QtdRepeticao.ToString();
                dpVariacaoSimples.SelectedValue = TipoRepeticao.Repeticoes[0].Variacao.ToString();
            }
            else
            {
                Session["RepeticaoComposta"] = TipoRepeticao.Repeticoes;
                CarregarGridComposta();
            }
        }

        private void PreencherObjeto(ref TipoRepeticao NovaRepeticao)
        {
            NovaRepeticao.CodigoAcademia = ((Usuarios)Session["Usuario"]).CodigoAcademia;
            NovaRepeticao.Nome = txtNome.Text;
            NovaRepeticao.Tipo = rbtipoCombinacao.SelectedValue;

            if (rbtipoCombinacao.SelectedValue == "S")
            {
                List<Repeticao> Repet = new List<Repeticao>();

                Repeticao repeticao = new Repeticao();
                repeticao.QtdVezes = Convert.ToInt32(txtNumVezesSimples.Text);
                repeticao.QtdRepeticao = Convert.ToInt32(txtRepetSimples.Text);
                repeticao.Variacao = dpVariacaoSimples.SelectedValue;

                Repet.Add(repeticao);
                NovaRepeticao.Repeticoes = Repet;
            }
            else
            {
                NovaRepeticao.Repeticoes = (List<Repeticao>)Session["RepeticaoComposta"];
            }
        }

        private void AtualizarRepeticao(TipoRepeticao TipoRepeticao, TipoRepeticao NovaRepeticao)
        {
            TipoRepeticao.Nome = NovaRepeticao.Nome;
            TipoRepeticao.Tipo = NovaRepeticao.Tipo;

            if (NovaRepeticao.Tipo == "S")
            {
                TipoRepeticao.Repeticoes[0].QtdRepeticao = NovaRepeticao.Repeticoes[0].QtdRepeticao;
                TipoRepeticao.Repeticoes[0].QtdVezes = NovaRepeticao.Repeticoes[0].QtdVezes;
                TipoRepeticao.Repeticoes[0].Variacao = NovaRepeticao.Repeticoes[0].Variacao;
            }
            else
            {
                TipoRepeticao.Repeticoes = NovaRepeticao.Repeticoes;
            }
        }

        private void CarregarGridComposta()
        {
            if (Session["RepeticaoComposta"] != null)
            {
                gvCombinada.DataSource = (List<Repeticao>)Session["RepeticaoComposta"];
                gvCombinada.DataBind();
            }
        }

        #endregion

    }
}