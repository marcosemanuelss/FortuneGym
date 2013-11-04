using System;
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
    }
}
