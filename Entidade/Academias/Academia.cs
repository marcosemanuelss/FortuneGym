using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Academias
{
    [Serializable]
    public class Academia
    {
        [Coluna("ID_ACADEMIA")]
        public int Codigo { get; set; }

        [Coluna("NR_CNPJ")]
        public string CNPJ { get; set; }

        [Coluna("DS_NOME")]
        public string Nome { get; set; }

        [Coluna("IM_LOGO")]
        public byte[] Logotipo { get; set; }

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

        [Coluna("DS_EMAIL")]
        public string Email { get; set; }

        [Coluna("IN_ATIVO")]
        public bool Ativo { get; set; }

        [Coluna("DT_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Coluna("DT_ATUALIZACAO")]
        public DateTime DataAtualizacao { get; set; }

        public AcademiaParametros Parametros { get; set; }
    }
}
