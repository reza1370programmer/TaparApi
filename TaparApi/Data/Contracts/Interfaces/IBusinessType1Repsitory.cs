using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessType1Repsitory:IRepository<BusinessType1>
{
    public Task<List<BusinessType1>> GetBusinessByBusinessCategoriId(long id,CancellationToken cancellationToken);
}