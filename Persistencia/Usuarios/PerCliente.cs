using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Usuarios;
using System.Data.Common;
using Persistencia.Base;
using System.Data;

namespace Persistencia.Usuarios
{
    public class PerCliente
    {
        public List<ClientesGrid> ListarClientes(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<ClientesGrid>("SP_LISTAR_CLIENTES", GenericMake.Make<ClientesGrid>, CommandType.StoredProcedure, p);
        }
    }
}
