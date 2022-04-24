using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.BusinessOfficeType;
using TaparApi.Common.Dtos.Location;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{
  
    public class DefaultController : BaseController
    {
        public IRepository<BusinessOfficeType> businessOfficeTypeRepository { get; set; }
        public IRepository<Location> LocationRepository { get; set; }
        public IMapper Mapper { get; set; }
        public DefaultController(IRepository<BusinessOfficeType> repository, IMapper mapper, IRepository<Location> locationRepository)
        {
            businessOfficeTypeRepository = repository;
            Mapper = mapper;
            LocationRepository = locationRepository;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<BusinessOfficeTypeDto>>> GetBusinessOfficeTypes(CancellationToken cancellationToken)
        {
            var list= await businessOfficeTypeRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(Mapper.Map<List<BusinessOfficeTypeDto>>(list));
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<LocationDto>>> GetLocations(CancellationToken cancellationToken)
        {
            var list = await LocationRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(Mapper.Map<List<LocationDto>>(list));
        }
    }
}
