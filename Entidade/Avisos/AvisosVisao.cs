using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Db;

namespace Entidade.Avisos
{
    [Serializable]
    public class AvisosVisao
    {
        [Coluna("ID_ACADEMIA")]
        public int CodigoAcademia { get; set; }

        [Coluna("ID_AVISO")]
        public int CodigoAviso { get; set; }

        [Coluna("ID_USUARIO_TIPO")]
        public int CodigoTipoUsuario { get; set; }
    }
}
