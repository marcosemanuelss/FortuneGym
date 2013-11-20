using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Fichas;
using Entidade.Academias;

namespace SAcademia.Web.Cadastros
{
    public partial class CadastroFicha : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PreencherSeries();
            }
        }

        #endregion

        #region "Métodos"

        private void PreencherSeries()
        {
            dpSerie.DataValueField = "Codigo";
            dpSerie.DataTextField = "Nome";

            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            dpSerie.DataSource = new NegSerieTipo().ListarTipos(CodigoAcademia, "");
            dpSerie.DataBind();
        }

        #endregion

        protected void btnProcurarMatricula_Click(object sender, EventArgs e)
        {
            ucModalPopupPesquisaMatricula1.Call("~/Default.aspx", "~/Default.aspx");
        }
    }
}