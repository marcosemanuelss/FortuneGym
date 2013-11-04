using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Entidade.Objetivos;
using System.Data;
using Persistencia.Base;

namespace Persistencia.Objetivos
{
    public class PerObjetivo
    {
        public List<Objetivo> ListarObjetivos(int CodigoAcademia, int CodigoUsuario)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));

            return Base.Db.ReadList<Objetivo>("SP_LISTAR_OBJETIVOS", GenericMake.Make<Objetivo>, CommandType.StoredProcedure, p);
        }
    }
}
