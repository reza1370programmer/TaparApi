
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
        Task<List<Place>> GetPlacesByUserId(SearchParamsForUserPanel dto, CancellationToken cancellationToken);
        Task<GetPlaceForEditAddressDto> GetPlaceForEditAddress(long placeId, CancellationToken cancellationToken);
        Task UpdatePlacePics(PlacePicUpdateDto dto,Place place, CancellationToken cancellationToken);
        Task UpdateModirPic(UpdateModiPicDto dto,Place place, CancellationToken cancellationToken);
        Task UpdateVisitCartPic(UpdateVisitCartPic dto,Place place, CancellationToken cancellationToken);
        Task UpdateWorkTime(UpdateWorkTimeDto dto, CancellationToken cancellationToken);
        Task UpdateGlobalInformation(EditGlobalInformationDto dto, CancellationToken cancellationToken);
        Task DeleteBusiness(long id, CancellationToken cancellationToken);
        #endregion

        //Task<PlaceGetDto> GetPlaceById(long id, CancellationToken cancellationToken);
    }
}
