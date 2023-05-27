using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Account;
using Tapar.Data.Entities;


namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface IUserRepository : IRepository<User>
{
    Task<User?> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken);
    Task<IEnumerable<UserListForSuperAdminDTO>> GetUserListForSuperAdmin(CancellationToken cancellationToken);
}