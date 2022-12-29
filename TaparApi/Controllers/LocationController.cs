using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Contracts.Interfaces;

namespace TaparApi.Controllers
{

    public class LocationController : BaseController
    {
        public ILocationRepository locationRepository { get; set; }

        public LocationController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllLocations(CancellationToken cancellationToken)
        {
            var list = await locationRepository
                .TableNoTracking
                .Select(l => new { l.Id, l.name })
                .ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOstan(CancellationToken cancellationToken)
        {
            var list = await locationRepository.TableNoTracking
                .Where(l => l.isActive == true && l.parentId == null)
                .Select(l => new { l.Id, l.name })
                .ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetShahrestanByParentId(int id, CancellationToken cancellationToken)
        {
            var list = await locationRepository.TableNoTracking
                .Where(l => l.parentId == id && l.isActive)
                .Select(l => new { l.Id, l.name })
                .ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllShahrestan(CancellationToken cancellationToken)
        {
            var shahrestan=await locationRepository.TableNoTracking.Where(l => l.parentId!=null).ToListAsync(cancellationToken);
            return Ok(shahrestan);
        }
    }
}
