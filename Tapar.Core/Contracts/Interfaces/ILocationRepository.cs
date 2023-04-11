using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces
{
    [ScopedService]
    public interface ILocationRepository : IRepository<Location>
    {
        Task<IEnumerable<Location>> GetLocationsByParentId(int id, CancellationToken cancellationToken);
    }
}
