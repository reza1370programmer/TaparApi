using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using TaparApi.Common.Dtos.Business;
using TaparApi.Common.Dtos.BusinessCategory;
using TaparApi.Common.Dtos.BusinessOffice;
using TaparApi.Common.Dtos.BusinessOfficeType;
using TaparApi.Common.Dtos.BusinessType2;
using TaparApi.Common.Dtos.DynamicFields;
using TaparApi.Common.Dtos.FirstTypeBusiness;
using TaparApi.Common.Dtos.Location;
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
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<BusinessOfficeAddDto, BusinessOffice>().ReverseMap();
        CreateMap<BusinessOffice, BusinessOfficeDto>().ReverseMap().ForMember(dist => dist.cUserId, opt => opt.Ignore())
            .ForMember(dist => dist.cDate, opt => opt.Ignore());
        CreateMap<BusinessOfficeSelectDto, BusinessOffice>().ReverseMap();
        CreateMap<BusinessOfficeUpdateDto, BusinessOffice>().ReverseMap();
        CreateMap<OfficeUpdate, BusinessOffice>().ReverseMap()
            .ForMember(dest => dest.businessOfficeId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<BusinessAddDto, Business>().ReverseMap();
        CreateMap<BusinessDto, Business>().ReverseMap();
        CreateMap<BusinessSelectDto, Business>().ReverseMap().ForMember(dest => dest.businessOfficeDto, opt => opt.MapFrom(src => src.BusinessOffice));
        CreateMap<Business, BusinessUpdate>().ForMember(dist=>dist.Id,opt=>opt.Ignore());

    }
}