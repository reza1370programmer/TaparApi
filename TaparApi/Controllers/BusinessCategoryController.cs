using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.BusinessCategory;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BusinessCategoryController : ControllerBase
    {
        public IRepository<BusinessCategory> Repository { get; set; }
        public IMapper Mapper { get; set; }

        public BusinessCategoryController(IRepository<BusinessCategory> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }
        [HttpGet]
        public ApiResult<List<BusinessCategoryDto>> GetAllBusinessCategories()
        {
            return Mapper.Map<List<BusinessCategoryDto>>(Repository.TableNoTracking);
        }
        [HttpPost]
        public async Task<ApiResult> AddBusinessCategory(BusinessCategoryDto businessCategoryDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var businessCategory = Mapper.Map<BusinessCategory>(businessCategoryDto);
                businessCategory.approvedDate = DateTime.Now;
                await Repository.AddAsync(businessCategory, cancellationToken);
                return Ok("گروه مورد نظر به خوبی ثبت شد");
            }

            return BadRequest("لطفا اطلاعات را درست وارد کنید");
        }
        [HttpPut]
        public async Task<ApiResult> UpdateBusinessCategory(BusinessCategoryDto businessCategoryDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var bc = await Repository.Table.FirstAsync(c => c.Id == businessCategoryDto.id);
                var businessCategory = Mapper.Map(businessCategoryDto, bc);
                await Repository.UpdateAsync(businessCategory, cancellationToken);
                return Ok("گروه مورد نظر به بروزرسانی شد");
            }

            return BadRequest("لطفا اطلاعات را درست وارد کنید");
        }
        [HttpGet("activeDeactive/{id:long}")]
        public async Task<ApiResult> ActiveDeactive(long id, CancellationToken cancellationToken)
        {
            var category = await Repository.GetByIdAsync(cancellationToken, id);
            category.deactivatedDate = category.deactivatedDate != null
                 ? category.deactivatedDate = null
                 : category.deactivatedDate = DateTime.Now;
            await Repository.UpdateAsync(category, cancellationToken);
            return Ok("عملیات به خوبی انجام شد");
        }
        [HttpGet("delete/{id:long}")]
        public async Task<ApiResult> Delete(long id, CancellationToken cancellationToken)
        {
            var category = await Repository.GetByIdAsync(cancellationToken, id);
            category.deactivatedDate = category.deletedDate != null
                ? category.deletedDate = null
                : category.deletedDate = DateTime.Now;
            await Repository.UpdateAsync(category, cancellationToken);
            return Ok("عملیات به خوبی انجام شد");
        }
    }
}
