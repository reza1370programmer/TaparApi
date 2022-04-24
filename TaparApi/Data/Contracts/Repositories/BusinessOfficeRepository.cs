using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Utilities;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class BusinessOfficeRepository:Repository<BusinessOffice>,IBusinessOfficeRepository
{
    public BusinessOfficeRepository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<string> getTaparKey( CancellationToken cancellationToken)
    {
        var key = GenerateUniqeKey.GenerateUniqueKey();
       
        var result = await TableNoTracking.AnyAsync(k => k.gKey == key, cancellationToken);
        while (result)
        {
             key = GenerateUniqeKey.GenerateUniqueKey();

             result = await TableNoTracking.AnyAsync(k => k.gKey == key, cancellationToken);
        }
        return key;
    }

    public async Task<List<BusinessOffice>> GetBusinessOfficesByUserId(long userId)
    {
      return await TableNoTracking.Where(b => b.userId == userId).ToListAsync();
    }
}