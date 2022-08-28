using System.ComponentModel.DataAnnotations;

namespace TaparApi.Common.Dtos.RefreshToken
{
    public class RefreshTokenDto
    {
        public DateTime? expirationDate { get; set; }
        public string? refreshToken { get; set; }
    }
    public class RefreshTokenModel
    {
        [Required]
        public string userType { get; set; }
        [Required]
        public string refreshTokenparam { get; set; }
    }
}
