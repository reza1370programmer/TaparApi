﻿using Microsoft.EntityFrameworkCore;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
using TaparApi.Common.Dtos.Account;
namespace TaparApi.Data.Contracts.Repositories;

public class UserRepository:Repository<User>,IUserRepository
{
    public UserRepository(TaparDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken)
    {
        return await TableNoTracking.SingleOrDefaultAsync(
            u => u.userName == loginUserDto.userName && u.password == loginUserDto.password, cancellationToken);
    }
}