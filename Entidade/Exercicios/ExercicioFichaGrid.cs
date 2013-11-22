using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Exercicios
{
    [Serializable]
    public class ExercicioFichaGrid : ExercicioGrid
    {
        [Coluna("ID_SERIE_TIPO")]
        public int CodigoTipoSerie { get; set; }
    }
}
