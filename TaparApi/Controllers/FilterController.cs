using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos.Filters;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{

    public class FilterController : BaseController
    {
        public IRepository<Filters> repository { get; set; }
        public IRepository<Filters_Cat2> cat2Filters { get; set; }
        public FilterController(IRepository<Filters> repository, IRepository<Filters_Cat2> cat2Filters)
        {
            this.repository = repository;
            this.cat2Filters = cat2Filters;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetParentFilters(CancellationToken cancellationToken)
        {
            var filters = await repository.TableNoTracking.Where(f => f.parentId == null).Select(f => new { f.Id, f.title, f.enTitle }).ToListAsync(cancellationToken);
            return Ok(filters);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddParentFilter(FilterAddDto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var check = repository.TableNoTracking.Any(p => p.title.Trim() == dto.title.Trim() || p.enTitle.Trim() == dto.enTitle.Trim());
                    if (check)
                    {
                        throw new Exception("فیلتر تکراری میباشد");
                    }
                    var filter = new Filters() { title = dto.title, enTitle = dto.enTitle, parentId = null };
                    await repository.AddAsync(filter, cancellationToken);
                    return RedirectToAction("GetParentFilters", new { cancellationToken });
                }
                return BadRequest(ModelState);
            }
            return Unauthorized("باید لاگین کنید");

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> EditParentFilter(FilterEditDto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var check = repository.TableNoTracking.Any(p => p.title.Trim() == dto.title.Trim() || p.enTitle.Trim() == dto.enTitle.Trim());
                    if (check)
                    {
                        throw new Exception("فیلتر تکراری میباشد");
                    }
                    var filter = await repository.GetByIdAsync(cancellationToken, dto.id);
                    filter.title = dto.title;
                    filter.enTitle = dto.enTitle;
                    await repository.UpdateAsync(filter, cancellationToken);
                    return RedirectToAction("GetParentFilters", new { cancellationToken });
                }
                return BadRequest(ModelState);
            }
            return Unauthorized("باید لاگین کنید");
        }
        [HttpGet("[action]/{filterId}")]
        public async Task<IActionResult> GetSubFilters(int filterId, CancellationToken cancellationToken)
        {
            var filters = await repository.TableNoTracking.Where(t => t.parentId == filterId).Select(s => new { s.title, s.enTitle, s.Id }).ToListAsync(cancellationToken);
            return Ok(filters);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddChildFilter(ChildFilterAddDto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var check = repository.TableNoTracking.Any(p => p.title.Trim() == dto.title.Trim() || p.enTitle.Trim() == dto.enTitle.Trim());
                    if (check)
                    {
                        throw new Exception("فیلتر تکراری میباشد");
                    }
                    var filter = new Filters() { title = dto.title, enTitle = dto.enTitle, parentId = dto.parentId };
                    await repository.AddAsync(filter, cancellationToken);
                    return RedirectToAction("GetSubFilters", new { filterId = dto.parentId, cancellationToken });
                }
                return BadRequest(ModelState);
            }
            return Unauthorized("باید لاگین کنید");

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> EditChildFilter(ChildFilterEditDto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var check = repository.TableNoTracking.Any(p => p.title.Trim() == dto.title.Trim() || p.enTitle.Trim() == dto.enTitle.Trim());
                    if (check)
                    {
                        throw new Exception("فیلتر تکراری میباشد");
                    }
                    var filter = await repository.GetByIdAsync(cancellationToken, dto.id);
                    filter.title = dto.title;
                    filter.enTitle = dto.enTitle;
                    await repository.UpdateAsync(filter, cancellationToken);
                    return RedirectToAction("GetSubFilters", new { filterId = dto.parentId, cancellationToken });
                }
                return BadRequest(ModelState);
            }
            return Unauthorized("باید لاگین کنید");
        }
        [HttpGet("[action]/{cat2Id}")]
        public async Task<IActionResult> GetFiltersByCat2Id(int cat2Id, CancellationToken cancellationToken)
        {
            var filtersOfCat2 = await repository.TableNoTracking
                .SelectMany(p => p.filters_Cat2s)
                .Where(p => p.cat2Id == cat2Id)
                .Select(p => new { p.filter.Id, p.filter.title, p.filter.enTitle })
                .ToListAsync(cancellationToken);
            return Ok(filtersOfCat2);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddFilterToCat2(AddFilterToCat2Dto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var check = cat2Filters.TableNoTracking.Any(p => p.cat2Id == dto.cat2Id && p.filterId == dto.filterId);
                    if (check)
                    {
                        return Conflict();
                    }
                    var filter_cat2 = new Filters_Cat2() { cat2Id = dto.cat2Id, filterId = dto.filterId };
                    await cat2Filters.AddAsync(filter_cat2, cancellationToken);
                    return RedirectToAction("GetFiltersByCat2Id", new { dto.cat2Id, cancellationToken });
                }
                return BadRequest(ModelState);
            }
            return Unauthorized("باید لاگین کنید");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteFilterFromCat2(DeleteFilterFromCat2Dto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var cat2_filter = await cat2Filters.TableNoTracking.SingleOrDefaultAsync(f => f.filterId == dto.filterId && f.cat2Id == dto.cat2Id,cancellationToken);
                    await cat2Filters.DeleteAsync(cat2_filter, cancellationToken);
                    return RedirectToAction("GetFiltersByCat2Id", new { dto.cat2Id, cancellationToken });
                }
                return BadRequest(ModelState);
            }
            return Unauthorized("باید لاگین کنید");
        }
    }
}
