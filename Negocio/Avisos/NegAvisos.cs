using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia.Avisos;

namespace Negocio.Avisos
{
    public class NegAvisos
    {
        public List<Entidade.Avisos.Avisos> ListarAvisos(int CodigoAcademia, string Filtro, int TipoUsuario)
        {
            PerAvisos PerAvisos = new PerAvisos();
            List<Entidade.Avisos.Avisos> RetornoAviso = new List<Entidade.Avisos.Avisos>();

            RetornoAviso = PerAvisos.ListarAvisos(CodigoAcademia, Filtro, TipoUsuario);

            for (int i = 0; i < RetornoAviso.Count; i++)
            {
                RetornoAviso[i].Arquivos = PerAvisos.ListarArquivos(CodigoAcademia, RetornoAviso[i].Codigo);
                RetornoAviso[i].Visao = PerAvisos.ListarVisao(CodigoAcademia, RetornoAviso[i].Codigo);
            }

            return RetornoAviso;
        }

        public bool InserirAviso(Entidade.Avisos.Avisos NovoAviso, ref string Mensagem)
        {
            throw new NotImplementedException();
        }

        public bool AtualizarAviso(Entidade.Avisos.Avisos NovoAviso, ref string Mensagem)
        {
            throw new NotImplementedException();
        }
    }
}
