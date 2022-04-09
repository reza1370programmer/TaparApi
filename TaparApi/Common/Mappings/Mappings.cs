using AutoMapper;
using TaparApi.Common.Dtos.BusinessCategory;
using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Data.Entities;

namespace TaparApi.Common.Mappings;

public class Mappings:Profile
{
    public Mappings()
    {
        CreateMap<BusinessCategory,BusinessCategoryDto>().ReverseMap();
        CreateMap<BusinessType1, BusinessType1Dto>().ReverseMap();
    }
}