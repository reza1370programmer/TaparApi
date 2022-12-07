using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Filters;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{
    public class Cat3Controller : BaseController
    {
        public ICat3Repository Repository { get; set; }
        public ICat2Repsitory cat2Repsitory { get; set; }
        public IMapper Mapper { get; set; }
        public IRepository<TagCat3> tagCatRepository { get; set; }
        public Cat3Controller(ICat3Repository repository, IMapper mapper, ICat2Repsitory cat2Repsitory, IRepository<TagCat3> tagCatRepository)
        {
            Repository = repository;
            Mapper = mapper;
            this.cat2Repsitory = cat2Repsitory;
            this.tagCatRepository = tagCatRepository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListOfCat3(CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.Select(p => new { p.name, p.Id }).OrderBy(p => p.Id).ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id:int}")]
        public async Task<IActionResult> GetCat3ById(int id, CancellationToken cancellationToken)
        {
            var category = Mapper.Map<CatDto>(await Repository.GetByIdAsync(cancellationToken, id));
            return Ok(category);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat3sByCat2Id(int id, CancellationToken cancellationToken)
        {
            var cat3List = (await Repository.GetCat3sByCat2Id(id, cancellationToken)).Select(c => new { c.Id, c.name }).OrderBy(p => p.Id);
            return Ok(cat3List);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat2FiltersByCat3Id(int id, CancellationToken cancellationToken)
        {
            var filters = Mapper.Map<IEnumerable<FilterDto>>(await Repository.GetCat2FiltersByCat3Id(id, cancellationToken));
            return Ok(filters);
        }
        [HttpGet("[action]/{cat3Id}")]
        public async Task<IActionResult> GetTagsByCat3Id(int cat3Id, CancellationToken cancellationToken)
        {
            var tags = await tagCatRepository.TableNoTracking.Where(p => p.cat3Id == cat3Id).Select(q => q.tag.title).ToListAsync(cancellationToken);
            return Ok(tags);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddCat3(AddCat3Dto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var cat3 = new Cat3() { name = dto.name, cat2Id = dto.cat2Id };
                    await Repository.AddAsync(cat3, cancellationToken);
                    return RedirectToAction("GetCat3sByCat2Id", new { id = dto.cat2Id, cancellationToken });
                }
                else { return BadRequest(); }
            }
            return Unauthorized();

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> EditCat3(EditCat3Dto dto,CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var cat3 = await Repository.GetByIdAsync(cancellationToken, dto.cat3Id);
                    cat3.name = dto.name;
                    await Repository.UpdateAsync(cat3, cancellationToken);
                    return RedirectToAction("GetCat3sByCat2Id", new { id = dto.cat2Id, cancellationToken });
                }
                else { return BadRequest(); }
            }
            return Unauthorized();
        }
    }
}
