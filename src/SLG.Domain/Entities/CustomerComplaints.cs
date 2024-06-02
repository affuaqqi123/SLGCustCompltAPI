using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SLG.Domain.Entities
{
    public class CustomerComplaint:BaseEntity
    {
        public CustomerComplaint()
        {
                
        }
        public CustomerComplaint( string employeeID, string employeeName, string firstName, string surName, string mobileNumber, string email, string customerAddress1, string customerAddress2, string city, string postalCode, string sku, string brandName, string orderNo, int complaintCategoryId, string storeLocationId, DateTime dateofPurchase, DateTime dateofComplaint, DateTime faultDetectionDate, string natureOfComplaint, string remedyRequestedByCustomer, int productImagesId, string comments, string createdBy, string updatedBy, DateTime creationDate, DateTime modificationDate)
        {
            
            EmployeeID = employeeID;
            EmployeeName = employeeName;
            FirstName = firstName;
            SurName = surName;
            MobileNumber = mobileNumber;
            Email = email;
            CustomerAddress1 = customerAddress1;
            CustomerAddress2 = customerAddress2;
            City = city;
            Postalcode = postalCode;
            Sku = sku;
            BrandName = brandName;
            OrderNo = orderNo;
            ComplaintCategoryId = complaintCategoryId;
            StoreLocationId = storeLocationId;
            DateofPurchase = dateofPurchase;
            DateofComplaint = dateofComplaint;
            FaultDetectionDate = faultDetectionDate;
            NatureOfComplaint = natureOfComplaint;
            RemedyRequestedByCustomer = remedyRequestedByCustomer;
            ProductImagesId = productImagesId;
            Comments = comments;
            CreatedBy = employeeID;
            UpdatedBy = employeeID;
            CreationDate = DateTime.UtcNow;
            ModificationDate = DateTime.UtcNow;
        }


       

        public string EmployeeID { get; set; } = null!;

        public string EmployeeName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string SurName { get; set; } = null!;
        public string MobileNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }

        public string City { get; set; }
        public string Postalcode { get; set; }

        public string Sku { get; set; }

        public string BrandName { get; set; }
        public string OrderNo { get; set; }
        public int ComplaintCategoryId { get; set; }
        public string StoreLocationId { get; set; }

        public DateTime DateofPurchase { get; set; }

        public DateTime DateofComplaint { get; set; }
        public DateTime FaultDetectionDate { get; private set; }

        public string NatureOfComplaint { get; private set; }

        public string RemedyRequestedByCustomer { get; set; }

        public int ProductImagesId { get; set; }

        public string Comments { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }

    }
}
