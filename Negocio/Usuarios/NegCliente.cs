using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Usuarios;
using Persistencia.Usuarios;

namespace Negocio.Usuarios
{
    public class NegCliente
    {
        public List<ClientesGrid> ListarClientes(int CodigoAcademia, string Filtro)
        {
            return new PerCliente().ListarClientes(CodigoAcademia, Filtro);
        }
    }
}
