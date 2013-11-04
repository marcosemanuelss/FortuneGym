using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Usuarios;
using Entidade.Usuarios;
using Entidade.Academias;
using Negocio.Academias;

namespace SAcademia.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new NegUsuario().Logar(txtLogin.Text, txtSenha.Text);

            if (usuario != null)
            {
                Academia academia = new NegAcademia().Obter(usuario.CodigoAcademia);

                Session["Academia"] = academia;
                Session["Usuario"] = usuario;

                Response.Redirect("~/Inicio.aspx");
            }
            else
            {
                //solicitar senha novamente
            }

            
        }
    }
}