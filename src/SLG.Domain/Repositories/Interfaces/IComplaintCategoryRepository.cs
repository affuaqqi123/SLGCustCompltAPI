using SLG.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Domain.Repositories.Interfaces
{
    public interface IComplaintCategoryRepository
    {
        Task<List<ComplaintCategories>> GetAllCompalintCategoryAsync();
    }
}
