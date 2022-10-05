using Microsoft.AspNetCore.Mvc;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{
    
    public class PlaceController : BaseController
    {
        public IPlaceRepository repository { get; set; }

        public PlaceController(IPlaceRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddPlace([FromForm] PlaceAddDto dto, CancellationToken cancellationToken)
        {
            Place place = new Place();
            place.tablo= dto.tablo;
            place.service_description = dto.description;
            place.manager = dto.modir;
            place.gvalue = dto.gValue;
            //ToDo filters
            return Ok();
        }

    }
}
