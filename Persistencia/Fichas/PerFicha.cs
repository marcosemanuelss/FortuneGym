using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Fichas;
using System.Data.Common;
using Persistencia.Base;
using System.Data;

namespace Persistencia.Fichas
{
    public class PerFicha
    {
        public Ficha ObterFicha(int CodigoAcademia, int CodigoUsuario)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));

            return Base.Db.Read<Ficha>("SP_OBTER_FICHA", GenericMake.Make<Ficha>, CommandType.StoredProcedure, p);
        }
    }
}
