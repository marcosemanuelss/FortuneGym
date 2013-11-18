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

            if (CodigoRetorno > 0)
                Mensagem = "Usuário inserido com sucesso. Sua senha é trocar@123 ";
            else if (CodigoRetorno == -2601)
                Mensagem = "Login já cadastrado no sistema, favor escolher outro.";
            else
                Mensagem = "Erro ao inserir usuário, favor verificar os dados informados e tentar novamente.";

            return CodigoRetorno > 0;
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

        public bool ObterUsuario(string Login, string CPF, ref string Mensagem)
        {
            int CodigoRetorno = new PerUsuarios().ObterUsuario(Login, CPF);

            bool Valido = false;

            if (CodigoRetorno == 1)
            {
                Mensagem = "Email enviado com sucesso. Verifique sua caixa de entrada";
                Valido = true;
            }
            else
            {
                Mensagem = "Não existe esse usuário no sistema.";
            }
            
            return Valido;
        }

        public bool AlterarSenhaUsuario(int CodigoAcademia, int CodigoUsuario, string NovaSenha, ref string Mensagem)
        {
            int CodigoRetorno = new PerUsuarios().AlterarSenhaUsuario(CodigoAcademia, CodigoUsuario, NovaSenha);
            bool Valido = false;
            if (CodigoRetorno == 1)
            {
                Mensagem = "Senha alterada com sucesso. O sistema será redirecionado para a tela de login.";
                Valido = true;
            }
            else
            {
                Mensagem = "Erro ao alterar senha.";
                Valido = false;
            }
            return Valido;
        }

        public List<UsuarioTipo> ListarUsuarioTipo()
        {
            return new PerUsuarios().ListarUsuarioTipo();
        }
    }
}
