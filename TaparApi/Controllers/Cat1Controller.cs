using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{
    
    public class Cat1Controller : BaseController
    {
        public  IRepository<Cat1> repository  { get; set; }

        public Cat1Controller(IRepository<Cat1> repository)
        {
            this.repository = repository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListOfCat1(CancellationToken cancellationToken)
        {
            var list = await repository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat1ById(int id, CancellationToken cancellationToken)
        {
            var cat1 = await repository.TableNoTracking.SingleOrDefaultAsync(c=>c.Id==id, cancellationToken);
            return Ok(cat1);
        }
    }
}
