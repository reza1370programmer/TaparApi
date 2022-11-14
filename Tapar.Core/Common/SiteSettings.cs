namespace Tapar.Core.Common
{
    public class SiteSettings
    {
        public JwtSettings JwtSettings { get; set; }
    }
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Encryptkey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int NotBeforeMinutes { get; set; }
        public int ExpirationDays { get; set; }
    }
}
