
using TaparApi.Common.Dtos.Account;
using TaparApi.Data.Entities;

namespace TaparApi.Data.Contracts.Interfaces;

public interface IUserRepository:IRepository<User>
{
    Task<User?> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken);
}