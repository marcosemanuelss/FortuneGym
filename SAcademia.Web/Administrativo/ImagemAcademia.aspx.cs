using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SFF.Web.Administrativo
{
    public partial class ImagemAcademia : System.Web.UI.Page
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
            if (Session["Logotipo"] != null)
            {
                //Orgao orgao = (Orgao)
                byte[] imagem;
                imagem = (byte[])Session["Logotipo"];
                Response.ContentType = imagem.ToString();
                Response.BinaryWrite(imagem);
            }
        }

        #endregion
    }
}