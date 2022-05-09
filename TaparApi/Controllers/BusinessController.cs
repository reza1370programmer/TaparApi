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
        public IRepository<BusinessUpdate> BusinessUpdateRepository { get; set; }

        public BusinessController(IMapper mapper, IRepository<Business> repository, IRepository<BusinessUpdate> businessUpdateRepository)
        {
            Mapper = mapper;
            Repository = repository;
            BusinessUpdateRepository = businessUpdateRepository;
        }
        [HttpPost]
        public async Task<ActionResult> AddBusiness([FromBody] BusinessAddDto addDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var business = Mapper.Map<Business>(addDto);
                business.cDate = DateTime.Now;
                business.cUserId = Convert.ToInt64(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                await Repository.AddAsync(business, cancellationToken);
                return Ok("اطلاعات به خوبی ذخیره شد");
            }

            return BadRequest("اطلاعات ارسال شده صحیح نمی باشد");

        }
        [HttpGet("[action]/{id:long}")]
        public async Task<ActionResult> GetBusinessesByBusinessOfficeId(long id, CancellationToken cancellationToken)
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
        [HttpPut]
        public async Task<ActionResult> UpdateBusiness(BusinessSelectDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var oldBusiness = await Repository.GetByIdAsync(cancellationToken, dto.id);
                var businessUpdate = Mapper.Map<BusinessUpdate>(oldBusiness);
                var userId = Convert.ToInt64(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var newBusiness = Mapper.Map(dto, oldBusiness);
                newBusiness.modifiedDate=DateTime.Now;
                newBusiness.modifiedUserId = userId;
                businessUpdate.modifiedDate = newBusiness.modifiedDate;
                businessUpdate.modifiedUserId = newBusiness.modifiedUserId;
                businessUpdate.businessId = newBusiness.Id;
                await BusinessUpdateRepository.AddAsync(businessUpdate, cancellationToken);
                await Repository.UpdateAsync(newBusiness, cancellationToken);
                return Ok("عملیات ویرایش به خوبی انجام شد");
            }
            catch (Exception)
            {
                throw new Exception("مشکل ناشناخته ای اتفاق افتاد");
            }
        }
    }
}
