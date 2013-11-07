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
    }
}
