using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Contracts.Interfaces;


namespace TaparApi.Controllers
{
    public class Cat3Controller : BaseController
    {
        public ICat3Repository Repository { get; set; }
        public IMapper Mapper { get; set; }

        public Cat3Controller(ICat3Repository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetListOfCat3(CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.Select(p => new { p.name, p.Id }).ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id:int}")]
        public async Task<ApiResult> GetCat3ById(int id, CancellationToken cancellationToken)
        {
            var category = await Repository.GetByIdAsync(cancellationToken, id);
            return Ok(category);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat3sByCat2Id(int id, CancellationToken cancellationToken)
        {
            var list = await Repository.GetCat3sByCat2Id(id, cancellationToken);
            return Ok(list);
        }
    }
}
