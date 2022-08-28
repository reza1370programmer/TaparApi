using Microsoft.EntityFrameworkCore;
using TaparApi.Data.Common;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class BusinessType2Repository : Repository<Cat2>, IBusinessType2Repository
{
    public BusinessType2Repository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Cat2>> GetBusinessType2sByBusinessType1Id(long id, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(b => b.businessType1Id == id).ToListAsync(cancellationToken);
    }
}