
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IDynamicFieldsRepsitory:IRepository<SpecialTypeField>
{
    Task<List<SpecialTypeField>> GetDynamicFieldsByBusinessType1Id(long id,CancellationToken cancellationToken);
    Task<List<SpecialTypeField>> GetDynamicFieldsByBusinessType2Id(long id,CancellationToken cancellationToken);
}