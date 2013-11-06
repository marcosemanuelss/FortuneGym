using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Usuarios;
using Persistencia.Usuarios;

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
            PerUsuarios PerUsuario = new PerUsuarios();
            NovoUsuario.CodigoTipo = 1;
            int CodigoRetorno = PerUsuario.InserirUsuario(NovoUsuario);

            if (CodigoRetorno > 0)
            {
                NovoUsuario.Codigo = CodigoRetorno;
                CodigoRetorno = PerUsuario.InserirUsuarioComplemento(NovoUsuario);
            }

            if (CodigoRetorno > 0)
                Mensagem = "Cliente inserido com sucesso. Sua senha é trocar@123 ";
            else if (CodigoRetorno == -2601)
                Mensagem = "Login já cadastrado no sistema, favor escolher outro.";
            else 
                Mensagem = "Erro ao inserir cliente, favor verificar os dados informados e tentar novamente.";

            return CodigoRetorno > 0;
        }

        public bool AtualizarCliente(Entidade.Usuarios.Usuarios NovoUsuario, int CodigoUsuarioAlt, ref string Mensagem)
        {
            PerUsuarios PerUsuario = new PerUsuarios();
            int CodigoRetorno = PerUsuario.AtualizarUsuario(NovoUsuario, CodigoUsuarioAlt);

            if (CodigoRetorno == 1)
            {
                CodigoRetorno = PerUsuario.AtualizarUsuarioComplemento(NovoUsuario);
            }

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Cliente atualizado com sucesso.";
                    break;
                default: Mensagem = "Erro ao atualizar cliente, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
