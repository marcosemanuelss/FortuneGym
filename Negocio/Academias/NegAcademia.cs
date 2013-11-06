using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Academias;
using Persistencia.Academias;

namespace Negocio.Academias
{
    public class NegAcademia
    {
        public Academia Obter(int CodigoAcademia)
        {
            PerAcademia perAcademia = new PerAcademia();
            Academia academia = perAcademia.Obter(CodigoAcademia);

            if (academia != null)
                academia.Parametros = perAcademia.ObterParametros(CodigoAcademia);

            return academia;
        }

        public List<Academia> ListarAcademias(string Pesquisa)
        {
            return new PerAcademia().ListarAcademias(Pesquisa);
        }

        public AcademiaParametros ObterParametros(int CodigoAcademia)
        {
            return new PerAcademia().ObterParametros(CodigoAcademia);
        }

        public bool SalvarParametros(AcademiaParametros academiaParametros, ref string Mensagem)
        {
            int CodigoRetorno = new PerAcademia().SalvarParametros(academiaParametros);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Parâmetros salvos com sucesso.";
                    break;
                default: Mensagem = "Erro ao salvar parâmetros. Cadastro cancelado.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public List<string> TipoSituacao()
        {
            List<string> lista = new List<string>();
            lista.Add("");
            lista.Add("Ativo");
            lista.Add("Inativo");
            
            return lista;
        }

        public bool InserirAcademia(Academia academia, ref string Mensagem)
        {
            int CodigoRetorno = new PerAcademia().InserirAcademia(academia);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Academia inserida com sucesso.";
                    break;
                default: Mensagem = "Erro ao inserir academia. Cadastro cancelado.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool AtualizarAcademia(Academia academia, ref string Mensagem)
        {
            int CodigoRetorno = new PerAcademia().AtualizarAcademia(academia);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Academia atualizada com sucesso.";
                    break;
                default: Mensagem = "Erro ao atualizar academia. Cadastro cancelado.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool AlterarSituacao(int CodigoAcademia, bool Situacao, ref string Mensagem)
        {
            int CodigoRetorno = new PerAcademia().AlterarSituacao(CodigoAcademia, Situacao);

            switch (CodigoRetorno)
            {
                case 1: 
                    if (Situacao)
                        Mensagem = "Academia desbloqueada com sucesso.";
                    else
                        Mensagem = "Academia bloqueada com sucesso.";
                    break;
                default:
                    if (Situacao)
                        Mensagem = "Erro ao desbloquear academia.";
                    else
                        Mensagem = "Erro ao bloquear academia.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
