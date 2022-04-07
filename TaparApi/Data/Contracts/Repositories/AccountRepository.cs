using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Dtos.Account;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Repositories
{
    public class AccountRepository:Repository<SuperAdmin>,IAccountRepository
    {
        public AccountRepository(TaparDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<SuperAdmin?> LoginSuperAdmin(LoginSuperAdminDTO loginSuperAdminDto, CancellationToken cancellationToken)
        {
            return await TableNoTracking.SingleOrDefaultAsync(
                c => c.password == loginSuperAdminDto.userName && c.password == loginSuperAdminDto.password,
                cancellationToken);
        }
    }
}
