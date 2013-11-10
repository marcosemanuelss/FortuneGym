using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SFF.Web
{
    public partial class Logotipo : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RecuperarImagemAcademia();
                //Session["Logotipo"] = null;
            }
        }

        #endregion

        #region "Métodos"

        public void RecuperarImagemAcademia()
        {
            if (Session["Logo"] != null)
            {
                //Orgao orgao = (Orgao)
                byte[] imagem;
                imagem = (byte[])Session["Logo"];
                Response.ContentType = imagem.ToString();
                Response.BinaryWrite(imagem);
            }
        }

        #endregion
    }
}