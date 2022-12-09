
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
        public IRepository<Tag> repository { get; set; }
        public IRepository<TagCat3> tagCat3Repository { get; set; }

        public TagController(IRepository<Tag> repository, IRepository<TagCat3> tagCat3Repository)
        {
            this.repository = repository;
            this.tagCat3Repository = tagCat3Repository;
        }
        [HttpGet("[action]/{searchkey?}")]
        public async Task<IActionResult> SearchTags(string? searchkey,CancellationToken cancellationToken)
        {
            var tags = await repository.TableNoTracking.Where(t => t.title.Contains(searchkey)).Select(t => new {t.title,t.Id}).ToListAsync(cancellationToken);
            return Ok(tags);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddTag(AddTagDto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if(ModelState.IsValid)
                {
                    var checkTag = await repository.TableNoTracking.AnyAsync(p => p.title.Trim() == dto.title.Trim());
                    if (checkTag)
                    {
                        var tag = await repository.TableNoTracking.SingleOrDefaultAsync(t => t.title.Trim() == dto.title.Trim());
                        if (await tagCat3Repository.TableNoTracking.AnyAsync(t=>t.tagId==tag.Id && dto.cat3Id==t.cat3Id)) {
                            return Ok(null);
                        }
                        await tagCat3Repository.AddAsync(new TagCat3 { tagId = tag.Id, cat3Id = dto.cat3Id },cancellationToken);
                        return RedirectToAction("GetTagsByCat3Id", new { dto.cat3Id, cancellationToken });
                    }
                    else
                    {
                        var tag = new Tag() { title=dto.title};
                        await repository.AddAsync(tag, cancellationToken);
                        var tagcat3=new TagCat3() { cat3Id=dto.cat3Id,tagId=tag.Id};
                        await tagCat3Repository.AddAsync(tagcat3,cancellationToken);
                        return RedirectToAction("GetTagsByCat3Id", new { dto.cat3Id, cancellationToken });
                    }
                }
                return BadRequest();
            }
            return Unauthorized();
               
            
        }
        [HttpGet("[action]/{cat3Id}")]
        public async Task<IActionResult> GetTagsByCat3Id(int cat3Id, CancellationToken cancellationToken)
        {
            var cat3Tags = await tagCat3Repository.TableNoTracking.Where(p => p.cat3Id == cat3Id)
                .Select(p => new { p.tag.Id, p.tag.title })
                .ToListAsync(cancellationToken);
            return Ok(cat3Tags);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> EditTag(TagDto dto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
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
