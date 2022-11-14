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
        CreateMap<Place, PlaceSearchDto>()
            .ForMember(x => x.cat3Title, y => y.MapFrom(x => x.cat3.name))
            .ForMember(x => x.cat2Title, y => y.MapFrom(x => x.cat3.cat2.name))
            .ForMember(x => x.cat1Title, y => y.MapFrom(x => x.cat3.cat2.cat1.name))
            .ForMember(x => x.cat1Id, y => y.MapFrom(x => x.cat3.cat2.cat1.Id));
        CreateMap<WeekDays, WeekDaysDto>().ReverseMap();
    }
}