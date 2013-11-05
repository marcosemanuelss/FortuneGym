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
    }
}
