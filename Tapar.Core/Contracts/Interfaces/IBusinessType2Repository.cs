using AspNetCore.ServiceRegistration.Dynamic;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessType2Repository:IRepository<Cat2>, IScopedService
{
    public Task<List<Cat2>> GetBusinessType2sByBusinessType1Id(long id, CancellationToken cancellationToken);

}