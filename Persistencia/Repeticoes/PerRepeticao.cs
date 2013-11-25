using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade.Repeticoes;
using System.Data.Common;
using Persistencia.Base;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia.Repeticoes
{
    public class PerRepeticao
    {
        public TipoRepeticao ObterTipoRepeticao(int CodigoAcademia, int CodigoTipoRepeticao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_TIPO_REPETICAO", CodigoTipoRepeticao));

            return Base.Db.Read<TipoRepeticao>("SP_OBTER_TIPO_REPETICAO", GenericMake.Make<TipoRepeticao>, CommandType.StoredProcedure, p);
        }

        public List<Repeticao> ListarRepeticao(int CodigoAcademia, int CodigoTipoRepeticao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_TIPO_REPETICAO", CodigoTipoRepeticao));

            return Base.Db.ReadList<Repeticao>("SP_LISTAR_REPETICAO", GenericMake.Make<Repeticao>, CommandType.StoredProcedure, p);
        }

        public static List<TipoRepeticao> ListarTipoRepeticao(int CodigoAcademia, string Filtro)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_FILTRO", Filtro));

            return Base.Db.ReadList<TipoRepeticao>("SP_LISTAR_TIPO_REPETICAO", GenericMake.Make<TipoRepeticao>, CommandType.StoredProcedure, p);
        }

        public static int InserirTipoRepeticao(TipoRepeticao NovaRepeticao, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovaRepeticao.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovaRepeticao.Nome));
            p.Add(Base.Db.CreateParameter("@IN_TIPO", NovaRepeticao.Tipo));

            return Base.Db.Insert("SP_INSERIR_TIPO_REPETICAO", CommandType.StoredProcedure, p, Command);
        }

        public static int InserirRepeticao(TipoRepeticao NovaRepeticao, SqlCommand Command)
        {
            int retorno = -1;
            for (int i = 0; i < NovaRepeticao.Repeticoes.Count; i++)
            {
                List<DbParameter> p = new List<DbParameter>();
                p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovaRepeticao.CodigoAcademia));
                p.Add(Base.Db.CreateParameter("@ID_TIPO_REPETICAO", NovaRepeticao.Codigo));
                p.Add(Base.Db.CreateParameter("@NR_VEZES", NovaRepeticao.Repeticoes[i].QtdVezes));
                p.Add(Base.Db.CreateParameter("@NR_REPETICAO", NovaRepeticao.Repeticoes[i].QtdRepeticao));
                p.Add(Base.Db.CreateParameter("@IN_MUDANCA", NovaRepeticao.Repeticoes[i].Variacao));

                retorno = Base.Db.Insert("SP_INSERIR_REPETICAO", CommandType.StoredProcedure, p, Command);

                if (retorno != 1)
                    break;
            }

            return retorno;
        }

        public static int AtualizarTipoRepeticao(TipoRepeticao NovaRepeticao, SqlCommand Command)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", NovaRepeticao.CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_TIPO_REPETICAO", NovaRepeticao.Codigo));
            p.Add(Base.Db.CreateParameter("@DS_NOME", NovaRepeticao.Nome));
            p.Add(Base.Db.CreateParameter("@IN_TIPO", NovaRepeticao.Tipo));

            return Base.Db.Insert("SP_ATUALIZAR_TIPO_REPETICAO", CommandType.StoredProcedure, p, Command);
        }

        public static int AtualizarRepeticao(int CodigoAcademia, int CodigoTipoRepeticao, Repeticao NovaRepeticao)
        {
            List<DbParameter> p = new List<DbParameter>();
            p.Add(Base.Db.CreateParameter("@ID_ACADEMIA", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_TIPO_REPETICAO", CodigoAcademia));
            p.Add(Base.Db.CreateParameter("@ID_REPETICAO", NovaRepeticao.Codigo));
            p.Add(Base.Db.CreateParameter("@NR_VEZES", NovaRepeticao.QtdVezes));
            p.Add(Base.Db.CreateParameter("@NR_REPETICAO", NovaRepeticao.QtdRepeticao));
            p.Add(Base.Db.CreateParameter("@IN_MUDANCA", NovaRepeticao.Variacao));

            return Base.Db.Insert("SP_ATUALIZAR_REPETICAO", CommandType.StoredProcedure, p);
        }
    }
}
