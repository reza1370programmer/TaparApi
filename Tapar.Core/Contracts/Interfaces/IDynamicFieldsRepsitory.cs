

using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface IDynamicFieldsRepsitory:IRepository<SpecialTypeField>
{
    Task<List<SpecialTypeField>> GetDynamicFieldsByCat2Id(int id,CancellationToken cancellationToken);
}