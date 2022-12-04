using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Core.Contracts.Interfaces;


namespace TaparApi.Controllers
{

    public class PlaceController : BaseController
    {
        #region Properties
        public IPlaceRepository repository { get; set; }
        public IMapper mapper { get; set; }
        #endregion

        #region Constructor
        public PlaceController(IPlaceRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
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
                    catch (Exception ex)
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
        public async Task<IActionResult> SearchPlace([FromQuery] SearchParams searchParams, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var placeList = mapper.Map<List<PlaceSearchDto>>(await repository.SearchPlace(searchParams, cancellationToken));
                if (placeList == null) return NotFound();
                return Ok(placeList);
            }
            return BadRequest();
        }
        [HttpGet("[action]/{placeId}")]
        public async Task<IActionResult> AddLikeToPlace(long placeId, CancellationToken cancellationToken)
        {
            if (UserIsAutheticated)
            {
                var likecount = await repository.AddLikeForPlace(placeId, cancellationToken);
                return Ok(likecount);
            }
            return Unauthorized();
        }
        [HttpGet("[action]/{placeId}")]
        public async Task<IActionResult> AddViewAsync(long placeId, CancellationToken cancellationToken)
        {
            await repository.AddView(placeId, cancellationToken);
            return NoContent();
        }

        #region UserPanelMethods
        [HttpGet("[action]/{placeId}")]
        public async Task<IActionResult> GetPlaceForEditUserPanel(long placeId, CancellationToken cancellationToken)
        {
            var placedto = await repository.GetPlaceForEditAdminPanel(placeId, cancellationToken);
            return Ok(placedto);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPlacesByUserId(CancellationToken cancellation)
        {
            if (UserIsAutheticated)
            {
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var places = mapper.Map<List<BusinessForAdminPanelDto>>(await repository.GetPlacesByUserId(Convert.ToInt64(userid), cancellation));
                return Ok(places);
            }
            else
                return Unauthorized();
            
        }
        #endregion

        #endregion

    }
}
