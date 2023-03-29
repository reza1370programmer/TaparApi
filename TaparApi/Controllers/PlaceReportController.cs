using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{

    public class PlaceReportController : BaseController
    {
        public IRepository<Place_Report> Repository { get; set; }
        public PlaceReportController(IRepository<Place_Report> repository)
        {
            Repository = repository;
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddReportForPlace(AddReportForPlaceDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var userId = Convert.ToInt64(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var newReport = new Place_Report() { Other_Description = dto.Other_Description, PlaceId = dto.PlaceId, ReportOptionId = dto.ReportOptionId, UserId = userId };
                var report = await Repository.TableNoTracking.SingleOrDefaultAsync(p => p.UserId == userId && p.PlaceId == dto.PlaceId && p.ReportOptionId == dto.ReportOptionId);
                if (report is null)
                {
                    await Repository.AddAsync(newReport, cancellationToken);
                    return Ok();
                }
                else if (report is not null && report.Status is false)
                    return Conflict();
                else if (report is not null && report.Status is true)
                {
                    report.Status = false;
                    await Repository.UpdateAsync(report, cancellationToken);
                    return Ok();
                }
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
