using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Usuarios;
using Persistencia.Usuarios;
using Persistencia.Base;

namespace Negocio.Usuarios
{
    public class NegCliente
    {
        public List<ClientesGrid> ListarClientes(int CodigoAcademia, string Filtro)
        {
            return new PerCliente().ListarClientes(CodigoAcademia, Filtro);
        }

        public bool InserirCliente(Entidade.Usuarios.Usuarios NovoUsuario, ref string Mensagem)
        {
            Transacao trans = new Transacao();
            PerUsuarios PerUsuario = new PerUsuarios();
            NovoUsuario.CodigoTipo = 1;
            int CodigoRetorno = 0;
            try
            {
                CodigoRetorno = PerUsuario.InserirUsuario(NovoUsuario, trans.GetCommand());

                if (CodigoRetorno > 0)
                {
                    NovoUsuario.Codigo = CodigoRetorno;
                    CodigoRetorno = PerUsuario.InserirUsuarioComplemento(NovoUsuario, trans.GetCommand());
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
                Mensagem = "Cliente inserido com sucesso. Sua senha é trocar@123 ";
            }
            else if (CodigoRetorno == -2601)
            {
                trans.Rollback();
                Mensagem = "Login já cadastrado no sistema, favor escolher outro.";
            }
            else
            {
                trans.Rollback();
                Mensagem = "Erro ao inserir cliente, favor verificar os dados informados e tentar novamente.";
            }

            return CodigoRetorno > 0;
        }

        public bool AtualizarCliente(Entidade.Usuarios.Usuarios NovoUsuario, int CodigoUsuarioAlt, ref string Mensagem)
        {
            Transacao trans = new Transacao();
            PerUsuarios PerUsuario = new PerUsuarios();
            int CodigoRetorno = 0;
            try
            {
                CodigoRetorno = PerUsuario.AtualizarUsuario(NovoUsuario, CodigoUsuarioAlt, trans.GetCommand());

                if (CodigoRetorno == 1)
                {
                    CodigoRetorno = PerUsuario.AtualizarUsuarioComplemento(NovoUsuario, trans.GetCommand());
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
                    Mensagem = "Cliente atualizado com sucesso.";
                    break;
                default:
                    trans.Rollback();
                    Mensagem = "Erro ao atualizar cliente, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
