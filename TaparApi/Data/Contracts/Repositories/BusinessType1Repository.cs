using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class BusinessType1Repository:Repository<BusinessType1>,IBusinessType1Repsitory
{
    public BusinessType1Repository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<BusinessType1>> GetBusinessByBusinessCategoriId(long id,CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(c => c.businessCategoryId == id).ToListAsync(cancellationToken);
    }
}