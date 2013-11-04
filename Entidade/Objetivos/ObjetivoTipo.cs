using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Objetivos
{
    [Serializable]
    public class ObjetivoTipo
    {
        [Coluna("ID_OBJETIVO_TIPO")]
        public int Codigo { get; set; }

        [Coluna("DS_NOME")]
        public string Nome { get; set; }
    }
}
