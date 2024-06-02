using SLG.Domain.Entities;
using SLG.Shared.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Shared.DTOs
{
    public class ComplaintCategoryResponseDto : IMapFrom<ComplaintCategories>
    {
        public int complaintCategoryId { get; set; }
        public string? complaintCategoryDescription { get; set; }
    }
}
