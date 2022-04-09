using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{

    public class BusinessType1Controller : BaseController
    {
        public IBusinessType1Repsitory Repository { get; set; }
        public IMapper Mapper { get; set; }

        public BusinessType1Controller(IBusinessType1Repsitory repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        [HttpGet("[action]/{id:long}")]
        public async Task<ActionResult<List<BusinessType1Dto>>> GetByBusinessCategoryId(long id, CancellationToken cancellationToken)
        {
            var business1 = await Repository.GetBusinessByBusinessCategoriId(id, cancellationToken);
            return Ok(Mapper.Map<List<BusinessType1Dto>>(business1));
        }
        [HttpPost("[action]")]
        public async Task<ApiResult> AddBusinessType1(BusinessType1Dto businessType1Dto, CancellationToken cancellationToken)
        {
            var businesstype1 = Mapper.Map<BusinessType1>(businessType1Dto);
            businesstype1.approvedDate = DateTime.Now;
            await Repository.AddAsync(businesstype1, cancellationToken);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBusinessType1(BusinessType1Dto businessType1Dto,
            CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var bt1 = await Repository.GetByIdAsync(cancellationToken, businessType1Dto.id);
                var businessType1 = Mapper.Map(businessType1Dto, bt1);
                await Repository.UpdateAsync(businessType1, cancellationToken);
                return Ok("گروه مورد نظر به بروزرسانی شد");
            }

            return BadRequest("لطفا اطلاعات را درست وارد کنید");
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            var bt1 = await Repository.GetByIdAsync(cancellationToken, id);
            bt1.deletedDate = bt1.deletedDate != null
                ? bt1.deletedDate = null
                : bt1.deletedDate = DateTime.Now;
            await Repository.UpdateAsync(bt1, cancellationToken);
            return Ok("عملیات به خوبی انجام شد");
        }
        [HttpGet("activeDeactive/{id:long}")]
        public async Task<ApiResult> ActiveDeactive(long id, CancellationToken cancellationToken)
        {
            var bt1 = await Repository.GetByIdAsync(cancellationToken, id);
            bt1.deactivatedDate = bt1.deactivatedDate != null
                ? bt1.deactivatedDate = null
                : bt1.deactivatedDate = DateTime.Now;
            await Repository.UpdateAsync(bt1, cancellationToken);
            return Ok("عملیات به خوبی انجام شد");
        }

    }
}
