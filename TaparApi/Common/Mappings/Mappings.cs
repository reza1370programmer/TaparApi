using AutoMapper;
using TaparApi.Common.Dtos.BusinessCategory;
using TaparApi.Common.Dtos.BusinessOfficeType;
using TaparApi.Common.Dtos.BusinessType2;
using TaparApi.Common.Dtos.DynamicFields;
using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Data.Entities;

namespace TaparApi.Common.Mappings;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<BusinessCategory, BusinessCategoryDto>().ReverseMap();
        CreateMap<BusinessType1, BusinessType1Dto>().ReverseMap();
        CreateMap<BusinessType2, BusinessType2Dto>().ReverseMap();
        CreateMap<DynamicFieldsDto, SpecialTypeField>().
            ForMember(dest => dest.BusinessType1, opt => opt.Ignore()).
            ForMember(dest => dest.BusinessType2, opt => opt.Ignore())
            .ReverseMap();
        CreateMap<BusinessOfficeType, BusinessOfficeTypeDto>().ReverseMap();

    }
}