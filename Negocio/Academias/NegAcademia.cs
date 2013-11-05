using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Academias;
using Persistencia.Academias;

namespace Negocio.Academias
{
    public class NegAcademia
    {
        public Academia Obter(int CodigoAcademia)
        {
            PerAcademia perAcademia = new PerAcademia();
            Academia academia = perAcademia.Obter(CodigoAcademia);

            if (academia != null)
                academia.Parametros = perAcademia.ObterParametros(CodigoAcademia);

            return academia;
        }

        public List<Academia> ListarAcademias(string Pesquisa)
        {
            return new PerAcademia().ListarAcademias(Pesquisa);
        }

        public AcademiaParametros ObterParametros(int CodigoAcademia)
        {
            return new PerAcademia().ObterParametros(CodigoAcademia);
        }

        public int SalvarParametros(AcademiaParametros academiaParametros)
        {
            return new PerAcademia().SalvarParametros(academiaParametros);
        }
    }
}
