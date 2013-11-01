using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Perfil;
using System.Data.Common;
using Persistencia.Base;
using System.Data;

namespace Persistencia.Perfil
{
    public class PerPaginas
    {
        public List<Paginas> ListarPaginas(int CodigoTipo)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_TIPO", CodigoTipo));

            return Base.Db.ReadList<Paginas>("SP_LISTAR_PAGINAS_USUARIO", GenericMake.Make<Paginas>, CommandType.StoredProcedure, p);
        }
    }
}
