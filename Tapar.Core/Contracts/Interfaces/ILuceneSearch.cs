


using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using Tapar.Core.Common.Dtos.LuceneDto;

namespace Tapar.Core.Contracts.Interfaces
{
    [ScopedService]
    public interface ILuceneSearch
    {
        public void AddPlacesToIndex();
        public IEnumerable<LuceneDto> Search(string searchTerm);
        //public void CopyDataToLucene();
    }
}
