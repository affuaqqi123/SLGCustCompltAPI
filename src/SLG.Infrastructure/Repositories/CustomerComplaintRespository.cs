using Dapper;
using SLG.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using SLG.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using SLG.Shared.DTOs;

namespace SLG.Infrastructure.Repositories
{
    public class CustomerComplaintRespository : IGenericInterface
    {
        private readonly string _connectionString;

        public CustomerComplaintRespository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SLGComplaintConnectionString");

        }

        public async Task<CustomerComplaint> AddRecordAsync(CustomerComplaint complaints)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                try
                {
                    parameters.Add("@EmployeeID", complaints.EmployeeID);
                    parameters.Add("@EmployeeName", complaints.EmployeeName);
                    parameters.Add("@FirstName", complaints.FirstName);
                    parameters.Add("@SurName", complaints.SurName);
                    parameters.Add("@MobileNumber", complaints.MobileNumber);
                    parameters.Add("@Email", complaints.Email);
                    parameters.Add("@CustomerAddress1", complaints.CustomerAddress1);
                    parameters.Add("@CustomerAddress2", complaints.CustomerAddress2);
                    parameters.Add("@City", complaints.City);
                    parameters.Add("@Postalcode", complaints.Postalcode);
                    parameters.Add("@Sku", complaints.Sku);
                    parameters.Add("@BrandName", complaints.BrandName);
                    parameters.Add("@OrderNo", complaints.OrderNo);
                    parameters.Add("@ComplaintCategoryId", complaints.ComplaintCategoryId);
                    parameters.Add("@StoreLocationId", complaints.StoreLocationId);
                    parameters.Add("@DateofPurchase", complaints.DateofPurchase);
                    parameters.Add("@DateofComplaint", complaints.DateofComplaint);
                    parameters.Add("@FaultDetectionDate", complaints.FaultDetectionDate);
                    parameters.Add("@NatureOfComplaint", complaints.NatureOfComplaint);
                    parameters.Add("@RemedyRequestedByCustomer", complaints.RemedyRequestedByCustomer);
                    parameters.Add("@ProductImagesId", complaints.ProductImagesId);
                    parameters.Add("@Comments", complaints.Comments);
                    parameters.Add("@CreatedBy", complaints.CreatedBy);
                    parameters.Add("@UpdatedBy", complaints.UpdatedBy);
                    parameters.Add("@CreationDate", complaints.CreationDate);
                    parameters.Add("@ModificationDate", complaints.ModificationDate);


                    connection.ExecuteScalar("AddCustomerComplaint", parameters, commandType: CommandType.StoredProcedure);
                    return complaints;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }

        public async Task<CustomerComplaint> FindRecordByIdAsync(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var custComplaint = await connection.QuerySingleOrDefaultAsync<CustomerComplaint>("GetComplaintByComplaintId", new { Id }, commandType: CommandType.StoredProcedure);
                    return custComplaint;   
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<List<CustomerComplaint>> GetAllRecordsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var custComplaints = await connection.QueryAsync<CustomerComplaint>("GetAllCustomerComplaints", commandType: CommandType.StoredProcedure);
                    return custComplaints.ToList();
                   
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<List<CustomerComplaint>?> GetAllComplaintsByStoreIdAsync(string Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var custComplaints = await connection.QueryAsync<CustomerComplaint>("GetAllComplaintByStoreId", new {Id }, commandType: CommandType.StoredProcedure);
                    return custComplaints.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public async Task<CustomerComplaint> UpdateRecordAsync(int Id, CustomerComplaint complaints)
        {

            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", complaints.EmployeeID);
            parameters.Add("@EmployeeName", complaints.EmployeeName);
            parameters.Add("@FirstName", complaints.FirstName);
            parameters.Add("@SurName", complaints.SurName);
            parameters.Add("@Email", complaints.Email);
            parameters.Add("@MobileNumber", complaints.MobileNumber);

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    var compaints = connection.ExecuteAsync("UpdateCustomerComplaint", parameters, commandType: CommandType.StoredProcedure);
                    return complaints;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
        }
        public async Task<int> RemoveRecordAsync(int Id)
        {


            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.ExecuteAsync("DeleteCustomerComplaint", new { Id }, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex);
                }

            }
        }


    }

}

