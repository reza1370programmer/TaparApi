using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IDynamicFieldsRepsitory:IRepository<SpecialTypeField>
{
    Task<List<SpecialTypeField>> GetDynamicFieldsByBusinessType1Id(long id,CancellationToken cancellationToken);
}