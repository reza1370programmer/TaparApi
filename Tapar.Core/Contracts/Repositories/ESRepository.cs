using AutoMapper;
using Nest;
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
            //var data = new PlaceIndex()
            //{
            //    tablo = place.tablo,
            //    service_description = place.service_description,
            //    address = place.address,
            //    bussiness_pic1 = place.bussiness_pic1,
            //    bussiness_pic2 = place.bussiness_pic2,
            //    bussiness_pic3 = place.bussiness_pic3,
            //    comments = place.comments,
            //    email = place.email,
            //    fax = place.fax,
            //    Id = place.Id,
            //    instagram = place.instagram,
            //    like_count = place.like_count,
            //    locationId = place.locationId,
            //    manager = place.manager,
            //    mob1 = place.mob1,
            //    mob2 = place.mob2,
            //    on_off = place.on_off,
            //    personal_pic = place.personal_pic,
            //    phone1 = place.phone1,
            //    phone2 = place.phone2,
            //    phone3 = place.phone3,
            //    RejectedDescription = place.RejectedDescription,
            //    special_message = place.special_message,
            //    StatusId = place.StatusId,
            //    taparcode = place.taparcode,
            //    telegram = place.telegram,
            //    userId
            //};
            var data = mapper.Map<PlaceIndex>(place);
            await _elasticClient.IndexDocumentAsync(data);
        }
    }
}
