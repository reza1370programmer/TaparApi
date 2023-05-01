using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                        throw new Exception("در ثبت اطلاعات مشکلی رخ داده هست" + ex.Message);
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
            var place = await repository.TableNoTracking.Include(p => p.weekDay!).AsSplitQuery().SingleOrDefaultAsync(p => p.Id == id, cancellationToken);
            return Ok(place);

        }
        [HttpGet("[action]/{number}")]
        public async Task<IActionResult> CheckPhoneNumber(string number, CancellationToken cancellationToken)
        {
            var place = await repository.TableNoTracking
                .Where(p => p.phone1 == number || p.phone2 == number || p.phone3 == number || p.mob1 == number || p.mob2 == number).FirstOrDefaultAsync(cancellationToken);
            if (place is null) { return Ok(null); }
            return Conflict(place.tablo);
        }
        #region UserPanelMethods

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPlacesByUserId(CancellationToken cancellation, [FromQuery] string? searchKey, [FromQuery] string? pageIndex)
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
                await repository.UpdateGlobalInformation(dto, cancellationToken);
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
                await repository.UpdateAddress(dto, cancellationToken);
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
                await repository.UpdateRelationWays(dto, cancellationToken);
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

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateWorkTime(UpdateWorkTimeDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                await repository.UpdateWorkTime(dto, cancellationToken);
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("مشکلی در سرور رخ داد");

            }
        }
        [Authorize]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> DeletePlace(long id, CancellationToken cancellationToken)
        {
            try
            {
                await repository.DeleteBusiness(id, cancellationToken);
                return Ok();
            }
            catch (Exception)
            {

                throw new Exception("سرور پاسخگو نمی باشد");
            }
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteImage(DeleteImageDto Dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                var place = await repository.DeleteImage(Dto, cancellationToken);
                return Ok(place);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
   
        #endregion

        #endregion

    }
}
