
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{
    public class UserController : BaseController
    {
        public IRepository<User> Repository { get; set; }

        public UserController(IRepository<User> repository)
        {
            Repository = repository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCountOfUsers(CancellationToken cancellationToken)
        {
            return Ok(await Repository.TableNoTracking.CountAsync(cancellationToken));
        }
    }
}
