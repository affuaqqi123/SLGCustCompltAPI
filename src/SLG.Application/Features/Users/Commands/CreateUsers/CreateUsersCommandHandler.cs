using MediatR;
using SLG.Domain.Core;
using SLG.Domain.Entities;
using SLG.Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand,bool>
    {
        private readonly IUsersInterface _usersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUsersCommandHandler(IUsersInterface repository, IUnitOfWork unitofWork)
        {
            _usersRepository = repository;
            _unitOfWork = unitofWork;
        }

        public async Task<bool> Handle(CreateUsersCommand request, CancellationToken cancellationToken)
        {
            var post = new User(request.Username, request.HashPassword, request.Role, request.StoreLocationId);

            await _usersRepository.AddUserAsync(post);

            _unitOfWork.Commit();

            return true;


        }


    }
}
