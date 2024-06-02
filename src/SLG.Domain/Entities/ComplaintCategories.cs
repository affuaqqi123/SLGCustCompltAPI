using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Domain.Entities
{
    public class ComplaintCategories
    {
        public ComplaintCategories()
        {
                
        }
        public int complaintCategoryId { get; set; } 
        public string? complaintCategoryDescription { get; set; }
    }
}