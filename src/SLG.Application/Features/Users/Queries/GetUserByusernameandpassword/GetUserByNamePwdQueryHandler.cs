using MediatR;
using SLG.Application.Features.Complaints.Queries.GetComplaintById;
using SLG.Application.Features.Users.Commands.CreateUsers;
using SLG.Domain.Core;
using SLG.Domain.Repositories.Interfaces;
using SLG.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.Users.Queries.GetUserByusernameandpassword
{
    internal class GetUserByNamePwdQueryHandler : IRequestHandler<GetUserByNamePwdQuery, UserDTO>
    {
        private readonly IUsersInterface _usersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByNamePwdQueryHandler(IUsersInterface repository, IUnitOfWork unitofWork)
        {
            _usersRepository = repository;
            _unitOfWork = unitofWork;
        }

        public async Task<UserDTO> Handle(GetUserByNamePwdQuery query, CancellationToken cancellationToken)
        {

            var usr = await _usersRepository.CheckUserCredentials(query.Username, query.HashPassword);
            if (usr == null) return null;

            return new UserDTO()
            {                
                Username = usr.Username,                
                HashPassword = usr.HashPassword,
                Role= usr.Role,
                StoreLocationId = usr.StoreLocationId
                
            };

        }

    }
}
