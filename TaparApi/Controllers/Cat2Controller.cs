using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Filters;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{

    public class Cat2Controller : BaseController
    {
        public ICat2Repsitory Repository { get; set; }
        public IMapper Mapper { get; set; }
        public IRepository<TagCat> tagCatRepository { get; set; }
        public Cat2Controller(ICat2Repsitory repository, IMapper mapper, IRepository<TagCat> tagCatRepository)
        {
            Repository = repository;
            Mapper = mapper;
            this.tagCatRepository = tagCatRepository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListOfCat2(long id, CancellationToken cancellationToken)
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
            if (UserIsAutheticated)
            {
                var list = await Repository.GetCat2sByCat1Id(id, cancellationToken);
                return Ok(list.Select(p => new { p.name, p.popup_state, p.Id }));
            }
            return Unauthorized();

        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetFiltersByCat2Id(int id, CancellationToken cancellationToken)
        {
            var filters = Mapper.Map<FilterDto[]>(await Repository.GetCat2Filters(id, cancellationToken));
            return Ok(filters);
        }
        [HttpGet("[action]/{cat2Id}")]
        public async Task<IActionResult> GetTagsByCat2Id(int cat2Id,CancellationToken cancellationToken)
        {
            var tags=await tagCatRepository.TableNoTracking.Where(p=>p.cat2Id==cat2Id).Select(q=>q.tag.title).ToListAsync(cancellationToken);
            return Ok(tags);
        }
    }
}
