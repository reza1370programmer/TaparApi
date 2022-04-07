using AutoMapper;
using TaparApi.Common.Dtos.BusinessCategory;
using TaparApi.Data.Entities;

namespace TaparApi.Common.Mappings;

public class Mappings:Profile
{
    public Mappings()
    {
        CreateMap<BusinessCategory,BusinessCategoryDto>().ReverseMap();
    }
}