
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Contracts.Interfaces;

namespace TaparApi.Controllers
{
    public class UserController : BaseController
    {
        public IUserRepository Repository { get; set; }

        public UserController(IUserRepository repository)
        {
            Repository = repository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCountOfUsers(CancellationToken cancellationToken)
        {
            return Ok(await Repository.TableNoTracking.CountAsync(cancellationToken));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserListForSuperAdmin(CancellationToken cancellationToken)
        {
            return Ok( await Repository.GetUserListForSuperAdmin(cancellationToken));
        }
    }
}
