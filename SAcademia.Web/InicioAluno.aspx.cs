﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAcademia.Web
{
    public partial class InicioAluno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ((LinkButton)Master.FindControl("lnkInicio")).Visible = false;
                ((LinkButton)Master.FindControl("lnkRelatorios")).Visible = false;
            }
        }
    }
}