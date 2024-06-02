using MediatR;
using SLG.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.Users.Queries.GetUserByusernameandpassword
{
    public class GetUserByNamePwdQuery : IRequest<UserDTO>
    {
        public string Username { get; set; }
        public string HashPassword { get; set; }

    }
}
