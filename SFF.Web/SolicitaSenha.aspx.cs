using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAcademia.Web
{
    public partial class SolicitaSenha : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnviarSenha_Click(object sender, EventArgs e)
        {
            if(ValidaEntrada()){
            }
        }

        private Boolean ValidaEntrada()
        {
            

            return true;
        }

    }
}