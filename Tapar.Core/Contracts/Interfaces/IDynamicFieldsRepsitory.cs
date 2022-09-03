﻿

using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface IDynamicFieldsRepsitory:IRepository<SpecialTypeField>
{
    Task<List<SpecialTypeField>> GetDynamicFieldsByBusinessType1Id(long id,CancellationToken cancellationToken);
    Task<List<SpecialTypeField>> GetDynamicFieldsByBusinessType2Id(long id,CancellationToken cancellationToken);
}