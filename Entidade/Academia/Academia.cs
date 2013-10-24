using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.Academia
{
    public class Academia
    {
        public int Codigo { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public byte[] Logotipo { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
