
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface ICat2Repsitory:IRepository<Cat2>
{
    public Task<List<Cat2>> GetCat2sByCat1Id(int id,CancellationToken cancellationToken);
    public Task<IEnumerable<Filters>> GetCat2Filters(int cat2Id,CancellationToken cancellationToken);
    public Task AddCat2(AddCat2Dto addCat2Dto, CancellationToken cancellationToken);
}