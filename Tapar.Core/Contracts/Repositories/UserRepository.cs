using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Account;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
namespace TaparApi.Data.Contracts.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<UserListForSuperAdminDTO>> GetUserListForSuperAdmin(CancellationToken cancellationToken)
    {
        var Users = await TableNoTracking.Include(p => p.places).Select(p => new UserListForSuperAdminDTO()
        {
            Mobile = p.Mobile,
            Password = p.Password,
            FullName = p.FullName,
            PlaceCount = p.places.Count()
        }).ToListAsync(cancellationToken);
        return Users;
    }

    public async Task<User?> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken)
    {
        return await TableNoTracking.SingleOrDefaultAsync(u => u.Password == loginUserDto.password && u.Mobile == loginUserDto.mobile, cancellationToken);
    }
}