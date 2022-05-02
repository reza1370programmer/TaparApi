using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.BusinessOffice;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

namespace TaparApi.Controllers
{
    //[Authorize]
    public class BusinessOfficeController : BaseController
    {
        public IMapper Mapper { get; set; }
        public IBusinessOfficeRepository Repository { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public BusinessOfficeController(IMapper mapper, IBusinessOfficeRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            Mapper = mapper;
            Repository = repository;
            HttpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public async Task<ActionResult> AddBusinessOffice(BusinessOfficeAddDto addDto, CancellationToken cancellationToken)
        {
            if (UserIsAutheticated && ModelState.IsValid)
            {
                // string id = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userClaims = HttpContextAccessor?.HttpContext?.User.Claims;
                var newId = userClaims?.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
                var businessOffice = Mapper.Map<BusinessOffice>(addDto);
                businessOffice.userId = Convert.ToInt64(newId);
                businessOffice.gKey = await Repository.getTaparKey(cancellationToken);
                businessOffice.cDate = DateTime.Now;
                businessOffice.cUserId = businessOffice.userId;
                await Repository.AddAsync(businessOffice, cancellationToken);
                return Ok("اطلاعات به خوبی ذخیره شد");

            }
            if (!UserIsAutheticated) return Unauthorized();
            return BadRequest("فرمت داده های ورودی اشتباه است");
        }
        [HttpGet]
        public async Task<ActionResult<List<BusinessOfficeDto>>> GetBusinessOfficesByUserId(CancellationToken cancellationToken)
        {
            var userClaims = HttpContextAccessor?.HttpContext?.User.Claims;
            var newId = userClaims?.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            var businessOffices = await Repository.GetBusinessOfficesByUserId(Convert.ToInt64(newId), cancellationToken);
            var result = Mapper.Map<List<BusinessOfficeDto>>(businessOffices);
            return Ok(result);
        }
        [HttpGet("[action]/{id:long}")]
        public async Task<ActionResult<BusinessOfficeSelectDto>> GetBusinessOfficeById(long id, CancellationToken cancellationToken)
        {
            var businessOffice = await Repository.GetByIdAsync(cancellationToken, id);
            var result = Mapper.Map<BusinessOfficeSelectDto>(businessOffice);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateBusinessOffice(BusinessOfficeUpdateDto dto,
            CancellationToken cancellationToken)
        {
            try
            {
                var businessOffice = await Repository.GetByIdAsync(cancellationToken, dto.id);
                var officeUpdateDocument = Mapper.Map<BusinessOfficeUpdateDocumentDto>(businessOffice);
                await Repository.AddUpdateDocument(officeUpdateDocument, cancellationToken);
                var result = Mapper.Map<BusinessOffice>(dto);
                result.modifiedDate = DateTime.Now;
                result.modifiedUserId = Convert.ToInt64(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                await Repository.UpdateAsync(result, cancellationToken);
                return Ok("اطلاعات به خوبی ویرایش شد");

            }
            catch (Exception)
            {
                throw new Exception("در ویرایش اطلاعات مشکلی رخ داده هست");
            }

        }
       
    }
}
