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

        public List<Academia> ListarAcademias(string Pesquisa)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@DS_PESQUISA", Pesquisa));

            return Base.Db.ReadList<Academia>("SP_LISTAR_ACADEMIAS", GenericMake.Make<Academia>, CommandType.StoredProcedure, p);
        }

        public int SalvarParametros(AcademiaParametros academiaParametros)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", academiaParametros.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@IN_AVALIACAO", academiaParametros.Avaliacao));
            p.Add(Base.Db.CreateParameter("@NR_TEMPO_AVALIACAO", academiaParametros.PrazoAvaliacao));
            p.Add(Base.Db.CreateParameter("@NR_TEMPO_FICHA", academiaParametros.PrazoFicha));
            p.Add(Base.Db.CreateParameter("@DS_COR", academiaParametros.Cor));

            return Base.Db.Insert("SP_SALVAR_PARAMETROS_ACADEMIA", CommandType.StoredProcedure, p);
        }
    }
}
