using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAcademia.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Entrar_Click(object sender, EventArgs e)
        {
            if (ValidaEntrada())
            {
                
            }
        }

        private Boolean ValidaEntrada()
        {
            
            //if (txtLogin.Text.Equals(string.Empty))
            //{
            //    mensagemLabel.Text = "Insira um login válido";
            //    txtLogin.Focus();
            //    return false;
            //}

            //if (txtSenha.Text.Equals(string.Empty))
            //{
            //    mensagemLabel.Text = "Insira uma senha válida";
            //    txtSenha.Focus();
            //    return false;
            //}

            return true;
        }
    }
}