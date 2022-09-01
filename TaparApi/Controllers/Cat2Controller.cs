using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
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
        public async Task<IActionResult> GetListOfCat2(long id, CancellationToken cancellationToken)
        {
            var list = await Repository.TableNoTracking.Select(p => new { p.name, p.Id }).ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat2ById(int id, CancellationToken cancellationToken)
        {
            var category = await Repository.GetByIdAsync(cancellationToken,id);
            return Ok(category);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCat2sByCat1Id(int id,CancellationToken cancellationToken)
        {
            var list = await Repository.GetCat2sByCat1Id(id, cancellationToken);
            return Ok(list);
        }
    
     

    }
}
