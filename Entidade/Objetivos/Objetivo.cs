using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Objetivos
{
    [Serializable]
    public class Objetivo
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_USUARIO")]
        public int CodigoUsuario { get; set; }

        [Coluna("ID_OBJETIVO")]
        public int Codigo { get; set; }

        [Coluna("ID_OBJETIVO_TIPO")]
        public int CodigoTipo { get; set; }

        [Coluna("DS_NOME")]
        public string Descricao { get; set; }

        [Coluna("DT_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Coluna("ID_USUARIO_CADASTRO")]
        public int CodigoUsuarioCadastro { get; set; }

        [Coluna("DT_ATUALIZACAO")]
        public DateTime DataAtualizacao { get; set; }

        [Coluna("ID_USUARIO_ATUALIZACAO")]
        public int CodigoUsuarioAtualizacao { get; set; }

        [Coluna("IN_ATIVO")]
        public bool Ativo { get; set; }
    }
}
