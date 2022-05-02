﻿using AspNetCore.ServiceRegistration.Dynamic;
using TaparApi.Common.Dtos.BusinessOffice;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IBusinessOfficeRepository:IScopedService,IRepository<BusinessOffice>
{
    public Task<string> getTaparKey(CancellationToken cancellationToken);
    public Task<List<BusinessOffice>> GetBusinessOfficesByUserId(long userId, CancellationToken cancellationToken);
    public Task<bool> AddUpdateDocument(BusinessOfficeUpdateDocumentDto officeUpdate, CancellationToken cancellationToken);
}