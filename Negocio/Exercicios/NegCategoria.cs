using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Exercicios;
using Persistencia.Exercicios;

namespace Negocio.Exercicios
{
    public class NegCategoria
    {
        public List<ExercicioCategoria> ListarCategorias(int CodigoAcademia, string Filtro)
        {
            return new PerCategoria().ListarCategorias(CodigoAcademia, Filtro);
        }

        public bool DesabilitarCategoria(int CodigoAcademia, int CodigoCategoria, ref string Mensagem)
        {
            int CodigoRetorno = new PerCategoria().DesabilitarCategoria(CodigoAcademia, CodigoCategoria);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Categoria excluida com sucesso.";
                    break;
                default: Mensagem = "Não foi possivel excluir está categoria." +
                   "Certifique-se que não existe Exercícios vinculadas a mesma e tente novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool InserirCategoria(ExercicioCategoria NovaCategoria, ref string Mensagem)
        {
            int CodigoRetorno = new PerCategoria().InserirCategoria(NovaCategoria);

            if (CodigoRetorno > 0)
                Mensagem = "Categoria inserida com sucesso.";
            else
                Mensagem = "Erro ao inserir categoria, favor verificar os dados informados e tentar novamente.";

            return CodigoRetorno > 0;
        }

        public bool AtualizarCategoria(ExercicioCategoria NovaCategoria, ref string Mensagem)
        {
            int CodigoRetorno = new PerCategoria().AtualizarCategoria(NovaCategoria);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Categoria atualizado com sucesso.";
                    break;
                default: Mensagem = "Erro ao atualizar a categoria, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
