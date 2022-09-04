using Microsoft.EntityFrameworkCore;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class DynamicFieldsRepository : Repository<SpecialTypeField>, IDynamicFieldsRepsitory
{
    public DynamicFieldsRepository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<SpecialTypeField>> GetDynamicFieldsByCat2Id(int id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(d => d.cat2Id == id).ToListAsync(cancellationToken);
    }

}