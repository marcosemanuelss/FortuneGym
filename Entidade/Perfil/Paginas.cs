using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Perfil
{
    [Serializable]
    public class Paginas
    {
        [Coluna("ID_PAGINA")]
        public int Codigo { get; set; }

        [Coluna("DS_NOME")]
        public string Nome { get; set; }

        [Coluna("DS_URL")]
        public string Url { get; set; }
    }
}
