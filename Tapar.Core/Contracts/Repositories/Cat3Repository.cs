
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class Cat3Repository : Repository<Cat3>, ICat3Repository
{
    public Cat3Repository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Cat3>> GetCat3sByCat2Id(int id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(c => c.cat2Id == id).ToListAsync(cancellationToken);
    }
}