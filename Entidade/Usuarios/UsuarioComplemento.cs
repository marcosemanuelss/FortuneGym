using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade.Usuarios
{
    public class UsuarioComplemento
    {
        public string Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public Fichas.Ficha Ficha { get; set; }
        public List<Objetivos.Objetivo> Objetivo { get; set; }
    }
}
