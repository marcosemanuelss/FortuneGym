using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Repeticoes;
using Persistencia.Repeticoes;
using Persistencia.Base;

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

        public List<TipoRepeticao> ListarRepeticoes(int CodigoAcademia, string Filtro)
        {
            PerRepeticao PerRepeticao = new PerRepeticao();
            List<TipoRepeticao> lista = PerRepeticao.ListarTipoRepeticao(CodigoAcademia, Filtro);

            for (int i = 0; i < lista.Count; i++)
                lista[i].Repeticoes = PerRepeticao.ListarRepeticao(CodigoAcademia, lista[i].Codigo);

            return lista;
        }

        public bool InserirRepeticao(TipoRepeticao NovaRepeticao, ref string Mensagem)
        {
            Transacao trans = new Transacao();
            PerRepeticao PerRepeticao = new PerRepeticao();
            int CodigoRetorno = 0;
            try
            {
                CodigoRetorno = PerRepeticao.InserirTipoRepeticao(NovaRepeticao, trans.GetCommand());

                if (CodigoRetorno > 0)
                {
                    NovaRepeticao.Codigo = CodigoRetorno;
                    CodigoRetorno = PerRepeticao.InserirRepeticao(NovaRepeticao, trans.GetCommand());
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
                Mensagem = "Repetição inserida com sucesso.";
            }
            else
            {
                trans.Rollback();
                Mensagem = "Erro ao inserir repetição, favor verificar os dados informados e tentar novamente.";
            }

            return CodigoRetorno > 0;
        }

        public bool AtualizarRepeticao(TipoRepeticao NovaRepeticao, ref string Mensagem)
        {
            //Ajustar esse metodo, para apagar todas as repetições e inserir tudo de novo, atualizar apenas o tipo de repetição
            Transacao trans = new Transacao();
            PerRepeticao PerRepeticao = new PerRepeticao();
            int CodigoRetorno = 0;
            try
            {
                CodigoRetorno = PerRepeticao.AtualizarTipoRepeticao(NovaRepeticao, trans.GetCommand());

                if (CodigoRetorno == 1)
                {
                    for (int i = 0; i < NovaRepeticao.Repeticoes.Count; i++)
                    {
                        CodigoRetorno = PerRepeticao.InserirRepeticao(NovaRepeticao, trans.GetCommand());
                        
                        if (CodigoRetorno != 1)
                            break;
                    }
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
                    Mensagem = "Repetição atualizada com sucesso.";
                    break;
                default:
                    trans.Rollback();
                    Mensagem = "Erro ao atualizar repetição, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
