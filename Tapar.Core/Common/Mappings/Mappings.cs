using AutoMapper;
using Tapar.Core.Common.Dtos;
using Tapar.Core.Common.Dtos.Place;
using Tapar.Data.Entities;

namespace Tapar.Core.Common.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<Place, PlaceAddDto>().ReverseMap();
        CreateMap<Place, BusinessForAdminPanelDto>().ForMember(x => x.cdate, y => y.MapFrom(g => g.cDate.Value.ToString("yyyy-MM-ddHHmmss")));
        CreateMap<Place, PlaceSearchDto>().ReverseMap();
        CreateMap<WeekDays, WeekDaysDto>().ReverseMap();
    }
}