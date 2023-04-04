using AutoMapper;
using Tapar.Data.Entities;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Core.Common.Dtos;
using Tapar.Data.ES_Entities;

namespace Tapar.Core.Common.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Place, PlaceAddDto>().ReverseMap();
        CreateMap<Place, BusinessForAdminPanelDto>().ForMember(x => x.cdate, y => y.MapFrom(g => g.cDate.Value.ToString("yyyy-MM-ddHHmmss")));
        CreateMap<Place, PlaceSearchDto>().ReverseMap();
        CreateMap<WeekDays, WeekDaysDto>().ReverseMap();
        CreateMap<PlaceIndex,Place>().ReverseMap();
        CreateMap<Comment, CommnetDtoForEs>().ReverseMap();
        CreateMap<WeekDays, WeekDaysDtoForEs>().ReverseMap();
    }
}