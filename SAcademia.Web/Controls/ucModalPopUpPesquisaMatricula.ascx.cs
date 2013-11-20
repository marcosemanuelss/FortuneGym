using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SAcademia.Web.Controls
{
    public partial class ucModalPopUpPesquisaMatricula : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DivPopup.Visible = false;
        }

        public void Call(String telaRetorno, String telaOrigem)
        {
            DivPopup.Visible = true;
            Session["TelaRetorno"] = telaRetorno;
            Session["TelaOrigem"] = telaOrigem;

            ModalPopupExtenderPopup.Show();
        }

        protected void btnCancelarPopup_Click(object sender, EventArgs e)
        {
            ModalPopupExtenderPopup.Hide();
        }
    }
}