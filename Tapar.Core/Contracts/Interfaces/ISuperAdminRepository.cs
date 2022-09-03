
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Data.Entities;
using TaparApi.Common.Dtos.Account;


namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface ISuperAdminRepository:IRepository<SuperAdmin>
{
    Task<SuperAdmin?> LoginSuperAdmin(LoginSuperAdminDTO loginSuperAdminDto, CancellationToken cancellationToken);
}