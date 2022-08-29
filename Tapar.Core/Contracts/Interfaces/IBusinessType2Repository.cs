
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessType2Repository:IRepository<Cat2>
{
    public Task<List<Cat2>> GetBusinessType2sByBusinessType1Id(long id, CancellationToken cancellationToken);

}