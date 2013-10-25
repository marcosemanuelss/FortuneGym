using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.Fichas
{
    public class Ficha
    {
        public int CodigoAcademia { get; set; }
        public int CodigoUsuario { get; set; }
        public int Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CodigoUsuarioCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int CodigoUsuarioAtualizacao { get; set; }
        public bool Ativo { get; set; }

        public List<Series> Series { get; set; }
    }
}
