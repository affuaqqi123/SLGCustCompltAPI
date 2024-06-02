using SLG.Domain.Entities;
using SLG.Shared.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Shared.DTOs
{
    public class CustomersComplaintDto:IMapFrom<CustomerComplaint>    
    {      
        public int Id { get; set; }
        public string EmployeeId { get; set; } = null!;

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
        public DateTime FaultDetectionDate { get;  set; }

        public string NatureOfComplaint { get;  set; }

        public string RemedyRequestedByCustomer { get; set; }

        public int ProductImagesId { get; set; }

        public string Comments { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModificationDate { get; set; }


    }
}
