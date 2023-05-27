

namespace Tapar.Core.Common.Dtos
{
    public class UserListForSuperAdminDTO
    {
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string FullName { get; set; } = "---";
        public int PlaceCount { get; set; } = 0;
    }
}
