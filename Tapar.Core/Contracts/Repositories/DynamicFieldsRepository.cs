using Microsoft.EntityFrameworkCore;
using TaparApi.Data.Common;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class DynamicFieldsRepository : Repository<SpecialTypeField>, IDynamicFieldsRepsitory
{
    public DynamicFieldsRepository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<SpecialTypeField>> GetDynamicFieldsByBusinessType1Id(long id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(d => d.businessType1Id == id).ToListAsync(cancellationToken);
    }

    public async Task<List<SpecialTypeField>> GetDynamicFieldsByBusinessType2Id(long id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(d => d.businessType2Id == id).ToListAsync(cancellationToken);

    }
}