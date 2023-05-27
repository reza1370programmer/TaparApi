using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.LuceneDto;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces
{
    public interface ILuceneSearch
    {
        public LuceneSearchDto Search(SearchParams searchParams);
        public IEnumerable<LuceneDto> SearchForMobile(SearchParamsForMobile searchParams);
        public void CopyDataToLucene(List<Place> places);
        public void AddDocumentToLucene(Place place);
        public void EditPlace(Place place);
        public void DeletePlace(long placeid);
    }
}
