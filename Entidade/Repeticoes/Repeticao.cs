using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Repeticoes
{
    [Serializable]
    public class Repeticao
    {
        [Coluna("ID_REPETICAO")]
        public int Codigo { get; set; }

        [Coluna("NR_VEZES")]
        public int QtdVezes { get; set; }

        [Coluna("NR_REPETICAO")]
        public int QtdRepeticao { get; set; }

        [Coluna("IN_MUDANCA")]
        public string Variacao { get; set; }
    }
}
