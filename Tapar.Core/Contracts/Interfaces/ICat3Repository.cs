
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces;

public interface ICat3Repository:IRepository<Cat3>
{
    public Task<IEnumerable<Cat3>> GetCat3sByCat2Id(int id, CancellationToken cancellationToken);

}