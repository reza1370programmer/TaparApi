using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;
using TaparApi.Data;
using TaparApi.Data.Contracts.Repositories;

namespace Tapar.Core.Contracts.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(TaparDbContext dbContext) : base(dbContext)
        {
        }

    }
}
