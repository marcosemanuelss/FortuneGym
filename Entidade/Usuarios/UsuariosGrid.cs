using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Usuarios
{
    [Serializable]
    public class UsuariosGrid
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
    }
}
