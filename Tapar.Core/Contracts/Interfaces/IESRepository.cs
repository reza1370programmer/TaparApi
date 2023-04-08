

using Nest;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos;
using Tapar.Data.Entities;
using Tapar.Data.ES_Entities;

namespace Tapar.Core.Contracts.Interfaces
{
    public interface IESRepository
    {
        Task AddPlaceIndex(Place place);
        Task<ISearchResponse<PlaceIndex>> SearchPlaces(SearchParams dto,CancellationToken cancellationToken);
        public void CopyDataToElastic(List<PlaceIndex> documents);
    }
}
