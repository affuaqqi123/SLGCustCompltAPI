using Dapper;
using Microsoft.Extensions.Configuration;
using SLG.Domain.Entities;
using SLG.Domain.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using System.Data;

namespace SLG.Infrastructure.Repositories
{
    public class UsersRepository : IUsersInterface
    {
        private readonly string _connectionString;

        public UsersRepository(IConfiguration configuration)
        {
            //_connectionString = configuration.GetConnectionString("SLGComplaintConnectionString");
            _connectionString = configuration.GetConnectionString("SLGComplaintConnectionString")
               ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");            
        }

        public async Task<User> AddUserAsync(User user)
        {
            user.HashPassword = BCrypt.Net.BCrypt.HashPassword(user.HashPassword);

            using (var connection = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                try
                {
                    parameters.Add("@Username", user.Username);                    
                    parameters.Add("@HashPassword", user.HashPassword);
                    parameters.Add("@Role", user.Role);
                    parameters.Add("@StoreLocationId", user.StoreLocationId);



                    connection.ExecuteScalar("AddUser_SP", parameters, commandType: CommandType.StoredProcedure);
                    return user;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<User> CheckUserCredentials(string username, string password)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", username);
                //parameters.Add("@HashPassword", BCrypt.Net.BCrypt.HashPassword(password));

                var user = await connection.QuerySingleOrDefaultAsync<User>("GetUserByNameandPassword", parameters, commandType: CommandType.StoredProcedure);
                //var sql = "SELECT * FROM Users WHERE Username = @Username";
                //var user = await connection.QuerySingleOrDefaultAsync<Users>(sql, new { username,password });

                if (user != null && user.Username==username && BCrypt.Net.BCrypt.Verify(password, user.HashPassword))
                {
                    return user;
                }

                return null;
            }
        }
    }
}
