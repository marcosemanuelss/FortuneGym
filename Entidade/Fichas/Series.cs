using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.Fichas
{
    public class Series
    {
        public int CodigoAcademia { get; set; }
        public int CodigoTipoSerie { get; set; }
        public int CodigoTipoRepeticao { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoFicha { get; set; }
        public int CodigoExercicio { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CodigoUsuarioCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int CodigoUsuarioAlteracao { get; set; }
        public bool Ativo { get; set; }

        public Exercicios.Exercicio Exercicio { get; set; }
        public Repeticoes.TipoRepeticao TipoRepeticao { get; set; }
    }
}
