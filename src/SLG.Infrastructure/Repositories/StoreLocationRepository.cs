using Dapper;
using Microsoft.Extensions.Configuration;
using SLG.Domain.Entities;
using SLG.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Infrastructure.Repositories
{
    public class StoreLocationRepository : IStoreLocationRepository
    {
        private readonly string _connectionString;
        public StoreLocationRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SLGComplaintConnectionString");
        }

        public async Task<IReadOnlyList<StoreLocations>> GetAllStoreLocationAsync()
        {
            const string sql = "SELECT * FROM StoreLocations";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<StoreLocations>(sql);
                return result.ToList();
            }
        }

    }


}