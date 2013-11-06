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
    public partial class Parametros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ParametrosAcademia"] != null)
                {
                    CarregaCampos((AcademiaParametros)Session["ParametrosAcademia"]);
                    Session["ParametrosAcademia"] = null;
                }        
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaAcademia.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Salvar()
        {
            int retorno = 0;
            AcademiaParametros academiaParametros = new AcademiaParametros();
            academiaParametros.Avaliacao = Convert.ToBoolean(rblistAvaliacao.SelectedValue);
            academiaParametros.PrazoAvaliacao = txtTempoAvaliacao.Text == "" ? null : (int?)Convert.ToInt32(txtTempoAvaliacao.Text);
            academiaParametros.PrazoFicha = Convert.ToInt32(txtTempoFicha.Text);
            academiaParametros.Cor = hddCorMenu.Value == "" ? "#303030" : hddCorMenu.Value;
            academiaParametros.CodigoAcademia = Convert.ToInt32(hddCodigoAcademia.Value);

            retorno = new NegAcademia().SalvarParametros(academiaParametros);
            if (retorno > 0)
            {
                ((Site)Master).ExecutaResposta("Parâmetros salvos com sucesso!" , "../img/icon-ok.png", "../Administrativo/ConsultaAcademia.aspx");
            }
            else
            {
                ((Site)Master).ExecutaResposta("Erro ao salvar parâmetros. Cadastro cancelado.", "../img/icon-erro.png", "");
            }
        }

        private void CarregaCampos(AcademiaParametros academiaParametros)
        {
            hddCodigoAcademia.Value = academiaParametros.CodigoAcademia.ToString();
            rblistAvaliacao.SelectedValue = academiaParametros.Avaliacao.ToString();
            txtTempoAvaliacao.Text = academiaParametros.PrazoAvaliacao.ToString();
            txtTempoFicha.Text = academiaParametros.PrazoFicha.ToString();
            hddCorMenu.Value = academiaParametros.Cor == null ? "#303030" : academiaParametros.Cor;
        }
    }
}