using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace SAcademia.Web.Administrativo
{
    public partial class ConsultaAcademia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGV();
        }

        protected void CarregaGV()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("CNPJ", System.Type.GetType("System.String"));
            dt.Columns.Add("Nome", System.Type.GetType("System.String"));
            dt.Columns.Add("Parâmetros", System.Type.GetType("System.String"));
            dt.Columns.Add("Situação", System.Type.GetType("System.String"));
            dt.Columns.Add("Ação", System.Type.GetType("System.String"));
            dt.Columns.Add("Editar", System.Type.GetType("System.String"));
            dt.Columns.Add("Excluir", System.Type.GetType("System.String"));

            for (int i = 1; i < 10; i++)
            {
                dt.Rows.Add(new String[] { "99999999999999", "Dom Bosco", "img", "Inativo", "img", "img", "img" });
            }

            gvConsulta.DataSource = dt;
            gvConsulta.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrativo/CadastraAcademia.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }
    }
}