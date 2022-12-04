using System.Security.Claims;

namespace Tapar.Core.Common.Extensions
{
    public static class IdentityUserExtension
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var result = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
                return Convert.ToInt32(result?.Value);
            }

            return default(int);
        }
    }
}
