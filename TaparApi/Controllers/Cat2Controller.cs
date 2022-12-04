using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Filters;
using Tapar.Core.Contracts.Interfaces;

namespace TaparApi.Controllers
{

    public class Cat2Controller : BaseController
    {
        public ICat2Repsitory Repository { get; set; }
        public IMapper Mapper { get; set; }

        public Cat2Controller(ICat2Repsitory repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListOfCat2(int id, CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.Select(p => new { p.name, p.Id }).ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat2ById(int id, CancellationToken cancellationToken)
        {
            var category = await Repository.GetByIdAsync(cancellationToken, id);
            return Ok(category);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat2sByCat1Id(int id, CancellationToken cancellationToken)
        {

            var list = await Repository.GetCat2sByCat1Id(id, cancellationToken);
            return Ok(list.Select(p => new { p.name, p.Id, }));
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetFiltersByCat2Id(int id, CancellationToken cancellationToken)
        {
            var filters = Mapper.Map<FilterDto[]>(await Repository.GetCat2Filters(id, cancellationToken));
            return Ok(filters);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat2sByCat1IdForSuperAdmin(int id, CancellationToken cancellationToken)
        {

            var list = await Repository.GetCat2sByCat1Id(id, cancellationToken);
            return Ok(list.Select(p => new { p.name, p.Id, selected = false }).OrderBy(p => p.Id));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCat2(AddCat2Dto addCat2Dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    await Repository.AddCat2(addCat2Dto, cancellationToken);
                    var list = await Repository.GetCat2sByCat1Id(addCat2Dto.cat1Id, cancellationToken);
                    return Ok(list.Select(p => new { p.name, p.Id, selected = false }).OrderBy(p => p.Id));
                }
                return BadRequest(ModelState);
            }
            return Unauthorized();
          
        }

    }
}
