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
        public IPlaceRepository PlaceRepository { get; set; }
        public ILuceneSearch LuceneRepository { get; set; }
        public PlaceReportController(IRepository<Place_Report> repository, IPlaceRepository placeRepository, ILuceneSearch luceneRepository)
        {
            Repository = repository;
            PlaceRepository = placeRepository;
            LuceneRepository = luceneRepository;
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddReportForPlace(AddReportForPlaceDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var userId = Convert.ToInt64(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var newReport = new Place_Report() { Other_Description = dto.Other_Description, PlaceId = dto.PlaceId, ReportOptionId = dto.ReportOptionId, UserId = userId };
                var report = await Repository.Table.Include(r => r.Place).Include(r => r.Report_Option).SingleOrDefaultAsync(p => p.UserId == userId && p.PlaceId == dto.PlaceId && p.ReportOptionId == dto.ReportOptionId);
                if (report is null)
                {
                    var ReportCount = await Repository.TableNoTracking.CountAsync(p => p.PlaceId == dto.PlaceId && p.Status == false);
                    if (ReportCount + 1 >= 3)
                    {
                        var place = await PlaceRepository.GetByIdAsync(cancellationToken, dto.PlaceId);
                        place.StatusId = 3;
                        place.RejectedDescription = "تعداد گزارشات کاربران بیشتر از 3 تا شده هست";
                        LuceneRepository.EditPlace(place);
                    }
                    await Repository.AddAsync(newReport, cancellationToken);
                    return Ok();
                }
                else if (report is not null && report.Status is false)
                    return Conflict();
                else if (report is not null && report.Status is true)
                {
                    var ReportCount = await Repository.TableNoTracking.CountAsync(p => p.PlaceId == dto.PlaceId && p.Status == false);
                    if (ReportCount + 1 >= 3)
                    {
                        report.Place.StatusId = 3;
                        report.Place.RejectedDescription = "تعداد گزارشات کاربران بیشتر از 3 تا شده هست";
                        LuceneRepository.EditPlace(report.Place);
                    }
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
