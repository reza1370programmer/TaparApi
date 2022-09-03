using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Data.Entities;
using TaparApi.Common.Dtos.Account;


namespace Tapar.Core.Contracts.Interfaces;
[ScopedService]
public interface IUserRepository:IRepository<User>
{
    Task<User?> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken);
}