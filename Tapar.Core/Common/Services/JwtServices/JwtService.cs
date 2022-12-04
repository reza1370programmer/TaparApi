using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Tapar.Data.Entities;

namespace Tapar.Core.Common.Services.JwtServices
{
    public class JwtService : IJwtService
    {
        private readonly SiteSettings _siteSetting;

        public JwtService(IOptionsSnapshot<SiteSettings> settings)
        {
            _siteSetting = settings.Value;
        }

        public async Task<string> GenerateAsync<T>(T user) where T : class
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.SecretKey); // longer that 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);

            var encryptionkey = Encoding.UTF8.GetBytes(_siteSetting.JwtSettings.Encryptkey); //must be 16 character
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionkey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var claims = await _getClaimsAsync(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _siteSetting.JwtSettings.Issuer,
                Audience = _siteSetting.JwtSettings.Audience,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSetting.JwtSettings.NotBeforeMinutes),
                Expires = DateTime.Now.AddDays(_siteSetting.JwtSettings.ExpirationDays),
                SigningCredentials = signingCredentials,
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = true;
            var securityToken = tokenHandler.CreateToken(descriptor);
            var jwt = tokenHandler.WriteToken(securityToken);
            return jwt;
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync<T>(T user) where T : class
        {

            var list = new List<Claim>();
            if (typeof(T) == typeof(SuperAdmin))
            {
                var superadmin = (SuperAdmin)Convert.ChangeType(user, typeof(SuperAdmin));
                list.Add(new Claim(ClaimTypes.Role, "superadmin"));
                list.Add(new Claim(ClaimTypes.NameIdentifier, superadmin.Id.ToString()));

            }
            else
            {
                var logUser = (User)Convert.ChangeType(user, typeof(User));
                list.Add(new Claim(ClaimTypes.Role, "user"));
                list.Add(new Claim(ClaimTypes.NameIdentifier, logUser.Id.ToString()));
            }
            return list;

        }
    }
}
