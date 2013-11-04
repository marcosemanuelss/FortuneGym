using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Fichas
{
    [Serializable]
    public class Series
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_SERIE_TIPO")]
        public int CodigoTipoSerie { get; set; }

        [Coluna("ID_USUARIO")]
        public int CodigoUsuario { get; set; }

        [Coluna("ID_FICHA")]
        public int CodigoFicha { get; set; }

        [Coluna("ID_EXERCICIO")]
        public int CodigoExercicio { get; set; }

        [Coluna("ID_TIPO_REPETICAO")]
        public int CodigoTipoRepeticao { get; set; }

        [Coluna("DT_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Coluna("ID_USUARIO_CADASTRO")]
        public int CodigoUsuarioCadastro { get; set; }

        [Coluna("DT_ATUALIZACAO")]
        public DateTime DataAtualizacao { get; set; }

        [Coluna("ID_USUARIO_ALT")]
        public int CodigoUsuarioAlteracao { get; set; }

        [Coluna("IN_ATIVO")]
        public bool Ativo { get; set; }

        public Exercicios.Exercicio Exercicio { get; set; }
        public Repeticoes.TipoRepeticao TipoRepeticao { get; set; }
    }
}
