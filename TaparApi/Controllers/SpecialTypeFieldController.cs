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
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<List<DynamicFieldsDto>>> GetDynamicFieldsByBusinessType2Id(long id, CancellationToken cancellationToken)
        {
            var result = Mapper.Map<List<DynamicFieldsDto>>(await Repsitory.GetDynamicFieldsByBusinessType2Id(id, cancellationToken));
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> AddDynamicField(DynamicFieldsDto addDto, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var result = Mapper.Map<SpecialTypeField>(addDto);
                await Repsitory.AddAsync(result, cancellationToken);
                return Ok();
            }

            return BadRequest();
        }
        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateDynamicField(DynamicFieldsDto dto, CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                var item = await this.Repsitory.GetByIdAsync(cancellation, dto.id);
                var entity = Mapper.Map(dto, item);
                await Repsitory.UpdateAsync(entity, cancellation);
                return Ok();
            }

            return BadRequest();
        }
    }
}
