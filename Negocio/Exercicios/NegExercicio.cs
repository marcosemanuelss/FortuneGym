using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Exercicios;
using Persistencia.Exercicios;

namespace Negocio.Exercicios
{
    public class NegExercicio
    {
        public List<ExercicioGrid> ListarExercicios(int CodigoAcademia, string Filtro)
        {
            return new PerExercicio().ListarExercicios(CodigoAcademia, Filtro);
        }

        public bool DesabilitarExercicio(int CodigoAcademia, int CodigoExercicio, ref string Mensagem)
        {
            int CodigoRetorno = new PerExercicio().DesabilitarExercicio(CodigoAcademia, CodigoExercicio);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Exercício excluida com sucesso.";
                    break;
                default: Mensagem = "Não foi possivel excluir este exercício." +
                   "Certifique-se que este Exercícios não está vinculadas a alguma ficha e tente novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool InserirExercicio(Exercicio NovoExercicio, ref string Mensagem)
        {
            int CodigoRetorno = new PerExercicio().InserirExercicio(NovoExercicio);

            if (CodigoRetorno > 0)
                Mensagem = "Exercício inserido com sucesso.";
            else
                Mensagem = "Erro ao inserir exercício, favor verificar os dados informados e tente novamente.";

            return CodigoRetorno > 0;
        }

        public bool AtualizarExercicio(Exercicio NovoExercicio, ref string Mensagem)
        {
            int CodigoRetorno = new PerExercicio().AtualizarExercicio(NovoExercicio);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Exercício atualizado com sucesso.";
                    break;
                default: Mensagem = "Erro ao atualizar o exercício, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
