using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Fichas;
using Persistencia.Fichas;
using Entidade.Exercicios;

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
            int CodigoRetorno = new PerSerieTipo().DesabilitarTipo(CodigoAcademia, CodigoTipo);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Tipo de Série excluida com sucesso.";
                    break;
                default: Mensagem = "Não foi possivel excluir este tipo de série." +
                   "Certifique-se que não existe Exercícios vinculadas a mesma e tente novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool InserirTipo(SerieTipo NovaSerieTipo, ref string Mensagem)
        {
            int CodigoRetorno = new PerSerieTipo().InserirTipo(NovaSerieTipo);

            if (CodigoRetorno > 0)
                Mensagem = "Tipo de Série inserido com sucesso.";
            else
                Mensagem = "Erro ao inserir tipo de série, favor verificar os dados informados e tentar novamente.";

            return CodigoRetorno > 0;
        }

        public bool AtualizarTipo(SerieTipo NovaSerieTipo, ref string Mensagem)
        {
            int CodigoRetorno = new PerSerieTipo().AtualizarTipo(NovaSerieTipo);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Tipo de Série atualizado com sucesso.";
                    break;
                default: Mensagem = "Erro ao atualizar o tipo de série, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool VincularTipoCategoria(SerieTipo Tipo, List<ExercicioCategoria> Categorias, ref string Mensagem)
        {
            int CodigoRetorno = new PerSerieTipo().VincularTipoCategoria(Tipo, Categorias);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Categorias vinculadas com sucesso.";
                    break;
                default: Mensagem = "Erro ao vincular categorias, favor tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
