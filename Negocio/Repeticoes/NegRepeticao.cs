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
            PerRepeticao PerRepeticao = new PerRepeticao();

            int CodigoRetorno = PerRepeticao.InserirTipoRepeticao(NovaRepeticao);

            if (CodigoRetorno > 0)
            {
                NovaRepeticao.Codigo = CodigoRetorno;
                CodigoRetorno = PerRepeticao.InserirRepeticao(NovaRepeticao);
            }

            if (CodigoRetorno > 0)
                Mensagem = "Repetição inserida com sucesso.";
            else
                Mensagem = "Erro ao inserir repetição, favor verificar os dados informados e tentar novamente.";

            return CodigoRetorno > 0;
        }

        public bool AtualizarRepeticao(TipoRepeticao NovaRepeticao, ref string Mensagem)
        {
            PerRepeticao PerRepeticao = new PerRepeticao();
            int CodigoRetorno = PerRepeticao.AtualizarTipoRepeticao(NovaRepeticao);

            if (CodigoRetorno == 1)
            {
                for (int i = 0; i < NovaRepeticao.Repeticoes.Count; i++)
                {
                    if (NovaRepeticao.Repeticoes[i].Codigo == 0)
                        CodigoRetorno = PerRepeticao.InserirRepeticao(NovaRepeticao);
                    else
                        CodigoRetorno = PerRepeticao.AtualizarRepeticao(NovaRepeticao.CodigoAcademia, NovaRepeticao.Codigo, NovaRepeticao.Repeticoes[i]);

                    if (CodigoRetorno != 1)
                        break;
                }
            }

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Repetição atualizada com sucesso.";
                    break;
                default: Mensagem = "Erro ao atualizar repetição, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
