using MediatR;
using SLG.Shared.DTOs;

namespace SLG.Application.Features.Complaints.Commands.CreateComplaints
{
    public class CreateCustomerComplaintCommand(
       string employeeID, string employeeName, string firstName, string surName, string mobileNumber, string email, string customerAddress1, string customerAddress2, string city, string postalCode, string sku, string brandName, string orderNo, int complaintCategoryId, string storeLocationId, DateTime dateofPurchase, DateTime dateofComplaint, DateTime faultDetectionDate, string natureOfComplaint, string remedyRequestedByCustomer, int productImagesId, string comments, string createdBy, string updatedBy, DateTime creationDate, DateTime modificationDate) : IRequest<int>
    {
        public int Id { get; }
        public string EmployeeId { get; } = employeeID;

        public string EmployeeName { get; } = employeeName;

        public string FirstName { get; } = firstName;

        public string SurName { get; } = surName;
        public string MobileNumber { get; } = mobileNumber;

        public string Email { get; } = email;

        public string CustomerAddress1 { get; } = customerAddress1;
        public string CustomerAddress2 { get; } = customerAddress2;

        public string City { get; } = city;
        public string Postalcode { get; } = postalCode;

        public string Sku { get; } = sku;

        public string BrandName { get; } = brandName;
        public string OrderNo { get; } = orderNo;
        public int ComplaintCategoryId { get; } = complaintCategoryId;
        public string StoreLocationId { get; } = storeLocationId;

        public DateTime DateofPurchase { get; } = dateofPurchase;

        public DateTime DateofComplaint { get; } = dateofComplaint;
        public DateTime FaultDetectionDate { get; } = faultDetectionDate;

        public string NatureOfComplaint { get; } = natureOfComplaint;

        public string RemedyRequestedByCustomer { get; } = remedyRequestedByCustomer;

        public int ProductImagesId { get; } = productImagesId;

        public string Comments { get; } = comments;

        public string CreatedBy { get; } = createdBy;

        public string UpdatedBy { get; } = updatedBy;

        public DateTime CreationDate { get; } = creationDate;

        public DateTime ModificationDate { get; } = modificationDate;


    }
}
