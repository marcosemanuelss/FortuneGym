using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Persistencia.Base
{
    class Transacao
    {
        private SqlCommand command;
        private SqlTransaction trans;
        private SqlConnection conn;

        public Transacao()
        {
            this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ADO.NET.SqlServer"].ConnectionString);

            conn.Open();

            this.command = conn.CreateCommand();
            this.trans = conn.BeginTransaction();
            command.Connection = conn;
            command.Transaction = trans;
        }

        public SqlCommand GetCommand()
        {
            return command;
        }

        public void Commit()
        {
            trans.Commit();
        }

        public void Rollback()
        {
            trans.Rollback();
        }

        public void CloseConnection()
        {
            conn.Close();
        }
    }
}
