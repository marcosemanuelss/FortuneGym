using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Academias;
using System.Data.Common;
using Persistencia.Base;
using System.Data;

namespace Persistencia.Academias
{
    public class PerAcademia
    {
        public Academia Obter(int CodigoAcademia)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));

            return Base.Db.Read<Academia>("SP_OBTER_ACADEMIA", GenericMake.Make<Academia>, CommandType.StoredProcedure, p);
        }

        public AcademiaParametros ObterParametros(int CodigoAcademia)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));

            return Base.Db.Read<AcademiaParametros>("SP_OBTER_ACADEMIA_PARAMETROS", GenericMake.Make<AcademiaParametros>, CommandType.StoredProcedure, p);
        }
    }
}
