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
    public class PerSerie
    {
        public List<Series> ListarSeries(int CodigoAcademia, int CodigoUsuario, int CodigoFicha)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));
            p.Add(Base.Db.CreateParameter("@ID_FICHA", CodigoFicha));

            return Base.Db.ReadList<Series>("SP_LISTAR_SERIES", GenericMake.Make<Series>, CommandType.StoredProcedure, p);
        }
    }
}
