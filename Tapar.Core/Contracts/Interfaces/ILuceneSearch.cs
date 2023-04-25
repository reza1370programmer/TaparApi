using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.LuceneDto;
using Tapar.Data.Entities;

namespace Tapar.Core.Contracts.Interfaces
{
    [ScopedService]
    public interface ILuceneSearch
    {
        public IEnumerable<LuceneDto> Search(SearchParams searchParams);
        public void CopyDataToLucene(List<Place> places);
        public void AddDocumentToLucene(Place place);
        public void EditPlace(Place place);
        public void DeletePlace(long placeid);
    }
}
