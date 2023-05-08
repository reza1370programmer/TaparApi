
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;

namespace TaparApi.Controllers
{
    //[Authorize("superadmin")]
    public class SuperAdminController : BaseController
    {
        public IPlaceRepository PlaceRepository { get; set; }

        public SuperAdminController(IPlaceRepository placeRepository)
        {
            PlaceRepository = placeRepository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> FilterPlaces([FromQuery] SearchParametersForSuperAdmin dto, CancellationToken cancellationToken)
        {
            var result = await PlaceRepository.FilterPlacesForSuperAdmin(dto, cancellationToken);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> ChangeStatusToApproved(long id, CancellationToken cancellationToken)
        {
            try
            {
                await PlaceRepository.ChangeStatusToApproved(id, cancellationToken);
                return Ok();

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ChangeStatusToRejected([FromQuery] ChangeStatusToRejectedForSuperAdminDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await PlaceRepository.ChangeStatusToRejected(dto, cancellationToken);
                return Ok();

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> ChangeStatusToAwaitining(long id, CancellationToken cancellationToken)
        {
            try
            {
                await PlaceRepository.ChangeStatusToAwaitinig(id, cancellationToken);
                return Ok();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
