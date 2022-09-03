using Microsoft.EntityFrameworkCore;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
using TaparApi.Data;
using TaparApi.Data.Contracts.Repositories;

namespace Tapar.Core.Contracts.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(TaparDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Location>> GetLocationsByParentId(int id, CancellationToken cancellationToken)
        {
            return await TableNoTracking
                .Where(l => l.parentId == id).ToListAsync(cancellationToken);
        }
    }
}
