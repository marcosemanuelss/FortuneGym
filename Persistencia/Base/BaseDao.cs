using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Entidade.Db;

namespace Persistencia.Base
{
    public abstract class BaseDao<T> : IDao<T>
    {

        public T Make(IDataReader reader)
        {
            return GenericMake.Make<T>(reader);
        }

        public T Obter(int PK)
        {
            return Obter(PK, Make);
        }

        public T Obter(int PK, Func<IDataReader, T> make)
        {
            var entidade = Activator.CreateInstance<T>();

            var tipo = typeof(T);
            var cache = new DecoratorCache()[tipo];

            var colunaPk = cache.FirstOrDefault(c => c.AtributoColuna.ChavePrimaria);
            colunaPk.Propriedade.SetValue(entidade, PK);

            return ObterLista(entidade).FirstOrDefault();
        }
        
        public virtual List<T> ObterLista()
        {
            return ObterLista(Activator.CreateInstance<T>(), Make);
        }

        public virtual List<T> ObterLista(T filtro)
        {
            return ObterLista(filtro, Make);
        }

        public virtual List<T> ObterLista(T filtro, Func<IDataReader, T> make)
        {
            var nomeProcedure = string.Format("P_OBTERLISTA_{0}", NomeTabela);
            var cacheParametros = new ParametroProcedureCache()[nomeProcedure].Select(x => x.Parametro).ToArray();
            return Db.ReadList(nomeProcedure, make, MontarParametros(filtro, cacheParametros));
        }

        public void Inserir(T registro)
        {
            var nomeProcedure = string.Format("P_INSERIR_{0}", NomeTabela);
            var tipo = typeof(T);
            var cache = new DecoratorCache()[tipo];

            List<DbParameter> parms = new List<DbParameter>();
            foreach (var campo in cache.Where(x=>x.AtributoUso.UsarNaInsercao))
            {
                parms.Add(Db.CreateParameter(campo.AtributoColuna.NomeColuna, campo.Propriedade.GetValue(registro, null)));
            }


            var chave = Db.Insert(nomeProcedure, parms);
            foreach (var campo in cache.Where(x=>x.AtributoColuna.ChavePrimaria))
            {
                campo.Propriedade.SetValue(registro, chave, null);
            }
        }

        public void Alterar(T registro)
        {
            var nomeProcedure = string.Format("P_ALTERAR_{0}", NomeTabela);
            var tipo = typeof(T);
            var cache = new DecoratorCache()[tipo];

            List<DbParameter> parms = new List<DbParameter>();
            foreach (var campo in cache.Where(x => x.AtributoUso.UsarNaAlteracao))
            {
                parms.Add(Db.CreateParameter(campo.AtributoColuna.NomeColuna, campo.Propriedade.GetValue(registro, null)));
            }


            Db.Update(nomeProcedure, parms);
        }

        public void Excluir(T registro)
        {
            var nomeProcedure = string.Format("P_EXCLUIR_{0}", NomeTabela);
            var tipo = typeof(T);
            var cache = new DecoratorCache()[tipo];

            List<DbParameter> parms = new List<DbParameter>();
            foreach (var campo in cache.Where(x => x.AtributoUso.UsarNaExclusao))
            {
                parms.Add(Db.CreateParameter(campo.AtributoColuna.NomeColuna, campo.Propriedade.GetValue(registro, null)));
            }


            Db.Delete(nomeProcedure, parms);
        }
        private List<DbParameter> MontarParametros(T filtro, string[] parametrosProcedure)
        {
            List<DbParameter> ret = new List<DbParameter>();
            var tipo = typeof(T);
            var cache = new DecoratorCache()[tipo];

            foreach (var parametro in parametrosProcedure)
            {
                var propriedade = cache.Where(x => x.AtributoColuna.NomeColuna.ToUpper() == parametro.ToUpper().Replace("@", "")).ToList();
                if (propriedade.Count > 0)
                {
                    ret.Add(Db.CreateParameter(parametro, propriedade[0].Propriedade.GetValue(filtro, null)));
                }
            }

            return ret;
        }        

        private string NomeTabela
        {
            get
            {
                var attr = typeof(T).GetCustomAttributes<TabelaAttribute>();

                if (attr.Length < 1)
                    throw new Exception(string.Format("Atributo 'Tabela' não encontrado na classe '{0}'", typeof(T).FullName));

                return attr[0].NomeTabela;
            }
        }
    }
}
