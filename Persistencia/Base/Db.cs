using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using Entidade.Db;
using Entidade;

namespace Persistencia.Base
{
    public static class Db
    {
        // Note: Static initializers are thread safe.
        // If this class had a static constructor then these static variables 
        // would need to be initialized there.
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);

        private static readonly string connectionStringName = ConfigurationManager.AppSettings.Get("ConnectionStringName");
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;

        #region Fast data readers

        private static string ConvertDbParameter(List<DbParameter> param)
        {
            string retorno = "";
            if(param != null && param.Count > 0)
            {
                for (int i = 0; i < param.Count; i++)
                    retorno += param[i].Value + ", ";
                retorno = retorno.Substring(0, retorno.Length - 2);
            }
            return retorno;
        }
        /// <summary>
        /// Fast read of individual item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="make"></param>
        /// <param name="commandType"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static T Read<T>(string sql, Func<IDataReader, T> make, CommandType commandType, List<DbParameter> parms, bool autoRead = true)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = commandType;
                    command.CommandText = sql;
                    command.SetParameters(parms);  // Extension method

                    connection.Open();

                    T t = default(T);
                    var reader = command.ExecuteReader();
                    if (autoRead && reader.Read())
                        t = make(reader);
                    //else
                    //    t = make(reader);

                    return t;
                }
            }

        }
        /// <summary>
        /// Fast read of individual item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="make"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static T Read<T>(string procName, Func<IDataReader, T> make, List<DbParameter> parms, bool autoRead = true)
        {
            return Read<T>(procName, make, CommandType.StoredProcedure, parms, autoRead);
        }


        /// <summary>
        /// Fast read of list of items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="make"></param>
        /// <param name="commandType"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static List<T> ReadList<T>(string sql, Func<IDataReader, T> make, CommandType commandType, List<DbParameter> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = commandType;
                    command.SetParameters(parms);

                    connection.Open();

                    var list = new List<T>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        list.Add(make(reader));

                    return list;
                }
            }

        }
        /// <summary>
        /// Fast read of list of items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="procName"></param>
        /// <param name="make"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static List<T> ReadList<T>(string procName, Func<IDataReader, T> make, List<DbParameter> parms)
        {
            return ReadList<T>(procName, make, CommandType.StoredProcedure, parms);
        }

        /// <summary>
        /// Gets a record count.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int GetCount(string sql, CommandType commandType, List<DbParameter> parms)
        {
            return GetScalar(sql, commandType, parms).AsInt();
        }

        /// <summary>
        /// Gets a record count.
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int GetCount(string procName, List<DbParameter> parms)
        {
            return GetScalar(procName, parms).AsInt();
        }

        /// <summary>
        /// Gets any scalar value from the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object GetScalar(string sql, CommandType commandType, List<DbParameter> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = commandType;
                    command.SetParameters(parms);

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }

        }

        public static List<String> ReadList(string sql, CommandType commandType, List<DbParameter> parms)
        {

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = commandType;
                    command.SetParameters(parms);

                    connection.Open();

                    var list = new List<String>();
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                        for (int i = 0; i < reader.FieldCount; i++)
                            list.Add(reader.GetValue(i).ToString());

                    return list;
                }
            }

        }

        /// <summary>
        /// Gets any scalar value from the database.
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object GetScalar(string procName, List<DbParameter> parms)
        {
            return GetScalar(procName, CommandType.StoredProcedure, parms);
        }

        #endregion

        #region Data update section

        /// <summary>
        /// Inserts an item into the database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int Insert(string sql, CommandType commandType, List<DbParameter> parms)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = commandType;
                    command.SetParameters(parms);
                    command.CommandText = sql;

                    connection.Open();

                    return command.ExecuteScalar().AsInt();
                }
            }
        }

        /// <summary>
        /// Inserts an item into the database
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int Insert(string procName, List<DbParameter> parms)
        {
            return Insert(procName, CommandType.StoredProcedure, parms);
        }


        /// <summary>
        /// Valida 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_RuleSet"></param>
        /// <param name="_Entidade"></param>
        /// <returns></returns>
        public static T ValidaAnnotation<T>(String _RuleSet, T _Entidade)
        {
            PropertyInfo[] info = _Entidade.GetType().GetProperties();
            PropertyInfo propErro = _Entidade.GetType().GetProperty("Erro");
            List<String> lstErros = new List<String>();
            List<Entidade.Erros> ListaErros = new List<Erros>();

            foreach (PropertyInfo Propriedade in info)
            {
                object[] objs = Propriedade.GetCustomAttributes(true);

                foreach (object obj in objs)
                {
                    Erros entErro = null;
                    //Valida Requerido da Entidade
                    //***********************************************************************************************************************************************
                    if (obj is Requerido)
                    {
                        if (((Requerido)obj).RuleSet == _RuleSet)
                        {
                            ResourceManager objResource = new ResourceManager("SIC.Persistencia.Base." + ((Requerido)obj).Resource, Assembly.GetExecutingAssembly());
                            object valor = Propriedade.GetValue(_Entidade, null);

                            if (valor == null)
                            {
                                entErro = new Erros(1, Propriedade.Name, objResource.GetString(((Requerido)obj).IDResource));
                                ListaErros.Add(entErro);                                
                            }
                            else if (String.IsNullOrEmpty(valor.ToString()))
                            {
                                entErro = new Erros(2, Propriedade.Name, objResource.GetString(((Requerido)obj).IDResource));
                                ListaErros.Add(entErro);                                
                            }

                        }
                    }
                    //***********************************************************************************************************************************************
                    //Fim de validação do objeto requerido

                    //Valida o Tamanho da String
                    //***********************************************************************************************************************************************
                    if (obj is TamanhoString)
                    {
                        if (((TamanhoString)obj).RuleSet == _RuleSet)
                        {
                            ResourceManager objResource = new ResourceManager("SIC.Persistencia.Base." + ((TamanhoString)obj).Resource, Assembly.GetExecutingAssembly());
                            object valor = Propriedade.GetValue(_Entidade, null);

                            if (valor == null)
                            {
                                entErro = new Erros(7, Propriedade.Name, objResource.GetString(((TamanhoString)obj).IDResource));
                                ListaErros.Add(entErro);
                            }
                            else if ( valor.ToString().Length < ((TamanhoString)obj).Tamanho)
                            {
                                entErro = new Erros(8, Propriedade.Name, objResource.GetString(((TamanhoString)obj).IDResource));
                                ListaErros.Add(entErro);
                            }
                        }
                    }
                    //***********************************************************************************************************************************************


                    //Valida o Cpf
                    //***********************************************************************************************************************************************
                    if (obj is CPF)
                    {
                        if (((CPF)obj).RuleSet == _RuleSet)
                        {
                            ResourceManager objResource = new ResourceManager("SIC.Persistencia.Base." + ((CPF)obj).Resource, Assembly.GetExecutingAssembly());
                            object valor = Propriedade.GetValue(_Entidade, null);

                            if (valor == null)
                            {
                                entErro = new Erros(3, Propriedade.Name, objResource.GetString(((CPF)obj).IDResource));
                                ListaErros.Add(entErro);
                            }
                            else if (ValidaCPF(valor.ToString()) == false)
                            {
                                entErro = new Erros(4, Propriedade.Name, objResource.GetString(((CPF)obj).IDResource));
                                ListaErros.Add(entErro);
                            }
                        }
                    }
                    //***********************************************************************************************************************************************
                    // Fim da validação do CPF


                    //Valida o CNPJ
                    //***********************************************************************************************************************************************
                    if (obj is CNPJ)
                    {
                        if (((CNPJ)obj).RuleSet == _RuleSet)
                        {
                            ResourceManager objResource = new ResourceManager("SIC.Persistencia.Base." + ((CNPJ)obj).Resource, Assembly.GetExecutingAssembly());
                            object valor = Propriedade.GetValue(_Entidade, null);

                            if (valor == null)
                            {
                                entErro = new Erros(5, Propriedade.Name, objResource.GetString(((CNPJ)obj).IDResource));
                                ListaErros.Add(entErro);
                            }
                            else if (ValidaCNPJ(valor.ToString()))
                            {
                                entErro = new Erros(6, Propriedade.Name, objResource.GetString(((CNPJ)obj).IDResource));
                                ListaErros.Add(entErro);
                            }

                        }
                    }
                    //***********************************************************************************************************************************************
                    //Fim da validação do CNPJ


                    //Valida expressão Regular
                    //***********************************************************************************************************************************************
                    if (obj is ExpressaoRegular)
                    {
                        if (((ExpressaoRegular)obj).RuleSet == _RuleSet)
                        {
                            ResourceManager objResource = new ResourceManager("SIC.Persistencia.Base." + ((ExpressaoRegular)obj).Resource, Assembly.GetExecutingAssembly());
                            object valor = Propriedade.GetValue(_Entidade, null);

                            if (valor == null)
                            {
                                entErro = new Erros(7, Propriedade.Name, objResource.GetString(((ExpressaoRegular)obj).IDResource));
                                ListaErros.Add(entErro);
                            }
                            else 
                            {
                                Regex regex = new System.Text.RegularExpressions.Regex(((ExpressaoRegular)obj).Expressao);
                                if (!regex.IsMatch(valor.ToString()))
                                {
                                    entErro = new Erros(8, Propriedade.Name, objResource.GetString(((ExpressaoRegular)obj).IDResource));
                                    ListaErros.Add(entErro);
                                } 
                               
                            }

                        }
                    }
                    //***********************************************************************************************************************************************
                    //Fim da Expressao Regular
                    
                }

                if (ListaErros.Count >= 1)
                    _Entidade.GetType().GetProperty("Erro").SetValue(_Entidade, ListaErros);
            }

            return _Entidade;
        }


        /// <summary>
        /// Valida o CPF
        /// </summary>
        /// <param name="_valueCpf"></param>
        /// <returns></returns>
        private static Boolean ValidaCPF(String _valueCpf)
        {
            // Caso coloque todos os numeros iguais
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            _valueCpf = _valueCpf.Trim();
            _valueCpf = _valueCpf.Replace(".", "").Replace("-", "");

            if (_valueCpf.Length != 11)
                return false;

            tempCpf = _valueCpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return _valueCpf.EndsWith(digito);            
        }

        /// <summary>
        /// Valida CNPJ
        /// </summary>
        /// <param name="_valueCNPJ"></param>
        /// <returns></returns>
        private static Boolean ValidaCNPJ(String _valueCNPJ)
        {
            // Se vazio

            if (_valueCNPJ.Length == 0)
                return false;
            
            // Limpa caracteres especiais
            _valueCNPJ = _valueCNPJ.Trim();
            _valueCNPJ = _valueCNPJ.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "");
            _valueCNPJ = _valueCNPJ.Replace("+", "").Replace("*", "").Replace(",", "").Replace("?", "");
            _valueCNPJ = _valueCNPJ.Replace("!", "").Replace("@", "").Replace("#", "").Replace("$", "");
            _valueCNPJ = _valueCNPJ.Replace("%", "").Replace("¨", "").Replace("&", "").Replace("(", "");
            _valueCNPJ = _valueCNPJ.Replace("=", "").Replace("[", "").Replace("]", "").Replace(")", "");
            _valueCNPJ = _valueCNPJ.Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
            _valueCNPJ = _valueCNPJ.Replace("<", "").Replace(">", "").Replace("ç", "").Replace("Ç", "");

          


            // Se o tamanho for < 11 entao retorna como inválido

            if (_valueCNPJ.Length != 14)
                return false;


            // Caso coloque todos os numeros iguais

            switch (_valueCNPJ)
            {       //00000000000000

                case "11111111111111":
                    return false;

                case "00000000000000":
                    return false;

                case "22222222222222":
                    return false;

                case "33333333333333":
                    return false;

                case "44444444444444":
                    return false;

                case "55555555555555":
                    return false;

                case "66666666666666":
                    return false;

                case "77777777777777":
                    return false;

                case "88888888888888":
                    return false;

                case "99999999999999":
                    return false;

            }


            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            _valueCNPJ = _valueCNPJ.Trim();
            _valueCNPJ = _valueCNPJ.Replace(".", "").Replace("-", "").Replace("/", "");

            if (_valueCNPJ.Length != 14)
                return false;

            tempCnpj = _valueCNPJ.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return _valueCNPJ.EndsWith(digito);

        }


        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        public static void Update(string sql, CommandType commandType, List<DbParameter> parms)
        {

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = commandType;
                    command.SetParameters(parms);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }

        /// <summary>
        /// Updates an item in the database
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parms"></param>
        public static void Update(string procName, List<DbParameter> parms)
        {
            Update(procName, CommandType.StoredProcedure, parms);
        }
        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parms"></param>
        public static void Delete(string sql, List<DbParameter> parms)
        {
            Update(sql, parms);
        }

        #endregion

        #region Extension methods

        /// <summary>
        /// Extension method: Appends the db specific syntax to sql string 
        /// for retrieving newly generated identity (autonumber) value.
        /// </summary>
        /// <param name="sql">The sql string to which to append syntax.</param>
        /// <returns>Sql string with identity select.</returns>
        private static string AppendIdentitySelect(this string sql)
        {
            switch (dataProvider)
            {
                // Microsoft Access does not support multistatement batch commands
                case "System.Data.OleDb": return sql;
                case "System.Data.SqlClient": return sql + ";SELECT SCOPE_IDENTITY()";
                case "System.Data.OracleClient": return sql + ";SELECT MySequence.NEXTVAL FROM DUAL";
                default: return sql + ";SELECT @@IDENTITY";
            }
        }


        public static string[] GetParameterProcedure(string procedureName)
        {
            List<string> ret = new List<string>();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();
                var result = connection.GetSchema("ProcedureParameters");
                var view = result.DefaultView;
                view.RowFilter = string.Format("SPECIFIC_NAME = '{0}'", procedureName);
                foreach (DataRowView item in view)
                {
                    ret.Add(item["PARAMETER_NAME"].AsString());
                }

                return ret.ToArray();
            }

        }

        public static void SetParameters(this DbCommand command, List<DbParameter> parameters)
        {
            if (parameters != null && command != null)
            {
                foreach (DbParameter param in parameters)
                {
                    command.Parameters.Add(param);
                }
            }
        }

        private static void SetParameters(this DbCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                // NOTE: Processes a name/value pair at each iteration
                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = parms[i].ToString();

                    // No empty strings to the database
                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                        parms[i + 1] = null;

                    // If null, set to DbNull
                    object value = parms[i + 1] ?? DBNull.Value;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);
                }
            }
        }

        public static DbParameter CreateParameter(string name, object value)
        {
            DbParameter param = factory.CreateParameter();
            param.ParameterName = name;
            param.Value = value ?? DBNull.Value;

            return param;
        }

        #endregion

        private static int GravarLogExecucao(int? CodigoOrgao, int? CodigoUsuario, string IP, string nomeProcedure, string Parametros)
        {
            List<DbParameter> parms = new List<DbParameter>();
            parms.Add(Db.CreateParameter("@ID_ORGAO", CodigoOrgao));
            parms.Add(Db.CreateParameter("@CD_USUARIO", CodigoUsuario));
            parms.Add(Db.CreateParameter("@DS_IP", IP));
            parms.Add(Db.CreateParameter("@DS_PROCEDURE", nomeProcedure));
            parms.Add(Db.CreateParameter("@DS_PARAMETROS", Parametros));

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.SetParameters(parms);
                    command.CommandText = "P_INSERIR_LOG";

                    connection.Open();

                    return command.ExecuteScalar().AsInt();
                }
            }
        }

        private static void AtualizarLogExecucao(int CodigoLog, String Erro)
        {
            List<DbParameter> parms = new List<DbParameter>();
            parms.Add(Db.CreateParameter("@ID_LOG", CodigoLog));
            parms.Add(Db.CreateParameter("@DS_ERROR", Erro));

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (var command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.SetParameters(parms);
                    command.CommandText = "P_ALTERAR_LOG";

                    connection.Open();

                    command.ExecuteScalar().AsInt();
                }
            }
        }
    }
}
