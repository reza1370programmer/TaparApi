﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Dtos.BusinessOffice;
using TaparApi.Common.Utilities;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class BusinessOfficeRepository : Repository<BusinessOffice>, IBusinessOfficeRepository
{
    public IMapper Mapper { get; set; }
    public BusinessOfficeRepository(TaparDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        Mapper = mapper;
    }

    public async Task<string> getTaparKey(CancellationToken cancellationToken)
    {
        var key = GenerateUniqeKey.GenerateUniqueKey();

        var result = await TableNoTracking.AnyAsync(k => k.gKey == key, cancellationToken);
        while (result)
        {
            key = GenerateUniqeKey.GenerateUniqueKey();

            result = await TableNoTracking.AnyAsync(k => k.gKey == key, cancellationToken);
        }
        return key;
    }

    public async Task<List<BusinessOffice>> GetBusinessOfficesByUserId(long userId, CancellationToken cancellationToken)
    {
        return await TableNoTracking.Where(b => b.userId == userId).ToListAsync(cancellationToken);
    }

    public async Task<bool> AddUpdateDocument(BusinessOfficeUpdateDocumentDto officeUpdate, CancellationToken cancellationToken)
    {
        var office = Mapper.Map<BusinessOffice>(officeUpdate);
        await DbContext.AddAsync(office, cancellationToken);
        var result = await DbContext.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}