using Microsoft.AspNetCore.Mvc;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Core.Common.Services.ImageUploader;
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

    }
}
