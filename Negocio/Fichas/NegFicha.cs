using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Fichas;
using Persistencia.Fichas;

namespace Negocio.Fichas
{
    public class NegFicha
    {
        public Ficha ObterFicha(int CodigoAcademia, int CodigoUsuario)
        {
            Ficha ficha = new PerFicha().ObterFicha(CodigoAcademia, CodigoUsuario);

            if (ficha != null)
                ficha.Series = new NegSerie().ListarSeries(CodigoAcademia, CodigoUsuario, ficha.Codigo);

            return ficha;
        }
    }
}
