using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIC.Persistencia.Base;

namespace SIC.Persistencia.Base
{

    public class ParametroProcedureCache
    {
        static Dictionary<string, ItemCache[]> Cache = new Dictionary<string, ItemCache[]>();

        public ItemCache[] this[string nomeProcedure]
        {
            get
            {
                if (!Cache.ContainsKey(nomeProcedure))
                    CriarCache(nomeProcedure);
                return Cache[nomeProcedure];
            }
        }

        private void CriarCache(string nomeProcedure)
        {
            List<ItemCache> propCache = new List<ItemCache>();
            foreach (var parametro in Db.GetParameterProcedure(nomeProcedure))
            {
                propCache.Add(new ItemCache()
                {
                    Parametro = parametro
                });
            }
            Cache.Add(nomeProcedure, propCache.ToArray());

        }

        public class ItemCache
        {
            public string Parametro { get; set; }
        }
    }
}
