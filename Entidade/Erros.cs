using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    public class Erros
    {
        #region "Propriedades"
            public Int32 Codigo { get; set; }
            public String Campo { get; set; }
            public String Descricao { get; set; }

        #endregion


        #region "Construtor"
            /// <summary>
            /// Construtor da Classe
            /// </summary>
            /// <param name="_Codigo"></param>
            /// <param name="_Campo"></param>
            /// <param name="_Descricao"></param>
            public Erros(Int32 _Codigo, String _Campo, String _Descricao)
            {
                this.Codigo = _Codigo;
                this.Campo = _Campo;
                this.Descricao = _Descricao;
            }
        #endregion
    }
}
