using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Domain.Entities
{
    public class User
    {
        public User()
        {
            
        }
        public User(string username, string passwordHash, string role, string storelocationid)
        {
            Username = username;            
            HashPassword = passwordHash;
            Role = role;
            StoreLocationId = storelocationid;
        }
        public string Username { get; set; } = null!;        
        public string HashPassword { get; set; } = null!;

        public string Role { get; set; } = null!;
        public string StoreLocationId { get; set;} = null!;

    }
}
