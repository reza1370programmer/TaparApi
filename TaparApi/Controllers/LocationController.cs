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
                .Select(l => new { l.Id, l.name, l.longitude, l.latitude })
                .ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetActiveLocations(CancellationToken cancellationToken)
        {
            var list = await locationRepository.TableNoTracking
                .Where(l => l.isActive == true)
                .Select(l => new { l.Id, l.name, l.longitude, l.latitude })
                .ToListAsync(cancellationToken);
            return Ok(list);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetLocationsByParentId(int id, CancellationToken cancellationToken)
        {
            var list = await locationRepository.TableNoTracking
                .Where(l => l.parentId == id)
                .Select(l => new { l.Id, l.name, l.longitude, l.latitude })
                .ToListAsync(cancellationToken);
            return Ok(list);
        }
    }
}
