using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUsersCommand(string username, string password, string role, string storelocationid ) : IRequest<bool>
    {
        public int UserId { get; }
        public string Username { get; } = username;        
        public string HashPassword { get; } = password;

        public string Role { get; } = role;

        public string StoreLocationId { get; } = storelocationid;
    }
}
