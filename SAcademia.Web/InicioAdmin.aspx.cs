﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SAcademia.Web
{
    public partial class InicioAdmin : System.Web.UI.Page
    {
        #region "Eventos"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGV();   
            }
        }

        protected void CarregaGV()
        {

        }

        #endregion
    }
}