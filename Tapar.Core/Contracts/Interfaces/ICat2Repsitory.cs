
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface ICat2Repsitory:IRepository<Cat2>
{
    public Task<IEnumerable<Cat2>> GetCat2sByCat1Id(int id,CancellationToken cancellationToken);
    public Task<IEnumerable<Filters>> GetCat2Filters(int cat2Id,CancellationToken cancellationToken);   
}