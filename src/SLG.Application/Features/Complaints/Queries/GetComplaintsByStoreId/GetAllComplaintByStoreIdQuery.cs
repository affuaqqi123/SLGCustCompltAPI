using MediatR;
using SLG.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.Complaints.Queries.GetComplaintsByStoreId
{
    public class GetAllComplaintByStoreIdQuery : IRequest<List<CustomersComplaintDto>>
    {
        public string? StoreLocationId { get; set; }
    }
}