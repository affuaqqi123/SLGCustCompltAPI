using MediatR;
using SLG.Application.Exception;
using SLG.Domain.Core;
using SLG.Domain.Entities;
using SLG.Domain.Repositories.Interfaces;


namespace SLG.Application.Features.Complaints.Commands.UpdateComplaint;

public class UpdateCustomerComplaintCommandHandler : IRequestHandler<UpdateCustomerComplaintCommand, bool>
{
    private readonly IGenericInterface _complaintRepository;
    private readonly IUnitOfWork _unitOfWork;


    public UpdateCustomerComplaintCommandHandler(IGenericInterface repository, IUnitOfWork unitofWork)
    {
        _complaintRepository = repository;
        _unitOfWork = unitofWork;
    }

    public async Task<bool> Handle(UpdateCustomerComplaintCommand request, CancellationToken cancellationToken)
    {
        var complaint = await _complaintRepository.FindRecordByIdAsync(request.Id);
        if (complaint == null)
        {
            throw new NotFoundException(nameof(CustomerComplaint), nameof(CustomerComplaint.Id), request.Id);
        }

        // complaint.EditEntity(request.EmployeeId, request.EmployeeName, request.FirstName, request.SurName, request.MobileNumber, request.Email, request.CustomerAddress1, request.CustomerAddress2, request.City, request.Postalcode, request.Sku, request.BrandName, request.OrderNo, request.ComplaintCategoryId, request.StoreLocationId, request.DateofPurchase, request.DateofComplaint, request.FaultDetectionDate, request.NatureOfComplaint, request.RemedyRequestedByCustomer, request.ProductImagesId, request.Comments, request.CreatedBy, request.UpdatedBy, request.CreationDate, request.ModificationDate);

        _unitOfWork.Commit();

        return true;
    }
}
