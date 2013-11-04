using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Fichas
{
    [Serializable]
    public class Ficha
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_USUARIO")]
        public int CodigoUsuario { get; set; }

        [Coluna("ID_FICHA")]
        public int Codigo { get; set; }

        [Coluna("DT_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Coluna("ID_USUARIO_CADASTRO")]
        public int CodigoUsuarioCadastro { get; set; }

        [Coluna("DT_ATUALIZACAO")]
        public DateTime DataAtualizacao { get; set; }

        [Coluna("ID_USUARIO_ALT")]
        public int CodigoUsuarioAtualizacao { get; set; }

        [Coluna("IN_ATIVO")]
        public bool Ativo { get; set; }

        public List<Series> Series { get; set; }
    }
}
