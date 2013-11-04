using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Fichas;
using Persistencia.Fichas;
using Persistencia.Exercicios;
using Negocio.Repeticoes;

namespace Negocio.Fichas
{
    public class NegSerie
    {
        public List<Series> ListarSeries(int CodigoAcademia, int CodigoUsuario, int CodigoFicha)
        {
            List<Series> serie = new PerSerie().ListarSeries(CodigoAcademia, CodigoUsuario, CodigoFicha);
            for (int i = 0; i < serie.Count; i++)
            {
                serie[i].Exercicio = new PerExercicio().ObterExercicio(CodigoAcademia, serie[i].CodigoExercicio);
                serie[i].TipoRepeticao = new NegRepeticao().ObterTipoRepeticao(CodigoAcademia, serie[i].CodigoTipoRepeticao);
            }
            return serie;
        }
    }
}
