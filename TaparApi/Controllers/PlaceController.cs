using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetPlaceById(long id, CancellationToken cancellationToken)
        {
            var place = await repository.GetByIdAsync(cancellationToken, id);
            return Ok(place);

        }

        #region UserPanelMethods
        [HttpGet("[action]/{placeId}")]
        public async Task<IActionResult> GetPlaceCurrentCategory(long placeId, CancellationToken cancellationToken)
        {
            var place = await repository.GetPlaceCurrentCategory(placeId, cancellationToken);
            string cat3 = place.cat3.name;
            string cat2 = place.cat3.cat2.name;
            string cat1 = place.cat3.cat2.cat1.name;
            return Ok(new { cat1, cat2, cat3 });
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPlacesByUserId(CancellationToken cancellation, [FromQuery] string? searchKey, [FromQuery]   string? pageIndex)
        {
            if (UserIsAutheticated)
            {
                var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var dto = new SearchParamsForUserPanel() { pageIndex = Convert.ToInt32(pageIndex), searchKey = searchKey, userid = Convert.ToInt64(UserId) };
                var places = mapper.Map<List<BusinessForAdminPanelDto>>(await repository.GetPlacesByUserId(dto, cancellation));
                return Ok(places);
            }
            else
                return Unauthorized();

        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> EditGlobalInformation(EditGlobalInformationDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var place = await repository.GetByIdAsync(cancellationToken, dto.id);
                place.tablo = dto.tablo;
                place.manager = dto.manager;
                place.service_description = dto.service_description;
                await repository.UpdateAsync(place, cancellationToken);
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("[action]/{placeid}")]
        public async Task<IActionResult> GetPlaceForEditAddress(long placeid, CancellationToken cancellationToken)
        {
            var data = await repository.GetPlaceForEditAddress(placeid, cancellationToken);
            return Ok(data);
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> EditAddress(EditAddressDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var place = await repository.GetByIdAsync(cancellationToken, dto.placeid);
                place.address = dto.restAddress;
                place.locationId = dto.locationId;
                await repository.UpdateAsync(place, cancellationToken);
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateRelationWays(UpdateRelationWaysDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var place = await repository.GetByIdAsync(cancellationToken, dto.id);
                place.phone1 = dto.phone1;
                place.phone2 = dto.phone2;
                place.phone3 = dto.phone3;
                place.mob1 = dto.mob1;
                place.mob2 = dto.mob2;
                place.fax = dto.fax;
                place.email = dto.email;
                place.website = dto.website;
                place.telegram = dto.telegram;
                place.instagram = dto.instagram;
                place.whatsapp = dto.whatsapp;
                await repository.UpdateAsync(place, cancellationToken);
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePlacePics([FromForm] PlacePicUpdateDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var place = await repository.GetByIdAsync(cancellationToken, dto.placeid);
                if (place == null)
                { return NotFound(); }
                await repository.UpdatePlacePics(dto, place, cancellationToken);
                return Ok();
            }
            return BadRequest();

        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateModirPic([FromForm] UpdateModiPicDto dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var place = await repository.GetByIdAsync(cancellationToken, dto.placeid);
                if (place == null)
                { return NotFound(); }
                await repository.UpdateModirPic(dto, place, cancellationToken);
                return Ok();
            }
            return BadRequest();

        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateVisitCartPic([FromForm] UpdateVisitCartPic dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var place = await repository.GetByIdAsync(cancellationToken, dto.placeid);
                if (place == null)
                { return NotFound(); }
                await repository.UpdateVisitCartPic(dto, place, cancellationToken);
                return Ok();
            }
            return BadRequest();

        }
        #endregion

        #endregion

    }
}
