using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Repeticoes;
using System.Data.Common;
using Persistencia.Base;
using System.Data;

namespace Persistencia.Repeticoes
{
    public class PerRepeticao
    {
        public TipoRepeticao ObterTipoRepeticao(int CodigoAcademia, int CodigoTipoRepeticao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_TIPO_REPETICAO", CodigoTipoRepeticao));

            return Base.Db.Read<TipoRepeticao>("SP_OBTER_TIPO_REPETICAO", GenericMake.Make<TipoRepeticao>, CommandType.StoredProcedure, p);
        }

        public List<Repeticao> ListarRepeticao(int CodigoAcademia, int CodigoTipoRepeticao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_TIPO_REPETICAO", CodigoTipoRepeticao));

            return Base.Db.ReadList<Repeticao>("SP_LISTAR_REPETICAO", GenericMake.Make<Repeticao>, CommandType.StoredProcedure, p);
        }

        public static List<TipoRepeticao> ListarTipoRepeticao(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<TipoRepeticao>("SP_LISTAR_TIPO_REPETICAO", GenericMake.Make<TipoRepeticao>, CommandType.StoredProcedure, p);
        }
    }
}
