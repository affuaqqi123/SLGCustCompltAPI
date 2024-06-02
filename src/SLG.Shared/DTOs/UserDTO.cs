using SLG.Domain.Entities;
using SLG.Shared.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Shared.DTOs
{
    public class UserDTO : IMapFrom<User>
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;       

        public string HashPassword { get; set; } = null!;

        public string Role { get; set; } = null!;

        public string StoreLocationId { get; set; } = null!;
    }
}
