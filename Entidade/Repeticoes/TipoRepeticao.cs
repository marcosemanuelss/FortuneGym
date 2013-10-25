using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.Repeticoes
{
    public class TipoRepeticao
    {
        public int CodigoAcademia { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public List<Repeticao> Repeticoes { get; set; }
    }
}
