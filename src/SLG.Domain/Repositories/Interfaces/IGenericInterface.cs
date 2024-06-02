using SLG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace SLG.Domain.Repositories.Interfaces
{
    public interface IGenericInterface
    {
        Task<List<CustomerComplaint>> GetAllRecordsAsync();
        Task<CustomerComplaint> FindRecordByIdAsync(int Id);
        Task<List<CustomerComplaint>> GetAllComplaintsByStoreIdAsync(string storeId);
        Task<CustomerComplaint> AddRecordAsync(CustomerComplaint model);
        Task<CustomerComplaint> UpdateRecordAsync(int Id, CustomerComplaint model);
        Task<int> RemoveRecordAsync(int Id);
    }
}
