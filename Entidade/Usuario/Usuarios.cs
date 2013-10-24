using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.Usuario
{
    public class Usuarios
    {
        public int CodigoAcademia { get; set; }
        public int Codigo { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string SenhaSalt { get; set; }
        public int CodigoTipo { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public int CodigoUsuarioAlteracao { get; set; }
        public UsuarioComplemento Complemento { get; set; }
    }
}
