using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Usuarios;
using Persistencia.Usuarios;
using Persistencia.Perfil;
using Persistencia.Fichas;
using Persistencia.Objetivos;
using Negocio.Fichas;

namespace Negocio.Usuarios
{
    public class NegUsuario
    {
        /// <summary>
        /// Verifica se o login e a senha do usuário está correta, se sim já adiciona as páginas que ele possui permissão e
        /// caso ainda ele seja um cliente obtem informações complementares.
        /// </summary>
        /// <param name="usuario">Login do Usuário</param>
        /// <param name="senha">Senha do Usuário</param>
        /// <returns>Objeto Usuário todo populado</returns>
        public Entidade.Usuarios.Usuarios Logar(string Usuario, string Senha)
        {
            Entidade.Usuarios.Usuarios UsuarioRetorno = new PerUsuarios().Logar(Usuario, Senha);

            if (UsuarioRetorno != null)
            {
                UsuarioRetorno.Paginas = new PerPaginas().ListarPaginas(UsuarioRetorno.CodigoTipo);

                if (UsuarioRetorno.CodigoTipo == 1)
                {
                    UsuarioRetorno.Complemento = ObterComplemento(UsuarioRetorno.CodigoAcademia, UsuarioRetorno.Codigo);
                }
            }

            return UsuarioRetorno;
        }

        private UsuarioComplemento ObterComplemento(int CodigoAcademia, int CodigoUsuario)
        {
            UsuarioComplemento Complemento = new PerUsuarios().ObterComplemento(CodigoAcademia, CodigoUsuario);
            Complemento.Ficha = new NegFicha().ObterFicha(CodigoAcademia, CodigoUsuario);
            Complemento.Objetivo = new PerObjetivo().ListarObjetivos(CodigoAcademia, CodigoUsuario);
            return Complemento;
        }

        public List<Entidade.Usuarios.UsuariosGrid> ListarUsuarios(int CodigoAcademia, string Filtro)
        {
            return new PerUsuarios().ListarUsuarios(CodigoAcademia, Filtro);
        }

        public bool InserirUsuario(Entidade.Usuarios.Usuarios NovoUsuario, ref string Mensagem)
        {
            int CodigoRetorno = new PerUsuarios().InserirUsuario(NovoUsuario);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Usuário inserido com sucesso. Sua senha é trocar@123 ";
                    break;
                case 2601: Mensagem = "Login já cadastrado no sistema, favor escolher outro.";
                    break;
                default: Mensagem = "Erro ao inserir usuário, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool BloquearUsuario(int CodigoAcademia, int CodigoUsuario, int CodigoUsuarioAlteracao, ref string Mensagem)
        {
            int CodigoRetorno = new PerUsuarios().BloquearUsuario(CodigoAcademia, CodigoUsuario, CodigoUsuarioAlteracao);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Usuário bloqueado com sucesso.";
                    break;
                default: Mensagem = "Erro ao bloquear usuário, favor tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool RedefinirSenha(int CodigoAcademia, int CodigoUsuario, int CodigoUsuarioAlteracao, ref string Mensagem)
        {
            int CodigoRetorno = new PerUsuarios().RedefinirSenha(CodigoAcademia, CodigoUsuario, CodigoUsuarioAlteracao);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Senha redefinida com sucesso. A nova senha é trocar@123";
                    break;
                default: Mensagem = "Erro ao redefinir a senha, favor tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }

        public bool AtualizarUsuario(Entidade.Usuarios.Usuarios NovoUsuario, int CodigoUsuarioAlteracao, ref string Mensagem)
        {
            int CodigoRetorno = new PerUsuarios().AtualizarUsuario(NovoUsuario, CodigoUsuarioAlteracao);

            switch (CodigoRetorno)
            {
                case 1: Mensagem = "Usuário atualizado com sucesso.";
                    break;
                default: Mensagem = "Erro ao atualizar o usuário, favor verificar os dados informados e tentar novamente.";
                    break;
            }

            return CodigoRetorno == 1;
        }
    }
}
