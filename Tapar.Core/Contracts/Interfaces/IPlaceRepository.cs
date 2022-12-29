﻿
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces
{
    [ScopedService]
    public interface IPlaceRepository : IRepository<Place>
    {
        #region General
        Task AddPlace(PlaceAddDto dto, CancellationToken cancellationToken);
        Task<List<Place>> SearchPlace(SearchParams searchParams, CancellationToken cancellationToken);
        Task<int?> AddLikeForPlace(long placeId, CancellationToken cancellationToken);
        Task AddView(long placeId, CancellationToken cancellationToken);
        #endregion

        #region UserPanel
        Task<List<Place>> GetPlacesByUserId(long userid, CancellationToken cancellationToken);
        Task<Place> GetPlaceCurrentCategory(long placeid, CancellationToken cancellationToken);
        Task<GetPlaceForEditAddressDto> GetPlaceForEditAddress(long placeId, CancellationToken cancellationToken);
        #endregion

        //Task<PlaceGetDto> GetPlaceById(long id, CancellationToken cancellationToken);
    }
}
