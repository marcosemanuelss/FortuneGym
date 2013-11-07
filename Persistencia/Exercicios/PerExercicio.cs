using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Exercicios;
using System.Data.Common;
using System.Data;
using Persistencia.Base;

namespace Persistencia.Exercicios
{
    public class PerExercicio
    {
        public Exercicio ObterExercicio(int CodigoAcademia, int CodigoExercicio)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoExercicio));

            return Base.Db.Read<Exercicio>("SP_OBTER_EXERCICIO", GenericMake.Make<Exercicio>, CommandType.StoredProcedure, p);
        }

        public List<ExercicioGrid> ListarExercicios(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<ExercicioGrid>("SP_LISTAR_EXERCICIO", GenericMake.Make<ExercicioGrid>, CommandType.StoredProcedure, p);
        }

        public int DesabilitarExercicio(int CodigoAcademia, int CodigoExercicio)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_EXERCICIO", CodigoExercicio));

            return (int)Base.Db.GetScalar("SP_BLOQUEAR_EXERCICIO", CommandType.StoredProcedure, p);
        }

        public int InserirExercicio(Exercicio NovoExercicio)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovoExercicio.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovoExercicio.Nome));
            p.Add(Base.Db.CreateParameter("@ID_EXERCICIO_CAT", NovoExercicio.CodigoCategoria));

            return Base.Db.Insert("SP_INSERIR_EXERCICIO", CommandType.StoredProcedure, p);
        }

        public int AtualizarExercicio(Exercicio NovoExercicio)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovoExercicio.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_EXERCICIO", NovoExercicio.Codigo));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovoExercicio.Nome));
            p.Add(Base.Db.CreateParameter("@ID_EXERCICIO_CAT", NovoExercicio.CodigoCategoria));

            return (int)Base.Db.GetScalar("SP_ATUALIZAR_EXERCICIO", CommandType.StoredProcedure, p);
        }
    }
}
