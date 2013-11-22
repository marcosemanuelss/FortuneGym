using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Persistencia.Base;
using System.Data;
using Entidade.Usuarios;

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

        public int InserirUsuarioComplemento(Entidade.Usuarios.Usuarios UsuarioComplemento)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", UsuarioComplemento.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", UsuarioComplemento.Codigo));
            p.Add(Base.Db.CreateParameter("@NR_MATRICULA", UsuarioComplemento.Complemento.Matricula));
            p.Add(Base.Db.CreateParameter("@DT_NASCIMENTO", UsuarioComplemento.Complemento.DataNascimento));
            p.Add(Base.Db.CreateParameter("@DS_CEP", UsuarioComplemento.Complemento.Cep));
            p.Add(Base.Db.CreateParameter("@DS_ENDERECO", UsuarioComplemento.Complemento.Endereco));
            p.Add(Base.Db.CreateParameter("@NR_ENDERECO", UsuarioComplemento.Complemento.Numero));
            p.Add(Base.Db.CreateParameter("@DS_COMPLEMENTO", UsuarioComplemento.Complemento.Complemento));
            p.Add(Base.Db.CreateParameter("@DS_BAIRRO", UsuarioComplemento.Complemento.Bairro));
            p.Add(Base.Db.CreateParameter("@DS_CIDADE", UsuarioComplemento.Complemento.Cidade));
            p.Add(Base.Db.CreateParameter("@SG_UF", UsuarioComplemento.Complemento.Uf));
            p.Add(Base.Db.CreateParameter("@NR_TELEFONE", UsuarioComplemento.Complemento.Telefone));
            p.Add(Base.Db.CreateParameter("@NR_CELULAR", UsuarioComplemento.Complemento.Celular));
            p.Add(Base.Db.CreateParameter("@DS_EMAIL", UsuarioComplemento.Complemento.Email));

            return Base.Db.Insert("SP_INSERIR_USUARIO_COMPLEMENTO", CommandType.StoredProcedure, p);
        }

        public int AtualizarUsuarioComplemento(Entidade.Usuarios.Usuarios UsuarioComplemento)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", UsuarioComplemento.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", UsuarioComplemento.Codigo));
            p.Add(Base.Db.CreateParameter("@NR_MATRICULA", UsuarioComplemento.Complemento.Matricula));
            p.Add(Base.Db.CreateParameter("@DT_NASCIMENTO", UsuarioComplemento.Complemento.DataNascimento));
            p.Add(Base.Db.CreateParameter("@DS_CEP", UsuarioComplemento.Complemento.Cep));
            p.Add(Base.Db.CreateParameter("@DS_ENDERECO", UsuarioComplemento.Complemento.Endereco));
            p.Add(Base.Db.CreateParameter("@NR_ENDERECO", UsuarioComplemento.Complemento.Numero));
            p.Add(Base.Db.CreateParameter("@DS_COMPLEMENTO", UsuarioComplemento.Complemento.Complemento));
            p.Add(Base.Db.CreateParameter("@DS_BAIRRO", UsuarioComplemento.Complemento.Bairro));
            p.Add(Base.Db.CreateParameter("@DS_CIDADE", UsuarioComplemento.Complemento.Cidade));
            p.Add(Base.Db.CreateParameter("@SG_UF", UsuarioComplemento.Complemento.Uf));
            p.Add(Base.Db.CreateParameter("@NR_TELEFONE", UsuarioComplemento.Complemento.Telefone));
            p.Add(Base.Db.CreateParameter("@NR_CELULAR", UsuarioComplemento.Complemento.Celular));
            p.Add(Base.Db.CreateParameter("@DS_EMAIL", UsuarioComplemento.Complemento.Email));

            return Base.Db.Insert("SP_ATUALIZAR_USUARIO_COMPLEMENTO", CommandType.StoredProcedure, p);
        }

        public int ObterUsuario(string Login, string CPF)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@NM_LOGIN", Login));
            p.Add(Base.Db.CreateParameter("@CD_CPF", CPF));

            return (int)Base.Db.GetScalar("SP_OBTER_USUARIO", CommandType.StoredProcedure, p);
        }

        public List<Entidade.Usuarios.Usuarios> ObterUsuario(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<Entidade.Usuarios.Usuarios>("SP_OBTER_USUARIO_FICHA", GenericMake.Make<Entidade.Usuarios.Usuarios>, CommandType.StoredProcedure, p);
        }

        public int AlterarSenhaUsuario(int CodigoAcademia, int CodigoUsuario, string NovaSenha)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));
            p.Add(Base.Db.CreateParameter("@DS_SENHA", NovaSenha));

            return (int)Base.Db.GetScalar("SP_ALTERAR_SENHA_USUARIO", CommandType.StoredProcedure, p);
        }

        public List<UsuarioTipo> ListarUsuarioTipo()
        {
            return Base.Db.ReadList<UsuarioTipo>("SP_LISTAR_USUARIO_TIPO", GenericMake.Make<UsuarioTipo>, null);
        }
    }
}
