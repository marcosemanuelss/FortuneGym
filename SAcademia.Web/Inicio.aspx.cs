using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidade.Academias;

namespace SAcademia.Web
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((Academia)Session["Academia"]).Logotipo != null)
                ExibirImagem(((Academia)Session["Academia"]).Logotipo);
        }

        private void ExibirImagem(byte[] imagem)
        {
            Session["Logo"] = imagem;
            imagemAcad.Src = "~/Logotipo.aspx";
            imagemAcad.Width = 300;
            imagemAcad.Height = 250;
            imagemAcad.Attributes.Add("title", ((Academia)Session["Academia"]).Nome);
        }
    }
}