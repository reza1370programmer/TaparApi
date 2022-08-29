
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessType1Repsitory:IRepository<Cat1>
{
    public Task<List<Cat1>> GetBusinessByBusinessCategoriId(long id,CancellationToken cancellationToken);
}