using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Fichas;
using Persistencia.Fichas;

namespace Negocio.Fichas
{
    public class NegSerieTipo
    {
        public List<SerieTipo> ListarTipos(int CodigoAcademia, string Filtro)
        {
            return new PerSerieTipo().ListarTipos(CodigoAcademia, Filtro);
        }

        public bool DesabilitarTipo(int CodigoAcademia, int CodigoTipo, ref string Mensagem)
        {
            throw new NotImplementedException();
        }
    }
}
