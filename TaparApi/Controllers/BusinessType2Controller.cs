using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.BusinessType2;
using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{
    public class BusinessType2Controller : BaseController
    {
        public IBusinessType2Repository Repository { get; set; }
        public IMapper Mapper { get; set; }

        public BusinessType2Controller(IBusinessType2Repository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        [HttpGet("[action]/{id:long}")]
        public async Task<ActionResult<List<BusinessType2Dto>>> GetByBusinessType1Id(long id, CancellationToken cancellationToken)
        {
            var business1 = await Repository.GetBusinessType2sByBusinessType1Id(id, cancellationToken);
            return Ok(Mapper.Map<List<BusinessType2Dto>>(business1));
        }
        [HttpPost()]
        public async Task<ApiResult> AddBusinessType2(BusinessType2Dto businessType2Dto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var businesstype2 = Mapper.Map<Cat2>(businessType2Dto);
                //businesstype2.approvedDate = DateTime.Now;
                await Repository.AddAsync(businesstype2, cancellationToken);
                return Ok();
            }
            return BadRequest("لطفا اطلاعات را درست وارد کنید");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBusinessType2(BusinessType2Dto businessType2Dto,
            CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var bt2 = await Repository.GetByIdAsync(cancellationToken, businessType2Dto.id);
                var businessType2 = Mapper.Map(businessType2Dto, bt2);
                await Repository.UpdateAsync(businessType2, cancellationToken);
                return Ok("گروه مورد نظر به بروزرسانی شد");
            }

            return BadRequest("لطفا اطلاعات را درست وارد کنید");
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            var bt2 = await Repository.GetByIdAsync(cancellationToken, id);
            //bt2.deletedDate = bt2.deletedDate != null
            //    ? bt2.deletedDate = null
            //    : bt2.deletedDate = DateTime.Now;
            await Repository.UpdateAsync(bt2, cancellationToken);
            return Ok("عملیات به خوبی انجام شد");
        }
        [HttpGet("activeDeactive/{id:long}")]
        public async Task<ApiResult> ActiveDeactive(long id, CancellationToken cancellationToken)
        {
            var bt2 = await Repository.GetByIdAsync(cancellationToken, id);
            //bt2.deactivatedDate = bt2.deactivatedDate != null
            //    ? bt2.deactivatedDate = null
            //    : bt2.deactivatedDate = DateTime.Now;
            await Repository.UpdateAsync(bt2, cancellationToken);
            return Ok("عملیات به خوبی انجام شد");
        }
    }
}
