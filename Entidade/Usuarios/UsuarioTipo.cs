using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Usuarios
{
    [Serializable]
    public class UsuarioTipo
    {
        [Coluna("ID_USUARIO_TIPO")]
        public int Codigo { get; set; }

        [Coluna("DS_NOME")]
        public string Nome { get; set; }
    }
}
