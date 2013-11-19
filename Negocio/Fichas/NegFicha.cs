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

        public List<Ficha> ListarFicha(int CodigoAcademia, string Filtro)
        {
            List<Ficha> lista = new PerFicha().ListarFicha(CodigoAcademia, Filtro);

            for (int i = 0; i < lista.Count; i++)
                lista[i].Series = new NegSerie().ListarSeries(CodigoAcademia, lista[i].CodigoUsuario, lista[i].Codigo);

            return lista;
        }
    }
}
