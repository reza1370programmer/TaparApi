using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.BusinessOfficeType;
using TaparApi.Common.Dtos.Location;


namespace TaparApi.Controllers
{
  
    public class DefaultController : BaseController
    {
     
        public IMapper Mapper { get; set; }
        public DefaultController( IMapper mapper)
        {
          
            Mapper = mapper;
        
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<BusinessOfficeTypeDto>>> GetBusinessOfficeTypes(CancellationToken cancellationToken)
        {
           
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<List<LocationDto>>> GetLocations(CancellationToken cancellationToken)
        {
      
            return Ok();
        }
    }
}
