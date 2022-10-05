
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
using TaparApi.Data;
using TaparApi.Data.Contracts.Repositories;

namespace Tapar.Core.Contracts.Repositories
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        public PlaceRepository(TaparDbContext dbContext) : base(dbContext)
        {

        }
    }
}
