using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Academias
{
    [Serializable]
    public class AcademiaParametros
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("DS_COR")]
        public string Cor { get; set; }

        [Coluna("NR_TEMPO_FICHA")]
        public int PrazoFicha { get; set; }

        [Coluna("IN_AVALIACAO")]
        public bool Avaliacao { get; set; }

        [Coluna("NR_TEMPO_AVALIACAO")]
        public int? PrazoAvaliacao { get; set; }
    }
}
