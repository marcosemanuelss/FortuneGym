﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Persistencia.Base;
using System.Data;

namespace Persistencia.Usuarios
{
    public class PerUsuarios
    {
        public Entidade.Usuarios.Usuarios Logar(string Usuario, string Senha)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@NM_LOGIN", Usuario));
            p.Add(Base.Db.CreateParameter("@DS_SENHA", Senha));

            return Base.Db.Read<Entidade.Usuarios.Usuarios>("SP_LOGAR_USUARIO", GenericMake.Make<Entidade.Usuarios.Usuarios>, CommandType.StoredProcedure, p);
        }

        public Entidade.Usuarios.UsuarioComplemento ObterComplemento(int CodigoAcademia, int CodigoUsuario)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));

            return Base.Db.Read<Entidade.Usuarios.UsuarioComplemento>("SP_OBTER_USUARIO_COMPLEMENTO", GenericMake.Make<Entidade.Usuarios.UsuarioComplemento>, CommandType.StoredProcedure, p);
        }

        public List<Entidade.Usuarios.UsuariosGrid> ListarUsuarios(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<Entidade.Usuarios.UsuariosGrid>("SP_LISTAR_USUARIOS_BUSCA", GenericMake.Make<Entidade.Usuarios.UsuariosGrid>, CommandType.StoredProcedure, p);
        }

        public int InserirUsuario(Entidade.Usuarios.Usuarios NovoUsuario)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovoUsuario.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@NM_LOGIN", NovoUsuario.Login));
            p.Add(Base.Db.CreateParameter("@CD_CPF", NovoUsuario.Cpf));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovoUsuario.Nome));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_TIPO", NovoUsuario.CodigoTipo));
            p.Add(Base.Db.CreateParameter("@DT_CADASTRO", NovoUsuario.DataCadastro));
            p.Add(Base.Db.CreateParameter("@IN_ATIVO", NovoUsuario.Ativo));

            return Base.Db.Insert("SP_INSERIR_USUARIO", CommandType.StoredProcedure, p);
        }

        public int AtualizarUsuario(Entidade.Usuarios.Usuarios NovoUsuario, int CodigoUsuarioAlteracao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovoUsuario.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", NovoUsuario.Codigo));
            p.Add(Base.Db.CreateParameter("@CD_CPF", NovoUsuario.Cpf));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovoUsuario.Nome));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_TIPO", NovoUsuario.CodigoTipo));
            p.Add(Base.Db.CreateParameter("@IN_ATIVO", NovoUsuario.Ativo));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_ALT", CodigoUsuarioAlteracao));

            return Base.Db.Insert("SP_ATUALIZAR_USUARIO", CommandType.StoredProcedure, p);
        }

        public int BloquearUsuario(int CodigoAcademia, int CodigoUsuario, int CodigoUsuarioAlteracao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_ALT", CodigoUsuarioAlteracao));

            return (int)Base.Db.GetScalar("SP_BLOQUEAR_USUARIO", CommandType.StoredProcedure, p);
        }

        public int RedefinirSenha(int CodigoAcademia, int CodigoUsuario, int CodigoUsuarioAlteracao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_ALT", CodigoUsuarioAlteracao));

            return (int)Base.Db.GetScalar("SP_REDEFINIR_SENHA_USUARIO", CommandType.StoredProcedure, p);
        }
    }
}
