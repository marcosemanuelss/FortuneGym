using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Repeticoes
{
    [Serializable]
    public class TipoRepeticao
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_TIPO_REPETICAO")]
        public int Codigo { get; set; }

        [Coluna("DS_NOME")]
        public string Nome { get; set; }

        public List<Repeticao> Repeticoes { get; set; }
    }
}
