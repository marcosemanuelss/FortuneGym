using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Exercicios;
using Persistencia.Exercicios;

namespace Negocio.Exercicios
{
    public class NegCategoria
    {
        public List<ExercicioCategoria> ListarCategorias(int CodigoAcademia, string Filtro)
        {
            return new PerCategoria().ListarCategorias(CodigoAcademia, Filtro);
        }
    }
}
