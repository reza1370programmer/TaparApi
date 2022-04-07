using TaparApi.Data.Common;

namespace TaparApi.Data.Entities;

public class SuperAdmin:BaseEntity
{
    public string userName { get; set; }
    public string password { get; set; }
    public string fullName { get; set; }
    public int adminType { get; set; } = 1;
}