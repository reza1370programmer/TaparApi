using AspNetCore.Totp.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos.Account;
using Tapar.Core.Common.Dtos.RefreshToken;
using Tapar.Core.Common.Services.JwtServices;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public ISuperAdminRepository SuperAdminRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IJwtService JwtService { get; set; }
        public IRepository<RefreshTokens> refreshTokenRepository { get; set; }
        public ITotpGenerator totpGenerator { get; set; }
        public ITotpValidator totpValidator { get; set; }

        public AccountController(IJwtService jwtService, ISuperAdminRepository superAdminRepository, IUserRepository userRepository, IRepository<RefreshTokens> refreshTokenRepository, ITotpGenerator totpGenerator, ITotpValidator totpValidator)
        {
            JwtService = jwtService;
            SuperAdminRepository = superAdminRepository;
            UserRepository = userRepository;
            this.refreshTokenRepository = refreshTokenRepository;
            this.totpGenerator = totpGenerator;
            this.totpValidator = totpValidator;
        }
        [HttpPost("[action]")]
        public async Task<ApiResult<object>> Login(LoginSuperAdminDTO loginUserDto, CancellationToken cancellationToken)
        {
            var admin = await SuperAdminRepository.LoginSuperAdmin(loginUserDto, cancellationToken);
            if (admin == null)
                return NotFound("نام کاربری یا کلمه عبور اشتباه است");
            var token = await JwtService.GenerateAsync(admin);
            var newRefreshToken = GenerateRefreshToken();
            await refreshTokenRepository.AddAsync(
                 new RefreshTokens { expirationDate = newRefreshToken.expirationDate, refreshToken = newRefreshToken.refreshToken, superAdminId = admin.Id }
                 , cancellationToken);
            return new { adminType = admin.adminType, fullName = admin.fullName, refreshToken = newRefreshToken.refreshToken, token = token, userId = admin.Id.ToString(), expirationTime = 30 };

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> LoginUser(LoginUserDto loginUserDto, CancellationToken cancellationToken)
        {
            var admin = await UserRepository.LoginUser(loginUserDto, cancellationToken);
            if (admin == null)
                return NotFound("نام کاربری یا کلمه عبور اشتباه است");
            var token = await JwtService.GenerateAsync(admin);
            //var newRefreshToken = GenerateRefreshToken();
            //await refreshTokenRepository.AddAsync(
            //     new RefreshTokens { expirationDate = newRefreshToken.expirationDate, refreshToken = newRefreshToken.refreshToken, userId = admin.Id }
            //     , cancellationToken);
            //return new { firstName = admin.firstName, lastName = admin.lastName, userName = admin.userName, refreshToken = newRefreshToken.refreshToken, token = token, userId = admin.Id.ToString(), expirationTime = 30 };
            return Ok(new { mobile = admin.mobile, password = admin.password, token = token, id = admin.Id });

        }
        [HttpGet("refresh-token")]
        public async Task<ActionResult<object>> RefreshToken([FromQuery] RefreshTokenModel tokenModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return Unauthorized();
            string token = "";
            var refreshToken = await refreshTokenRepository.Table.FirstOrDefaultAsync(r => r.refreshToken == tokenModel.refreshTokenparam);
            if (refreshToken == null)
                return Unauthorized();
            if (tokenModel.userType.ToLower() == "superadmin")
                await refreshTokenRepository.LoadReferenceAsync(refreshToken, r => r.superAdmin!, cancellationToken);
            if (tokenModel.userType == "user")
                await refreshTokenRepository.LoadReferenceAsync(refreshToken, r => r.user!, cancellationToken);
            if (refreshToken == null)
            {
                return Unauthorized("Invalid Refresh Token.");
            }

            if (refreshToken.expirationDate < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }
            if (refreshToken.user != null)
            {
                var user = refreshToken.user;
                token = await JwtService.GenerateAsync(refreshToken.user);
                var newRefreshToken = GenerateRefreshToken();
                refreshToken.refreshToken = newRefreshToken.refreshToken!;
                refreshToken.expirationDate = (DateTime)newRefreshToken.expirationDate!;
                await refreshTokenRepository.UpdateAsync(refreshToken, cancellationToken);
                return new { refreshToken = newRefreshToken.refreshToken, token = token, userId = user.Id.ToString(), expirationTime = 20 };

            }

            if (refreshToken.superAdmin != null)
            {
                var admin = refreshToken.superAdmin;
                token = await JwtService.GenerateAsync(refreshToken.superAdmin);
                var newRefreshToken = GenerateRefreshToken();
                refreshToken.refreshToken = newRefreshToken.refreshToken!;
                refreshToken.expirationDate = (DateTime)newRefreshToken.expirationDate!;
                await refreshTokenRepository.UpdateAsync(refreshToken, cancellationToken);
                return new { adminType = admin.adminType, fullName = admin.fullName, refreshToken = newRefreshToken.refreshToken, token = token, userId = admin.Id.ToString(), expirationTime = 30 };
            }

            throw new Exception("مشکل ناشناخته ای رخ داد");
        }

        private RefreshTokenDto GenerateRefreshToken()
        {
            var refreshtoken = new RefreshTokenDto
            {
                expirationDate = DateTime.Now.AddDays(7),
                refreshToken = Guid.NewGuid().ToString().Replace("-", "")
            };
            return refreshtoken;
        }

        [HttpGet("[action]")]
        public IActionResult checkToken()
        {
            return User.Identity!.IsAuthenticated ? Ok("you are authorized") : Unauthorized();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> LogOut([FromQuery] string refreshToken, CancellationToken cancellation)
        {
            var refresh = await refreshTokenRepository.Table.SingleAsync(t => t.refreshToken == refreshToken, cancellation);
            if (refresh != null)
            {
                await refreshTokenRepository.DeleteAsync(refresh, cancellation);
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("[action]")]
        public IActionResult GenerateTotp()
        {
            string secret_key = "e6c99c18e8e8567b54ae0c39bc0ad719";
            int totpCode = this.totpGenerator.Generate(secret_key);
            return Ok(totpCode);
        }
        [HttpGet("[action]/{code:int}")]
        public IActionResult ValidateTotp(int code)
        {
            string secret_key = "e6c99c18e8e8567b54ae0c39bc0ad719";
            var result = totpValidator.Validate(secret_key, code);
            return Ok(result);
        }

    }
}
