using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.Account;
using TaparApi.Common.Services;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IAccountRepository AccountRepository { get; set; }
        public IJwtService JwtService { get; set; }

        public AccountController(IAccountRepository accountRepository, IJwtService jwtService)
        {
            AccountRepository = accountRepository;
            JwtService = jwtService;
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<object>> Login(LoginSuperAdminDTO loginUserDto, CancellationToken cancellationToken)
        {
            var admin = await AccountRepository.LoginSuperAdmin(loginUserDto, cancellationToken);
            if (admin == null)
                return NotFound("نام کاربری یا کلمه عبور اشتباه است");
            var token = await JwtService.GenerateAsync(admin);
            return new { adminType = admin.adminType, fullName = admin.fullName, token = token, userId = admin.Id.ToString(), expirationTime = 30 };

        }
    }
}
