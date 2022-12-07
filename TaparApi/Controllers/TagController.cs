
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{

    public class TagController : BaseController
    {
        public ITagRepository repository { get; set; }
        public IRepository<TagCat3> tagCat3Repository { get; set; }

        public TagController(ITagRepository repository, IRepository<TagCat3> tagCat3Repository)
        {
            this.repository = repository;
            this.tagCat3Repository = tagCat3Repository;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllTags()
        {
            throw new NotImplementedException();
        }
        [HttpGet("[action]/{title}")]
        public async Task<IActionResult> AddTag(string title, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        [HttpGet("[action]/{cat3Id}")]
        public async Task<IActionResult> GetTagsByCat3Id(int cat3Id, CancellationToken cancellationToken)
        {
            var cat3Tags = await tagCat3Repository.TableNoTracking.Where(p => p.cat3Id == cat3Id)
                .Select(p =>new { p.tag.Id,p.tag.title })
                .ToListAsync(cancellationToken);
            return Ok(cat3Tags);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> EditTag(TagDto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if(ModelState.IsValid)
                {
                    var tag = await repository.GetByIdAsync(cancellationToken, dto.id);
                    tag.title = dto.title;
                    await repository.UpdateAsync(tag, cancellationToken);
                    return RedirectToAction("GetTagsByCat3Id", new { dto.cat3Id, cancellationToken });
                }
                return BadRequest();
     
            }
            return Unauthorized();
       
        }
    }
}
