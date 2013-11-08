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

        public int InserirTipo(SerieTipo NovaSerieTipo)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovaSerieTipo.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovaSerieTipo.Nome));

            return Base.Db.Insert("SP_INSERIR_SERIE_TIPO", CommandType.StoredProcedure, p);
        }

        public int AtualizarTipo(SerieTipo NovaSerieTipo)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovaSerieTipo.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_SERIE_TIPO", NovaSerieTipo.Codigo));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovaSerieTipo.Nome));

            return Base.Db.Insert("SP_ATUALIZAR_SERIE_TIPO", CommandType.StoredProcedure, p);
        }

        public int DesabilitarTipo(int CodigoAcademia, int CodigoTipo)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_SERIE_TIPO", CodigoTipo));

            return (int)Base.Db.GetScalar("SP_BLOQUEAR_SERIE_TIPO", CommandType.StoredProcedure, p);
        }

        public int VincularTipoCategoria(SerieTipo Tipo, List<Entidade.Exercicios.ExercicioCategoria> Categorias)
        {
            throw new NotImplementedException();
        }
    }
}
