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
    public class PerSerieTipo
    {
        public List<SerieTipo> ListarTipos(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<SerieTipo>("SP_LISTAR_SERIE_TIPO", GenericMake.Make<SerieTipo>, CommandType.StoredProcedure, p);
        }
    }
}
