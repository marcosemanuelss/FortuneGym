using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidade.Academias;
using Entidade.Usuarios;
using Negocio.Usuarios;
namespace SAcademia.Web.Administrativo
{
    public partial class ConsultaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListaClientes"] != null)
                {
                    gvConsulta.DataSource = (List<ClientesGrid>)Session["ListaClientes"];
                    gvConsulta.DataBind();
                }
            }
        }
        protected void CarregaGV()
        {
            int CodigoAcademia = ((Academia)Session["Academia"]).Codigo;
            List<ClientesGrid> lista = new NegCliente().ListarClientes(CodigoAcademia, txtPesquisa.Text);
            Session["ListaClientes"] = lista;
            gvConsulta.DataSource = lista;
            gvConsulta.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administrativo/CadastraCliente.aspx");
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inicio.aspx");
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            CarregaGV();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            txtPesquisa.Text = String.Empty;
            CarregaGV();
        }
        
    }
}