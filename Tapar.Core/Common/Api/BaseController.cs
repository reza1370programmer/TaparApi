
using Microsoft.AspNetCore.Mvc;
using TaparApi.Common.Filters;

namespace Tapar.Core.Common.Api
{
    [ApiController]
    [ApiResultFilter]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        public bool UserIsAutheticated => HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated;
    }
}
