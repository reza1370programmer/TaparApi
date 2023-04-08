
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;

namespace TaparApi.Controllers
{

    public class SearchController : BaseController
    {
        //public IESRepository Repository { get; set; }
        public ILuceneSearch LuceneRepository { get; set; }

        public SearchController(ILuceneSearch luceneRepository)
        {
            LuceneRepository = luceneRepository;
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> SearchPlace([FromQuery] SearchParams searchParams, CancellationToken cancellationToken)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var data = await Repository.SearchPlaces(searchParams, cancellationToken);
        //        return Ok(data.Documents.ToList());
        //    }
        //    return BadRequest();
        //}
        //[HttpGet("[action]")]
        //public async Task<IActionResult> CopyDataToEalstic()
        //{
        //    var documents = Mapper.Map<List<PlaceIndex>>(await PlaceRepo.TableNoTracking.Include(p => p.comments).Include(p => p.weekDay).ToListAsync());

        //    Repository.CopyDataToElastic(documents);
        //    return Ok();
        //}
        //[HttpGet("[action]")]
        //public IActionResult CopyDataToLucene()
        //{
        //    var service = serviceProvider.GetService<IPlaceRepository>();
        //    var places = service.TableNoTracking.Include(p => p.weekDay).ToList();
        //    LuceneRepository.CopyDataToLucene(places);
        //    return Ok();
        //}
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchPlace([FromQuery] SearchParams searchParams, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {
                var data = LuceneRepository.Search(searchParams);
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
