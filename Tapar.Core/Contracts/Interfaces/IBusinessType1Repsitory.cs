using AspNetCore.ServiceRegistration.Dynamic;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessType1Repsitory:IRepository<Cat1>,IScopedService
{
    public Task<List<Cat1>> GetBusinessByBusinessCategoriId(long id,CancellationToken cancellationToken);
}