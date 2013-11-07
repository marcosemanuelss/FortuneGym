using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Exercicios;
using Persistencia.Exercicios;

namespace Negocio.Exercicios
{
    public class NegExercicio
    {
        public List<Exercicio> ListarExercicios(int CodigoAcademia, string Filtro)
        {
            return new PerExercicio().ListarExercicios(CodigoAcademia, Filtro);
        }
    }
}
