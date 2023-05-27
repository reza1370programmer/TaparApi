
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{

    public class SearchController : BaseController
    {
        //public IESRepository Repository { get; set; }
        public IPlaceRepository placeRepository { get; set; }
        public ILuceneSearch LuceneRepository { get; set; }
        public IRepository<SearchRequest>  SearchRequestRepo  { get; set; }

        public SearchController(ILuceneSearch luceneRepository, IPlaceRepository placeRepository, IRepository<SearchRequest> searchRequestRepo)
        {
            LuceneRepository = luceneRepository;
            this.placeRepository = placeRepository;
            SearchRequestRepo = searchRequestRepo;
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
        [HttpGet("[action]")]
        public IActionResult CopyDataToLucene()
        {

            var places = placeRepository.TableNoTracking.Include(p => p.weekDay).ToList();
            LuceneRepository.CopyDataToLucene(places);
            return Ok();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchPlace([FromQuery] SearchParams searchParams, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {
                var data = LuceneRepository.Search(searchParams);
                var SearchRequest = new SearchRequest();
                SearchRequest.SearchKey = searchParams.searchKey;
                SearchRequest.SearchCount = data.TotalResultCount;
                SearchRequest.Id = Guid.NewGuid();
                await SearchRequestRepo.AddAsync(SearchRequest, cancellationToken);
                return Ok(data);
            }
            return BadRequest();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> SearchPlaceForMobile([FromQuery] SearchParamsForMobile searchParams, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {
                var data = LuceneRepository.SearchForMobile(searchParams);
                return Ok(data);
            }
            return BadRequest();
        }

    }
}
