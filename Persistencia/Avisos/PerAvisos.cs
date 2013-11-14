using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia.Base;
using System.Data;
using System.Data.Common;
using Entidade.Avisos;

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

            return Base.Db.ReadList<AvisosVisao>("SP_LISTAR_AVISOS_ARQUIVOS", GenericMake.Make<AvisosVisao>, CommandType.StoredProcedure, p);
        }
    }
}
