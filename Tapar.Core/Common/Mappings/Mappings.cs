using AutoMapper;
using Tapar.Core.Common.Dtos.DynamicFields;
using Tapar.Data.Entities;

namespace Tapar.Core.Common.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<SpecialTypeField, DynamicFieldsDto>().ReverseMap();
    }
}