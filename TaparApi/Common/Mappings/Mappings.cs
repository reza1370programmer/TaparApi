using AutoMapper;
using TaparApi.Common.Dtos.BusinessCategory;
using TaparApi.Common.Dtos.BusinessType2;
using TaparApi.Common.Dtos.DynamicFields;
using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Data.Entities;

namespace TaparApi.Common.Mappings;

public class Mappings:Profile
{
    public Mappings()
    {
        CreateMap<BusinessCategory,BusinessCategoryDto>().ReverseMap();
        CreateMap<BusinessType1, BusinessType1Dto>().ReverseMap();
        CreateMap<BusinessType2, BusinessType2Dto>().ReverseMap();
        CreateMap<SpecialTypeField, DynamicFieldsDto>().ReverseMap();
        CreateMap<SpecialTypeField, DynamicFieldsAddDto>().ReverseMap();
    }
}