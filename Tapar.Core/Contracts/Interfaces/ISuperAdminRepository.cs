
using TaparApi.Common.Dtos.Account;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface ISuperAdminRepository:IRepository<SuperAdmin>
{
    Task<SuperAdmin?> LoginSuperAdmin(LoginSuperAdminDTO loginSuperAdminDto, CancellationToken cancellationToken);
}