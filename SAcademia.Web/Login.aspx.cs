﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio.Usuarios;
using Entidade.Usuarios;

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
            Session["Usuario"] = usuario;
        }
    }
}