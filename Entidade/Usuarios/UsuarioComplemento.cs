using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Usuarios
{
    [Serializable]
    public class UsuarioComplemento
    {
        [Coluna("NR_MATRICULA")]
        public string Matricula { get; set; }

        [Coluna("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Coluna("DS_CEP")]
        public string Cep { get; set; }

        [Coluna("DS_ENDERECO")]
        public string Endereco { get; set; }

        [Coluna("NR_ENDERECO")]
        public int? Numero { get; set; }

        [Coluna("DS_COMPLEMENTO")]
        public string Complemento { get; set; }

        [Coluna("DS_BAIRRO")]
        public string Bairro { get; set; }

        [Coluna("DS_CIDADE")]
        public string Cidade { get; set; }

        [Coluna("SG_UF")]
        public string Uf { get; set; }

        [Coluna("NR_TELEFONE")]
        public string Telefone { get; set; }

        [Coluna("NR_CELULAR")]
        public string Celular { get; set; }

        [Coluna("DS_EMAIL")]
        public string Email { get; set; }

        public Fichas.Ficha Ficha { get; set; }
        public List<Objetivos.Objetivo> Objetivo { get; set; }


    }
}
