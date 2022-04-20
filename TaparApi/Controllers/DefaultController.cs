using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.BusinessOfficeType;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{
  
    public class DefaultController : BaseController
    {
        public IRepository<BusinessOfficeType> businessOfficeTypeRepository { get; set; }
        public IMapper Mapper { get; set; }
        public DefaultController(IRepository<BusinessOfficeType> repository, IMapper mapper)
        {
            businessOfficeTypeRepository = repository;
            Mapper = mapper;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<BusinessOfficeTypeDto>>> GetBusinessOfficeTypes()
        {
            var list= await businessOfficeTypeRepository.TableNoTracking.ToListAsync();
            return Ok(Mapper.Map<List<BusinessOfficeTypeDto>>(list));
        }

    }
}
