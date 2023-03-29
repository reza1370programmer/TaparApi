using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;

namespace TaparApi.Controllers
{

    public class CommentController : BaseController
    {
        public IRepository<Comment> Repository { get; set; }

        public CommentController(IRepository<Comment> repository)
        {
            Repository = repository;
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddComment(AddCommentDto dto, CancellationToken cancellationToken)
        {

            try
            {
                var userId = Convert.ToInt64(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var comment = new Comment() { create_date = DateTime.Now, placeId = dto.PlaceId, text = dto.Text, userId = userId, status = false };
                await Repository.AddAsync(comment, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        [HttpGet("[action]/{PlaceId}")]
        public async Task<IActionResult> GetCommentsByPlaceId(long PlaceId, CancellationToken cancellationToken)
        {
            var comments = await Repository.TableNoTracking.Where(c => c.placeId == PlaceId && c.status == true).ToListAsync(cancellationToken);
            return Ok(comments);
        }
    }
}
