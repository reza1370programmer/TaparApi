
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces;

public interface ICat2Repsitory:IRepository<Cat2>
{
    public Task<IEnumerable<Cat2>> GetCat2sByCat1Id(int id,CancellationToken cancellationToken);
}