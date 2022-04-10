﻿using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessType2Repository:IRepository<BusinessType2>
{
    public Task<List<BusinessType2>> GetBusinessType2sByBusinessType1Id(long id, CancellationToken cancellationToken);

}