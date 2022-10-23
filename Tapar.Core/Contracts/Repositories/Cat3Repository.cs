
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class Cat3Repository : Repository<Cat3>, ICat3Repository
{
    public ICat2Repsitory cat2Repsitory { get; set; }

    public Cat3Repository(TaparDbContext dbContext, ICat2Repsitory cat2Repsitory) : base(dbContext)
    {
        this.cat2Repsitory = cat2Repsitory;
    }

    public async Task<IEnumerable<Filters>> GetCat2FiltersByCat3Id(int id, CancellationToken cancellation)
    {
        var cat2Id = (await GetByIdAsync(cancellation, id)).cat2Id;
        var filters = await cat2Repsitory.GetCat2Filters(cat2Id, cancellation);
        return filters;
     
    }

    public async Task<IEnumerable<Cat3>> GetCat3sByCat2Id(int id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(c => c.cat2Id == id).ToListAsync(cancellationToken);
    }
}