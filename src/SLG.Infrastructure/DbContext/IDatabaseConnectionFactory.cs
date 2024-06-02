using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Infrastructure.Data
{
    public interface IDatabaseConnectionFactory
    {
        Task<SqlConnection> CreateConnectionAsync(); 
    }
}
