using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{

    public class Cat1Controller : BaseController
    {
        public IRepository<Cat1> repository { get; set; }

        public Cat1Controller(IRepository<Cat1> repository)
        {
            this.repository = repository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListOfCat1(CancellationToken cancellationToken)
        {
            var list = await repository.TableNoTracking.OrderBy(p => p.Id).ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat1ById(int id, CancellationToken cancellationToken)
        {
            var cat1 = await repository.TableNoTracking.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
            return Ok(cat1);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCatsWithSub(CancellationToken cancellationToken)
        {
            var cat1 = await repository.TableNoTracking.Include(p => p.cat2s).ThenInclude(q => q.cat3s).Select(p => new
            {
                p.Id,
                p.name,
                cat2s = p.cat2s
                .Select(t => new Categories
                {
                    id = t.Id,
                    name = t.name,
                    cat3s = t.cat3s.Select(q => new ChildCategories { id = q.Id, name = q.name }).ToList()
                }
                )

            }).ToListAsync();
            return Ok(cat1);
        }
    }
}
