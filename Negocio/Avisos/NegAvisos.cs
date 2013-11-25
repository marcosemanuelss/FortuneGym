using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia.Avisos;
using Persistencia.Base;
using System.Data.SqlClient;

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
            Transacao trans = new Transacao();
            PerAvisos PerAvisos = new PerAvisos();

            int CodigoRetorno = 0;

            try
            {
                CodigoRetorno = PerAvisos.InserirAviso(NovoAviso, trans.GetCommand());

                if (CodigoRetorno > 0)
                {
                    NovoAviso.Codigo = CodigoRetorno;
                    CodigoRetorno = InserirVisaoArquivo(NovoAviso, trans.GetCommand());
                }
            }
            catch
            {
                CodigoRetorno = 0;
                trans.Rollback();
            }

            if (CodigoRetorno > 0)
            {
                trans.Commit();
                Mensagem = "Aviso inserido com sucesso.";
            }
            else
            {
                trans.Rollback();
                Mensagem = "Erro ao inserir aviso, favor verificar os dados informados e tentar novamente.";
            }

            return CodigoRetorno > 0;
        }

        private int InserirVisaoArquivo(Entidade.Avisos.Avisos NovoAviso, SqlCommand Command)
        {
            PerAvisos perAvisos = new PerAvisos();
            int CodigoRetorno = NovoAviso.Codigo;

            if (NovoAviso.Visao != null && NovoAviso.Visao.Count > 0)
            {
                string Codigos = "";
                for (int i = 0; i < NovoAviso.Visao.Count; i++)
                {
                    Codigos += NovoAviso.Visao[i].CodigoTipoUsuario + ", ";
                }
                Codigos = Codigos.Substring(0, Codigos.Length - 2);

                CodigoRetorno = perAvisos.InserirVisao(NovoAviso.CodigoAcademia, NovoAviso.Codigo, Codigos, Command);
            }

            if (CodigoRetorno > 0 && NovoAviso.Arquivos != null && NovoAviso.Arquivos.Count > 0)
            {
                for (int i = 0; i < NovoAviso.Arquivos.Count; i++)
                {
                    CodigoRetorno = perAvisos.InserirArquivo(NovoAviso.CodigoAcademia, NovoAviso.Codigo, NovoAviso.Arquivos[i], Command);

                    if (CodigoRetorno <= 0)
                        break;
                }
            }

            return CodigoRetorno;
        }

        public bool AtualizarAviso(Entidade.Avisos.Avisos NovoAviso, int CodigoUsuarioAlt, ref string Mensagem)
        {
            Transacao trans = new Transacao();
            PerAvisos perAvisos = new PerAvisos();
            int CodigoRetorno = 0;
            try
            {
                CodigoRetorno = perAvisos.AtualizarAviso(NovoAviso, CodigoUsuarioAlt, trans.GetCommand());

                if (CodigoRetorno > 0)
                {
                    perAvisos.RemoverVisao(NovoAviso.CodigoAcademia, NovoAviso.Codigo, trans.GetCommand());
                    perAvisos.RemoverArquivo(NovoAviso.CodigoAcademia, NovoAviso.Codigo, trans.GetCommand());

                    CodigoRetorno = InserirVisaoArquivo(NovoAviso, trans.GetCommand());
                }
            }
            catch
            {
                CodigoRetorno = 0;
                trans.Rollback();
            }

            switch (CodigoRetorno)
            {
                case 1:
                    trans.Commit();
                    Mensagem = "Aviso atualizado com sucesso.";
                    break;
                default:
                    trans.Rollback();
                    Mensagem = "Erro ao atualizar o aviso, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool DesabilitarAviso(int CodigoAcademia, int CodigoAviso, int CodigoUsuario, ref string Mensagem)
        {
            int CodigoRetorno = new PerAvisos().DesabilitarAviso(CodigoAcademia, CodigoAviso, CodigoUsuario);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Aviso excluido com sucesso.";
                    break;
                default: Mensagem = "Não foi possivel excluir este aviso.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
