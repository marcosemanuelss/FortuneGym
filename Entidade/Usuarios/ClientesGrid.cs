using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Usuarios
{
    [Serializable]
    public class ClientesGrid
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_USUARIO")]
        public int Codigo { get; set; }

        [Coluna("NM_LOGIN")]
        public string Login { get; set; }

        [Coluna("CD_CPF")]
        public string Cpf { get; set; }

        [Coluna("DS_NOME")]
        public string Nome { get; set; }

        [Coluna("DS_SENHA")]
        public string Senha { get; set; }

        [Coluna("DS_SENHA_SALT")]
        public string SenhaSalt { get; set; }

        [Coluna("ID_USUARIO_TIPO")]
        public int CodigoTipo { get; set; }

        [Coluna("DS_TIPO")]
        public string DescricaoTipo { get; set; }

        [Coluna("DT_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Coluna("IN_ATIVO")]
        public string Situcacao { get; set; }

        [Coluna("ID_USUARIO_ALT")]
        public int? CodigoUsuarioAlteracao { get; set; }

        [Coluna("DT_ALTERACAO")]
        public DateTime? DataAlteracao { get; set; }

        [Coluna("NR_MATRICULA")]
        public string Matricula { get; set; }

        [Coluna("DT_NASCIMENTO")]
        public DateTime? DataNascimento { get; set; }

        [Coluna("DS_CEP")]
        public string Cep { get; set; }

        [Coluna("DS_ENDERECO")]
        public string Endereco { get; set; }

        [Coluna("NR_ENDERECO")]
        public int Numero { get; set; }

        [Coluna("DS_COMPLEMENTO")]
        public string Complemento { get; set; }

        [Coluna("DS_BAIRRO")]
        public string Bairro { get; set; }

        [Coluna("DS_CIDADE")]
        public string Cidade { get; set; }

        [Coluna("SG_UF")]
        public string Estado { get; set; }

        [Coluna("NR_TELEFONE")]
        public string Telefone { get; set; }

        [Coluna("NR_CELULAR")]
        public string Celular { get; set; }

        [Coluna("DS_EMAIL")]
        public string Email { get; set; }
    }
}
