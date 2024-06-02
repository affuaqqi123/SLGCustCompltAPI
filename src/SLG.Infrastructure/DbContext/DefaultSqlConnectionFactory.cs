using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Infrastructure.Data
{
    public class DefaultSqlConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;

        public DefaultSqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString ?? string.Empty;   
        }

        public async Task<SqlConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            if (sqlConnection.State != ConnectionState.Open) await sqlConnection.OpenAsync();
            return sqlConnection;
        }

       
    }
}
