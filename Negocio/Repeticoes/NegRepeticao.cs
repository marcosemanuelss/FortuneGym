using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Repeticoes;
using Persistencia.Repeticoes;

namespace Negocio.Repeticoes
{
    public class NegRepeticao
    {
        public TipoRepeticao ObterTipoRepeticao(int CodigoAcademia, int CodigoTipoRepeticao)
        {
            TipoRepeticao tipo = new PerRepeticao().ObterTipoRepeticao(CodigoAcademia, CodigoTipoRepeticao);

            if (tipo != null)
                tipo.Repeticoes = new PerRepeticao().ListarRepeticao(CodigoAcademia, CodigoTipoRepeticao);

            return tipo;
        }
    }
}
