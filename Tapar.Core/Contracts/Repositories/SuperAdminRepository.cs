using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Dtos.Account;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories;

public class SuperAdminRepository:Repository<SuperAdmin>,ISuperAdminRepository
{
    public SuperAdminRepository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<SuperAdmin?> LoginSuperAdmin(LoginSuperAdminDTO loginSuperAdminDto, CancellationToken cancellationToken)
    {
        return await TableNoTracking.SingleOrDefaultAsync(
                c => c.password == loginSuperAdminDto.userName && c.password == loginSuperAdminDto.password,
                cancellationToken);
    }
}