using AutoMapper;
using Tapar.Core.Common.Dtos.DynamicFields;
using Tapar.Data.Entities;
using Tapar.Core.Common.Dtos.Filters;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Core.Common.Dtos;

namespace Tapar.Core.Common.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {

        CreateMap<SpecialTypeField, DynamicFieldsDto>().ReverseMap();
        CreateMap<FilterDto, Data.Entities.Filters>().ReverseMap();
        CreateMap<ChildFilterDto, Data.Entities.Filters>().ReverseMap();
        CreateMap<Place, PlaceAddDto>().ReverseMap();
        CreateMap<Place, PlaceSearchDto>().ReverseMap();
        CreateMap<Place, PlaceGetDto>().ReverseMap();
        CreateMap<WeekDays, WeekDaysDto>().ReverseMap();
    }
}