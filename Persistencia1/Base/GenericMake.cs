using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SIC.Util.Db;
using SIC.Util;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;

namespace SIC.Persistencia.Base
{
    public static class GenericMake
    {
        /// <summary>
        /// Cache que contem as propriedades dos tipos e seus respectivos campos (decorator)
        /// </summary>
        public static DecoratorCache Cache = new DecoratorCache();
        
        public static T Make<T>(IDataReader reader)
        {   
            var instance = Activator.CreateInstance<T>();
            Type tipo = typeof(T);
            foreach (var coluna in Cache[typeof(T)])
            {
                if (reader.HasColumn(coluna.AtributoColuna.NomeColuna))
                {
                    var value = reader[coluna.AtributoColuna.NomeColuna] == DBNull.Value ? null : reader[coluna.AtributoColuna.NomeColuna];
                    coluna.Propriedade.SetValue(instance, value);
                }
            }
            return instance;
        }


    }
}
