using AspNetCore.ServiceRegistration.Dynamic;
using TaparApi.Common.Dtos.Account;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface ISuperAdminRepository:IRepository<SuperAdmin>,IScopedService
{
    Task<SuperAdmin?> LoginSuperAdmin(LoginSuperAdminDTO loginSuperAdminDto, CancellationToken cancellationToken);
}