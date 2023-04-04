using AutoMapper;
using Nest;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
using Tapar.Data.ES_Entities;

namespace Tapar.Core.Contracts.Repositories
{
    public class ESRepository : IESRepository
    {
        public IElasticClient _elasticClient { get; set; }
        public IMapper mapper { get; set; }
        public ESRepository(IElasticClient elasticClient, IMapper mapper)
        {
            _elasticClient = elasticClient;
            this.mapper = mapper;
        }

        public async Task AddPlaceIndex(Place place)
        {
            var data = mapper.Map<PlaceIndex>(place);
            await _elasticClient.IndexDocumentAsync(data);
        }

        public async Task<ISearchResponse<PlaceIndex>> SearchPlaces(SearchParams dto, CancellationToken cancellationToken)
        {
            // var result = await _elasticClient.SearchAsync<PlaceIndex>(s => s.Size(5).Skip((dto.pageIndex - 1) * 5).Query(
            //      q => q.MultiMatch(
            //          m => m.Fields(f => f.Field(p => p.tablo).Field(p => p.service_description)).Query(dto.searchKey).Fuzziness(Fuzziness.Auto
            //          )
            //) &&
            //q.Term(t=>t.locationId,dto.cityId)
            //      ), cancellationToken);

            // return result;
            var resp = await _elasticClient.SearchAsync<PlaceIndex>(s => s
       .Query(q =>
       {
           QueryContainer c = +q.MultiMatch(m => m.Fields(f => f.Field(p => p.tablo).Field(p => p.service_description)).Query(dto.searchKey).Fuzziness(Fuzziness.Auto));

           if (dto.cityId > 0)
               c = c && +q.Terms(r => r.Field(f => f.locationId).Terms(dto.cityId));

           return c;
       })
       .Index("place")
       .Size(5)
       .Skip((dto.pageIndex - 1) * 5)
   );
            return resp;
        }

        public async void CopyDataToElastic(List<PlaceIndex> documents)
        {
            await _elasticClient.BulkAsync(b => b.IndexMany(documents, (d, doc) => d.Document(doc).Index("place")));
        }
    }
}
