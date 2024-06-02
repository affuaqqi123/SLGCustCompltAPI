using MediatR;
using SLG.Domain.Repositories.Interfaces;
using SLG.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Features.StoreLocation
{
    public class GetAllStoreLocationQueryHandler : IRequestHandler<GetAllStoreLocationQuery, List<StoreLocationResponseDto>>
    {
        private readonly IStoreLocationRepository _repository;

        public GetAllStoreLocationQueryHandler(IStoreLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StoreLocationResponseDto>> Handle(GetAllStoreLocationQuery query, CancellationToken cancellationToken)
        {
            var storeLocation = await _repository.GetAllStoreLocationAsync();

            return storeLocation.Select(storeLocations => new StoreLocationResponseDto
            {
                StoreLocationId = storeLocations.StoreLocationId,
                StoreName = storeLocations.StoreName
            }).ToList();
        }
    }
}