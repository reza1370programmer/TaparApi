using AspNetCore.ServiceRegistration.Dynamic;
using TaparApi.Common.Dtos.Account;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IUserRepository:IRepository<User>,IScopedService
{
    Task<User?> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken);
}