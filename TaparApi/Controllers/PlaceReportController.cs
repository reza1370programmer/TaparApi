using Microsoft.AspNetCore.Mvc;
using Tapar.Core.Common.Api;
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
        [HttpPost("[action]")]
        public async Task<IActionResult> AddReportForPlace()
        {

        }
    }
}
