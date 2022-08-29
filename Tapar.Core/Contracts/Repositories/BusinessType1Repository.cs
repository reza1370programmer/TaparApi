using Microsoft.EntityFrameworkCore;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class BusinessType1Repository:Repository<Cat1>,IBusinessType1Repsitory
{
    public BusinessType1Repository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Cat1>> GetBusinessByBusinessCategoriId(long id,CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(c => c.Id == id).ToListAsync(cancellationToken);
    }
}