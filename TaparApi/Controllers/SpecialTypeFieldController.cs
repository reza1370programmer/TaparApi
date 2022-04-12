using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaparApi.Common.Api;
using TaparApi.Common.Dtos.DynamicFields;
using TaparApi.Data.Contracts.Interfaces;
using TaparApi.Data.Entities;

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
        public async Task<ActionResult<List<DynamicFieldsDto>>> GetDynamicFieldsByBusinessType1Id(long id, CancellationToken cancellationToken)
        {
            var result = Mapper.Map<List<DynamicFieldsDto>>(await Repsitory.GetDynamicFieldsByBusinessType1Id(id, cancellationToken));
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> AddDynamicField(DynamicFieldsAddDto addDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = Mapper.Map<SpecialTypeField>(addDto);
                await Repsitory.AddAsync(result, cancellationToken);
                return Ok();
            }

            return BadRequest();
        }
    }
}
