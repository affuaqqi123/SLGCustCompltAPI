using MediatR;
using SLG.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.ComplaintCategory.Queries
{
    public class GetAllComplaintCategoryQuery : IRequest<List<ComplaintCategoryResponseDto>>
    {
    }
}
