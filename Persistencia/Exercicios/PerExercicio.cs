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
    }
}
