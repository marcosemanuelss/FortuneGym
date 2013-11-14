using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Avisos
{
    [Serializable]
    public class Avisos
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_AVISO")]
        public int Codigo { get; set; }

        [Coluna("DT_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Coluna("ID_USUARIO_CADASTRO")]
        public int CodigoUsuarioCadastro { get; set; }

        [Coluna("DS_NOME")]
        public string NomeUsuarioCadastro { get; set; }

        [Coluna("DS_TITULO")]
        public string Titulo { get; set; }

        [Coluna("DS_DESCRICAO")]
        public string Descricao { get; set; }

        [Coluna("IN_ATIVO")]
        public bool Ativo { get; set; }

        public List<AvisosArquivos> Arquivos { get; set; }

        public List<AvisosVisao> Visao { get; set; }
    }
}
