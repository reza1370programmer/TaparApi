using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tapar.Core.Common.Api;
using Tapar.Core.Common.Dtos.DynamicFields;
using Tapar.Core.Contracts.Interfaces;
using Tapar.Data.Entities;


namespace TaparApi.Controllers
{

    public class SpecialTypeFieldController : BaseController
    {
        public IDynamicFieldsRepsitory Repsitory { get; set; }
        public IMapper Mapper { get; set; }

        public SpecialTypeFieldController(IDynamicFieldsRepsitory repsitory, IMapper mapper)
        {
            Repsitory = repsitory;
            Mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<List<DynamicFieldsDto>>> GetDynamicFieldsByCat2Id(int id, CancellationToken cancellationToken)
        {
            var result = Mapper.Map<List<DynamicFieldsDto>>(await Repsitory.GetDynamicFieldsByCat2Id(id, cancellationToken));
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> AddDynamicField(DynamicFieldsAddDto addDto, CancellationToken cancellationToken)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "superadmin" && UserIsAutheticated)
            {
                if (ModelState.IsValid)
                {
                    var result = Mapper.Map<SpecialTypeField>(addDto);
                    await Repsitory.AddAsync(result, cancellationToken);
                    return RedirectToAction("GetDynamicFieldsByCat2Id", new {id= addDto.cat2Id,cancellationToken});
                }

                return BadRequest();
            }
            return Unauthorized();

        }
    }
}
