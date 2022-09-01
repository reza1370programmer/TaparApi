
using Tapar.Data.Entities;
using TaparApi.Common.Dtos.Account;


namespace Tapar.Core.Contracts.Interfaces;

public interface IUserRepository:IRepository<User>
{
    Task<User?> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken);
}