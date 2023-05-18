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
                    if (ReportCount + 1 >= 5)
                    {
                        var place = await PlaceRepository.GetByIdAsync(cancellationToken, dto.PlaceId);
                        place.StatusId = 2;
                        place.RejectedDescription = "تعداد گزارشات کاربران بیشتر از 5 تا شده هست";
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
                    if (ReportCount + 1 >= 5)
                    {
                        report.Place.StatusId = 2;
                        report.Place.RejectedDescription = "تعداد گزارشات کاربران بیشتر از 5 تا شده هست";
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
        [HttpGet("[action]/{placeId}")]
        public async Task<IActionResult> GetListOfPlaceReportsForSuperAdmin(long placeId, CancellationToken cancellationToken)
        {
            var ReportList = await Repository.TableNoTracking.Include(r => r.Report_Option).Where(r => r.PlaceId == placeId).Select(t => new ReportListOfPlaceForSuperAdminDTO()
            {
                PlaceId = t.PlaceId,
                Id = t.Id,
                ReportOptionDesc = t.Report_Option.Title,
                ReportOptionId = t.ReportOptionId,
                ReportStatus = t.Status
            }).ToListAsync(cancellationToken);
            return Ok(ReportList);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> ChangeReportToSolvedForSuperAdmin([FromQuery] ChangeReportToSolvedForSuperAdminDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var report = await Repository.Table.Include(p => p.Place).SingleOrDefaultAsync(p => p.Id == dto.Id, cancellationToken);
                report.Status = true;
                var ReportCount = await Repository.TableNoTracking.CountAsync(p => p.PlaceId == dto.PlaceId && p.Status == false);
                if (ReportCount - 1 < 5)
                {
                    var place = await PlaceRepository.GetByIdAsync(cancellationToken, dto.PlaceId);
                    place.StatusId = 1;
                    place.RejectedDescription = null;
                    LuceneRepository.EditPlace(report.Place);
                }
                await Repository.UpdateAsync(report, cancellationToken);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
