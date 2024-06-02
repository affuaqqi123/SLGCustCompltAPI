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
    public class ComplaintCategoryRepository : IComplaintCategoryRepository
    {
        private readonly string _connectionString;
        public ComplaintCategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SLGComplaintConnectionString");
        }

        public async Task<List<ComplaintCategories>> GetAllCompalintCategoryAsync()
        {
            const string sql = "SELECT * FROM ComplaintCategories";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<ComplaintCategories>(sql);
                return result.ToList();
            }
        }

    }


}
