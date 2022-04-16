using AspNetCore.ServiceRegistration.Dynamic;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessType1Repsitory:IRepository<BusinessType1>,IScopedService
{
    public Task<List<BusinessType1>> GetBusinessByBusinessCategoriId(long id,CancellationToken cancellationToken);
}