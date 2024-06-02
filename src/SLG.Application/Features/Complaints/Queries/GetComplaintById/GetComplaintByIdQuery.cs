using MediatR;
using SLG.Shared.DTOs;

namespace SLG.Application.Features.Complaints.Queries.GetComplaintById;

public class GetComplaintByIdQuery : IRequest<CustomersComplaintDto>
{
    public int Id { get; set; }
}