using SLG.Domain.Entities;
using SLG.Shared.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Shared.DTOs
{
    public class StoreLocationResponseDto : IMapFrom<StoreLocations>
    {
        public string? StoreLocationId { get; set; }
        public string? StoreName { get; set; }

    }

}