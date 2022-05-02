using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.Business;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{

    public class BusinessController : BaseController
    {
        public IMapper Mapper { get; set; }
        public IRepository<Business> Repository { get; set; }

        public BusinessController(IMapper mapper, IRepository<Business> repository)
        {
            Mapper = mapper;
            Repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult> AddBusiness([FromBody] BusinessAddDto addDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var business = Mapper.Map<Business>(addDto);
                business.cDate=DateTime.Now;
                business.cUserId= Convert.ToInt64(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                await Repository.AddAsync(business, cancellationToken);
                return Ok("اطلاعات به خوبی ذخیره شد");
            }

            return BadRequest("اطلاعات ارسال شده صحیح نمی باشد");

        }
        [HttpGet("[action]/{id:long}")]
        public async Task<ActionResult> GetBusinessesByBusinessOfficeId(long id,CancellationToken cancellationToken)
        {
            var businessList = await Repository.TableNoTracking.Where(b => b.businessOfficeId == id).ToListAsync(cancellationToken);
            return Ok(Mapper.Map<List<BusinessDto>>(businessList));
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult> GetBusinessById(long id, CancellationToken cancellationToken)
        {
            var business = await Repository.GetByIdAsync(cancellationToken, id);
            await Repository.LoadReferenceAsync(business, b => b.BusinessOffice, cancellationToken);
            return Ok(Mapper.Map<BusinessSelectDto>(business));
        }
    }
}
