using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Exercicios;
using System.Data.Common;
using Persistencia.Base;
using System.Data;

namespace Persistencia.Exercicios
{
    public class PerCategoria
    {
        public List<ExercicioCategoria> ListarCategorias(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<ExercicioCategoria>("SP_LISTAR_EXERCICIO_CATEGORIA", GenericMake.Make<ExercicioCategoria>, CommandType.StoredProcedure, p);
        }

        public int DesabilitarCategoria(int CodigoAcademia, int CodigoCategoria)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_EXERCICIO_CATEGORIA", CodigoCategoria));

            return (int)Base.Db.GetScalar("SP_BLOQUEAR_EXERCICIO_CATEGORIA", CommandType.StoredProcedure, p);
        }

        public int InserirCategoria(ExercicioCategoria NovaCategoria)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovaCategoria.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_CATEGORIA", NovaCategoria.Descricao));

            return Base.Db.Insert("SP_INSERIR_EXERCICIO_CATEGORIA", CommandType.StoredProcedure, p);
        }

        public int AtualizarCategoria(ExercicioCategoria NovaCategoria)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovaCategoria.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_EXERCICIO_CATEGORIA", NovaCategoria.Codigo));
            p.Add(Base.Db.CreateParameter("@DS_CATEGORIA", NovaCategoria.Descricao));

            return (int)Base.Db.GetScalar("SP_ATUALIZAR_EXERCICIO_CATEGORIA", CommandType.StoredProcedure, p);
        }
    }
}
