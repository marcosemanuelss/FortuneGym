using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Data.Linq;
using System.Reflection;
using System.Data;
using System.ComponentModel;

namespace Persistencia.Base
{
    public static class MethodExtensions
    {


        public static string Formatado(this object valor, string formato, IFormatProvider provedor)
        {            
            if (valor.GetType().ImplementsInterface<IFormattable>())
            {
                return ((IFormattable)valor).ToString(formato, provedor);
            }
            return valor.ToString();
        }
        public static bool ImplementsInterface<T>(this Type type)
        {
            var implements = false;
            if (typeof(T).IsInterface)
            {
                var interfaceName = typeof(T).Name;
                implements = (type.GetInterface(interfaceName) != null);
            }
            return implements;
        }
        public static void SetValue(this PropertyInfo property, object instancia, object value, IFormatProvider format = null)
        {
            if (Convert.IsDBNull(value) || value == null)
            {
                if (property.PropertyType.IsValueType)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        value = default(DateTime);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        value = default(bool);
                    }
                    else
                    {
                        object testeDeValor = Activator.CreateInstance(property.PropertyType);
                        value = testeDeValor;
                    }

                    property.SetValue(instancia, value, null);
                }
            }
            else
            {
                if (property.PropertyType.IsGenericType &&
                    property.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))
                    )
                {
                    if (!property.PropertyType.GetGenericArguments()[0].Equals(value.GetType()))
                    {
                        value = CreateTypeConverter(value.GetType()).ConvertTo(value, property.PropertyType.GetGenericArguments()[0]);
                    }
                    NullableConverter conversor = new NullableConverter(property.PropertyType);
                    value = conversor.ConvertFrom(value);
                }
                else if (property.PropertyType != value.GetType() &&
                        property.PropertyType.IsValueType &&
                        (value.GetType().IsValueType || value.GetType() == typeof(string)))
                {
                    if (property.PropertyType.IsEnum)
                    {
                        value = Enum.Parse(property.PropertyType, value.ToString());
                    }
                    else
                    {
                        value = Convert.ChangeType(value, property.PropertyType, format);
                    }
                }

                property.SetValue(instancia, value, null);
            }
        }

        private static TypeConverter CreateTypeConverter(Type t)
        {
            return (TypeConverter)Assembly.GetAssembly(typeof(TypeConverter)).CreateInstance(string.Format("System.ComponentModel.{0}Converter", t.Name));
        }

        public static Nullable<T> ToNullable<T>(this T obj) where T : struct
        {
            return new Nullable<T>(obj);
        }


        public static bool HasColumn(this IDataReader dr, string columnName)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }

        public static T[] GetCustomAttributes<T>(this Type tipo) where T : Attribute
        {
            return tipo.GetCustomAttributes(typeof(T), true).Cast<T>().ToArray();
        }

        public static Dictionary<string, string> ObterDescricaoEnum(Type tipoEnum)
        {
            Type tipo = tipoEnum;
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (object item in Enum.GetValues(tipo))
            {
                var attrs = tipo.GetMember(item.ToString())[0].GetCustomAttributes<DescriptionAttribute>();
                dic.Add(item.ToString(), attrs.Length > 0 ? attrs[0].Description : item.ToString());
            }
            return dic;
        }

        public static Dictionary<T, string> ObterDescricaoEnum<T>()
        {
            Type tipo = typeof(T);
            Dictionary<T, string> dic = new Dictionary<T, string>();
            foreach (T item in Enum.GetValues(tipo))
            {
                var attrs = tipo.GetMember(item.ToString())[0].GetCustomAttributes<DescriptionAttribute>();
                dic.Add(item, attrs.Length > 0 ? attrs[0].Description : item.ToString());
            }
            return dic;
        }

        public static T[] GetCustomAttributes<T>(this MemberInfo prop) where T : Attribute
        {
            return prop.GetCustomAttributes(typeof(T), true).Cast<T>().ToArray();
        }

        /// <summary>
        /// Transform object into Identity data type (integer).
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is -1.</param>
        /// <returns>Identity value.</returns>
        public static int AsId(this object item, int defaultId = -1)
        {
            if (item == null)
                return defaultId;

            int result;
            if (!int.TryParse(item.ToString(), out result))
                return defaultId;

            return result;
        }

        /// <summary>
        /// Transform object into integer data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(int).</param>
        /// <returns>The integer value.</returns>
        public static int AsInt(this object item, int defaultInt = default(int))
        {
            if (item == null)
                return defaultInt;

            int result;
            if (!int.TryParse(item.ToString(), out result))
                return defaultInt;

            return result;
        }

        /// <summary>
        /// Transform object into double data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(double).</param>
        /// <returns>The double value.</returns>
        public static double AsDouble(this object item, double defaultDouble = default(double))
        {
            if (item == null)
                return defaultDouble;

            double result;
            if (!double.TryParse(item.ToString(), out result))
                return defaultDouble;

            return result;
        }

        /// <summary>
        /// Transform object into string data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(string).</param>
        /// <returns>The string value.</returns>
        public static string AsString(this object item, string defaultString = default(string))
        {
            if (item == null || item.Equals(System.DBNull.Value))
                return defaultString;

            return item.ToString().Trim();
        }

        /// <summary>
        /// Transform object into DateTime data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(DateTime).</param>
        /// <returns>The DateTime value.</returns>
        public static DateTime AsDateTime(this object item, DateTime defaultDateTime = default(DateTime))
        {
            if (item == null || string.IsNullOrEmpty(item.ToString()))
                return defaultDateTime;

            DateTime result;
            if (!DateTime.TryParse(item.ToString(), out result))
                return defaultDateTime;

            return result;
        }

        /// <summary>
        /// Transform object into bool data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <param name="defaultId">Optional default value is default(bool).</param>
        /// <returns>The bool value.</returns>
        public static bool AsBool(this object item, bool defaultBool = default(bool))
        {
            if (item == null)
                return defaultBool;

            return new List<string>() { "yes", "y", "true" }.Contains(item.ToString().ToLower());
        }

        /// <summary>
        /// Transform string into byte array.
        /// </summary>
        /// <param name="s">The object to be transformed.</param>
        /// <returns>The transformed byte array.</returns>
        public static byte[] AsByteArray(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            return Convert.FromBase64String(s);
        }

        /// <summary>
        /// Transform object into base64 string.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <returns>The base64 string value.</returns>
        public static string AsBase64String(this object item)
        {
            if (item == null)
                return null;
            ;

            return Convert.ToBase64String((byte[])item);
        }

        /// <summary>
        /// Transform Binary into base64 string data type. 
        /// Note: This is used in LINQ to SQL only.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <returns>The base64 string value.</returns>
        public static string AsBase64String(this Binary item)
        {
            if (item == null)
                return null;

            return Convert.ToBase64String(item.ToArray());
        }

        /// <summary>
        /// Transform base64 string to Binary data type. 
        /// Note: This is used in LINQ to SQL only.
        /// </summary>
        /// <param name="s">The base 64 string to be transformed.</param>
        /// <returns>The Binary value.</returns>
        public static Binary AsBinary(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;

            return new Binary(Convert.FromBase64String(s));
        }

        /// <summary>
        /// Transform object into Guid data type.
        /// </summary>
        /// <param name="item">The object to be transformed.</param>
        /// <returns>The Guid value.</returns>
        public static Guid AsGuid(this object item)
        {
            try { return new Guid(item.ToString()); }
            catch { return Guid.Empty; }
        }

        /// <summary>
        /// Concatenates SQL and ORDER BY clauses into a single string. 
        /// </summary>
        /// <param name="sql">The SQL string</param>
        /// <param name="sortExpression">The Sort Expression.</param>
        /// <returns>Contatenated SQL Statement.</returns>
        public static string OrderBy(this string sql, string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return sql;

            return sql + " ORDER BY " + sortExpression;
        }

        /// <summary>
        /// Takes an enumerable source and returns a comma separate string.
        /// Handy to build SQL Statements (for example with IN () statements) from object collections.
        /// </summary>
        /// <typeparam name="T">The Enumerable type</typeparam>
        /// <typeparam name="U">The original data type (typically identities - int).</typeparam>
        /// <param name="source">The enumerable input collection.</param>
        /// <param name="func">The function that extracts property value in object.</param>
        /// <returns>The comma separated string.</returns>
        public static string CommaSeparate<T, U>(this IEnumerable<T> source, Func<T, U> func)
        {
            return string.Join(",", source.Select(s => func(s).ToString()).ToArray());
        }

        public static string SerializarXML(this object that)
        {
            XmlSerializer xs = new XmlSerializer(that.GetType());
            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
            {
                xs.Serialize(sw, that);
                return sb.ToString();
            }
        }


        public static T DeserializarXML<T>(this string that)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader sr = new StringReader(that))
            {
                return (T)xs.Deserialize(sr);
            }
        }
    }
}
