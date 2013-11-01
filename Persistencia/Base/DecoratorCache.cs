using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Entidade.Db;

namespace Persistencia.Base
{
    public class DecoratorCache
    {
        static Dictionary<Type, ItemCache[]> Cache = new Dictionary<Type, ItemCache[]>();

        public ItemCache[] this[Type tipo]
        {
            get{
                if (!Cache.ContainsKey(tipo))
                    CriarCache(tipo);
                return Cache[tipo];
            }
        }

        private void CriarCache(Type type)
        {
            List<ItemCache> propCache = new List<ItemCache>();
            foreach (var item in type.GetProperties())
            {
                var atributosColuna = item.GetCustomAttributes<ColunaAttribute>();
                if (atributosColuna.Length > 0)
                {
                    var atributosUso = item.GetCustomAttributes<UsarNoAttribute>();
                    UsarNoAttribute atributoUso = new UsarNoAttribute(UsarNoAttribute.EnumUsarEm.Nenhum);
                    if (atributosUso.Length > 0)
                        atributoUso = atributosUso[0];

                    propCache.Add(new ItemCache()
                    {
                        AtributoColuna = atributosColuna[0],
                        NomePropriedade = item.Name,
                        AtributoUso = atributoUso,
                        Propriedade = item
                    });
                }
            }
            Cache[type] =  propCache.ToArray();
        }

        public class ItemCache
        {
            public string NomePropriedade { get; set; }
            public ColunaAttribute AtributoColuna { get; set; }
            public UsarNoAttribute AtributoUso { get; set; }
            public PropertyInfo Propriedade { get; set; }
        }
    }
}
