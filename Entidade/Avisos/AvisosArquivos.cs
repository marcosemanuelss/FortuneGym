using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Avisos
{
    [Serializable]
    public class AvisosArquivos
    {
        [Coluna("ID_ARQUIVO")]
        public int Codigo {get;set;}

        [Coluna("DS_ARQUIVO")]
        public string Descricao {get;set;}

        [Coluna("IM_ARQUIVO")]
        public byte[] Arquivo {get;set;}

        [Coluna("DS_EXTENSAO")]
        public string Extensao {get;set;}
    }
}
