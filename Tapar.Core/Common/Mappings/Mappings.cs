using AutoMapper;
using Tapar.Core.Common.Dtos.DynamicFields;
using Tapar.Data.Entities;
using Tapar.Core.Common.Dtos.Filters;

namespace Tapar.Core.Common.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {

        CreateMap<SpecialTypeField, DynamicFieldsDto>().ReverseMap();
        CreateMap<FilterDto, Data.Entities.Filters>().ReverseMap();
        CreateMap<ChildFilterDto, Data.Entities.Filters>().ReverseMap();
    }
}