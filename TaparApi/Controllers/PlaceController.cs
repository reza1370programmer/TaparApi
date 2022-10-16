using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Core.Contracts.Interfaces;


namespace TaparApi.Controllers
{

    public class PlaceController : BaseController
    {
        public IPlaceRepository repository { get; set; }
        public IMapper mapper { get; set; }

        public PlaceController(IPlaceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddPlace([FromForm] PlaceAddDto dto, CancellationToken cancellationToken)
        {
            if (UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await repository.AddPlace(dto, cancellationToken);
                        return Ok();
                    }
                    catch (Exception)
                    {

                        throw new Exception("در ثبت اطلاعات مشکلی رخ داده هست");
                    }
                }
                else
                    return BadRequest();
            }
            return Unauthorized();


        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPlaceById([FromQuery] long id, CancellationToken cancellationToken)
        {
            var place = await repository.GetPlaceById(id, cancellationToken);
            if (place == null) return NotFound();
            return Ok(place);
        }
        [HttpGet("[action]/{searchKey}")]
        public async Task<IActionResult> SearchPlace(string searchKey, CancellationToken cancellationToken)
        {
            var placeList = mapper.Map<List<PlaceSearchDto>>(await repository.SearchPlace(searchKey, cancellationToken));
            return Ok(placeList);
        }
    }
}
