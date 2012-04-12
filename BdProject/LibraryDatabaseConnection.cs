using System;
using System.Data;
using System.Data.Common;
using System.Text;
using Oracle.DataAccess.Client;

namespace BdProject
{
    class LibraryDatabaseConnection : IDisposable
    {
        private DbConnection connection;

        public bool IsConnected
        {
            get
            {
                return (connection.State & ConnectionState.Open) != 0;
            }
        }

        public LibraryDatabaseConnection()
        {
            connection = new OracleConnection(Properties.Settings.Default.ConnectionString);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public string ExecuteTestCommand()
        {
            var command = connection.CreateCommand();
            command.CommandText = "SELECT nazwa FROM FILO.kraje";
            using (var reader = command.ExecuteReader())
            {
                var builder = new StringBuilder();

                while (reader.Read())
                {
                    builder.Append(reader["nazwa"]).Append("\r\n");
                }

                return builder.ToString();
            }
        }
    }
}
