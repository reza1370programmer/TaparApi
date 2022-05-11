using Microsoft.AspNetCore.Mvc;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.Account;
using TaparApi.Common.Services;
using TaparApi.Data.Contracts.Interfaces;

namespace TaparApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public ISuperAdminRepository SuperAdminRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IJwtService JwtService { get; set; }
        

        public AccountController(IJwtService jwtService, ISuperAdminRepository superAdminRepository, IUserRepository userRepository)
        {
            JwtService = jwtService;
            SuperAdminRepository = superAdminRepository;
            UserRepository = userRepository;
            
        }

        [HttpPost("[action]")]
        public async Task<ApiResult<object>> Login(LoginSuperAdminDTO loginUserDto, CancellationToken cancellationToken)
        {
            var admin = await SuperAdminRepository.LoginSuperAdmin(loginUserDto, cancellationToken);
            if (admin == null)
                return NotFound("نام کاربری یا کلمه عبور اشتباه است");
            var token = await JwtService.GenerateAsync(admin);
            return new { adminType = admin.adminType, fullName = admin.fullName, token = token, userId = admin.Id.ToString(), expirationTime = 30 };

        }
        [HttpPost("[action]")]
        public async Task<ApiResult<object>> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken)
        {
            var admin = await UserRepository.LoginUser(loginUserDto, cancellationToken);
            if (admin == null)
                return NotFound("نام کاربری یا کلمه عبور اشتباه است");
            var token = await JwtService.GenerateAsync(admin);
            return new { firstName = admin.firstName, lastName = admin.lastName, userName = admin.userName, token = token, userId = admin.Id.ToString(), expirationTime = 30 };

        }
        [HttpGet("[action]")]
        public void ChekLogger()
        {
            
            try
            {
                var num = int.Parse("khkhsf");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
