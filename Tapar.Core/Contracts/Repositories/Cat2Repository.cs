using Microsoft.EntityFrameworkCore;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class Cat2Repository : Repository<Cat2>, ICat2Repsitory
{
    public Cat2Repository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Filters>> GetCat2Filters(int cat2Id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.SelectMany(p => p.filters_Cat2s)
            .Where(p => p.cat2Id == cat2Id).
            Include(p=>p.filter.childFilters).
            Select(p=>p.filter).AsSplitQuery().ToListAsync();
    }

    public async Task<IEnumerable<Cat2>> GetCat2sByCat1Id(int id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(c => c.cat1Id == id).ToListAsync(cancellationToken);
    }
}