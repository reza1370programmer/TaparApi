using System.ComponentModel.DataAnnotations.Schema;
using TaparApi.Data.Common;

namespace TaparApi.Data.Entities
{
    public class RefreshTokens:BaseEntity<long>
    {
        public DateTime? expirationDate { get; set; }
        public string? refreshToken { get; set; }
        [ForeignKey(nameof(user))]
        public long? userId { get; set; }
        [ForeignKey(nameof(superAdmin))]
        public int? superAdminId { get; set; }
        public User? user { get; set; }
        public SuperAdmin? superAdmin { get; set; }
    }
}
