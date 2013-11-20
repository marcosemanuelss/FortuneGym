using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAcademia.Web
{
    public partial class ucAjaxModalPopup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack)
            iconeMensagem.Attributes.Add("onLoad", "btnConfirmarFocus();");
            this.Visible = false;
        }

        protected void btnConfirmarPopup_Click(object sender, EventArgs e)
        {
            if (Session["TelaRetorno"] != null)
            {
                String Tela = Session["TelaRetorno"].ToString();
                Session["TelaRetorno"] = null;
                DivPopup.Visible = false;
                Response.Redirect(Tela);
            }
        }

        public void Call(String mensagem, String telaRetorno, String Tipo)
        {
            this.Visible = true;
            DivPopup.Visible = true;
            lblMensagemPopup.Text = mensagem;

            switch (Tipo)
            {
                case "Error":
                    iconeMensagem.Src = "../img/icon-erro.png";
                    break;
                case "OK":
                    iconeMensagem.Src = "../img/icon-ok.png";
                    break;
                case "Question":
                    iconeMensagem.Src = "../img/icon-question.png";
                    break;
                case "Attention":
                    iconeMensagem.Src = "../img/icon-atencao.png";
                    break;
                default:
                    iconeMensagem.Src = "../img/icon-ok.png";
                    break;
            }

            Session["TelaRetorno"] = telaRetorno;
            ModalPopupExtenderPopup.Show();
        }

    }
}