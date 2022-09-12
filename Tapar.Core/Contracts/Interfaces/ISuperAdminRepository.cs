
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos.Account;
using Tapar.Data.Entities;


namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface ISuperAdminRepository:IRepository<SuperAdmin>
{
    Task<SuperAdmin?> LoginSuperAdmin(LoginSuperAdminDTO loginSuperAdminDto, CancellationToken cancellationToken);
}