using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace SFF.Web.Administrativo
{
    public partial class ConsultaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaGV();
        }

        protected void CarregaGV()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Login", System.Type.GetType("System.String"));
            dt.Columns.Add("Nome", System.Type.GetType("System.String"));
            dt.Columns.Add("E-mail", System.Type.GetType("System.String"));
            dt.Columns.Add("Academia", System.Type.GetType("System.String"));
            dt.Columns.Add("Situação", System.Type.GetType("System.String"));
            dt.Columns.Add("Ação", System.Type.GetType("System.String"));
            dt.Columns.Add("Resetar Senha", System.Type.GetType("System.String"));
            dt.Columns.Add("Editar", System.Type.GetType("System.String"));
            dt.Columns.Add("Excluir", System.Type.GetType("System.String"));

            for (int i = 1; i < 10; i++)
            {
                dt.Rows.Add(new String[] {"Nome Teste", "Teste da Silva", "testedasilva@email.com.br", "img", "Inativo", "img", "img", "img", "img" });
            }

            gvConsulta.DataSource = dt;
            gvConsulta.DataBind();
        }
    }
}