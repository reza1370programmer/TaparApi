
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces
{
    [ScopedService]
    public interface IPlaceRepository:IRepository<Place>
    {
        Task AddPlace(PlaceAddDto dto,CancellationToken cancellationToken);
        Task<List<Place>> SearchPlace(SearchParams searchParams,CancellationToken cancellationToken);
        Task<PlaceGetDto> GetPlaceById(long id, CancellationToken cancellationToken);
    }
}
