using MediatR;
using SLG.Application.Features.Complaints;
using SLG.Domain.Entities;
using SLG.Domain.Repositories.Interfaces;
using SLG.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.ComplaintCategory.Queries.GetComplaintCategory
{
    public class GetAllComplaintCategoryQueryHandler : IRequestHandler<GetAllComplaintCategoryQuery, List<ComplaintCategoryResponseDto>>
    {
        private readonly IComplaintCategoryRepository _repository;

        public GetAllComplaintCategoryQueryHandler(IComplaintCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ComplaintCategoryResponseDto>> Handle(GetAllComplaintCategoryQuery query, CancellationToken cancellationToken)
        {
            var complaintCategory = await _repository.GetAllCompalintCategoryAsync();

            return complaintCategory.Select(complaintscategory => new ComplaintCategoryResponseDto
            {
                complaintCategoryId= complaintscategory.complaintCategoryId,
                complaintCategoryDescription = complaintscategory.complaintCategoryDescription

            }).ToList();
        }
    }
}
