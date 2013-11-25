using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia.Base;
using System.Data;
using System.Data.Common;
using Entidade.Avisos;
using System.Data.SqlClient;

namespace Persistencia.Avisos
{
    public class PerAvisos
    {
        public static List<Entidade.Avisos.Avisos> ListarAvisos(int CodigoAcademia, string Filtro, int TipoUsuario)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_TIPO", TipoUsuario));

            return Base.Db.ReadList<Entidade.Avisos.Avisos>("SP_LISTAR_AVISOS", GenericMake.Make<Entidade.Avisos.Avisos>, CommandType.StoredProcedure, p);
        }

        public static List<AvisosArquivos> ListarArquivos(int CodigoAcademia, int CodigoAviso)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", CodigoAviso));

            return Base.Db.ReadList<AvisosArquivos>("SP_LISTAR_AVISOS_ARQUIVOS", GenericMake.Make<AvisosArquivos>, CommandType.StoredProcedure, p);
        }

        public static List<AvisosVisao> ListarVisao(int CodigoAcademia, int CodigoAviso)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", CodigoAviso));

            return Base.Db.ReadList<AvisosVisao>("SP_LISTAR_AVISOS_VISAO", GenericMake.Make<AvisosVisao>, CommandType.StoredProcedure, p);
        }

        public int DesabilitarAviso(int CodigoAcademia, int CodigoAviso, int CodigoUsuario)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", CodigoAviso));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO", CodigoUsuario));

            return (int)Base.Db.GetScalar("SP_BLOQUEAR_AVISO", CommandType.StoredProcedure, p);
        }

        public int InserirAviso(Entidade.Avisos.Avisos NovoAviso, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovoAviso.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_CADASTRO", NovoAviso.CodigoUsuarioCadastro));
            p.Add(Base.Db.CreateParameter("@DS_TITULO", NovoAviso.Titulo));
            p.Add(Base.Db.CreateParameter("@DS_DESCRICAO", NovoAviso.Descricao));

            return Base.Db.Insert("SP_INSERIR_AVISO", CommandType.StoredProcedure, p, Command);
        }

        public int InserirVisao(int CodigoAcademia, int CodigoAviso, string Codigos, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", CodigoAviso));
            p.Add(Base.Db.CreateParameter("@ID_TIPOS", Codigos));

            return Base.Db.Insert("SP_INSERIR_AVISO_USUARIOS_TIPOS", CommandType.StoredProcedure, p, Command);
        }

        public int InserirArquivo(int CodigoAcademia, int CodigoAviso, AvisosArquivos AvisosArquivos, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", CodigoAviso));
            p.Add(Base.Db.CreateParameter("@DS_ARQUIVO", AvisosArquivos.Descricao));
            p.Add(Base.Db.CreateParameter("@IM_ARQUIVO", AvisosArquivos.Arquivo));
            p.Add(Base.Db.CreateParameter("@DS_EXTENSAO", AvisosArquivos.Extensao));

            return Base.Db.Insert("SP_INSERIR_AVISO_ARQUIVO", CommandType.StoredProcedure, p, Command);
        }

        public int AtualizarAviso(Entidade.Avisos.Avisos NovoAviso, int CodigoUsuarioAlt, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovoAviso.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", NovoAviso.Codigo));
            p.Add(Base.Db.CreateParameter("@ID_USUARIO_ALTERACAO", CodigoUsuarioAlt));
            p.Add(Base.Db.CreateParameter("@DS_TITULO", NovoAviso.Titulo));
            p.Add(Base.Db.CreateParameter("@DS_DESCRICAO", NovoAviso.Descricao));

            return (int)Base.Db.GetScalar("SP_ATUALIZAR_AVISO", CommandType.StoredProcedure, p, Command);
        }

        public void RemoverVisao(int CodigoAcademia, int CodigoAviso, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", CodigoAviso));

            Base.Db.GetScalar("SP_EXCLUIR_AVISO_VISAO", CommandType.StoredProcedure, p, Command);
        }

        public void RemoverArquivo(int CodigoAcademia, int CodigoAviso, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_AVISO", CodigoAviso));

            Base.Db.GetScalar("SP_EXCLUIR_AVISO_ARQUIVOS", CommandType.StoredProcedure, p, Command);
        }
    }
}
