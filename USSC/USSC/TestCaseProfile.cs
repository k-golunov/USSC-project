using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC;

public class TestCaseProfile : Profile
{
    public TestCaseProfile()
    {
        CreateMap<ReviewTestCaseModel, TestCase>()
            .ForMember(dst => dst.Allow,
                opt => opt.MapFrom(src => src.Allow))
            .ForMember(dst => dst.Comment,
                opt => opt.MapFrom(src => src.Comment))
            .ForMember(dst => dst.Path,
                opt => opt.MapFrom(src => src.Path))
            .ForMember(dst => dst.Id,
                opt => opt.Ignore());
        
        CreateMap<TestCaseModel, TestCase>()
            .ForMember(dst => dst.Path,
                opt => opt.MapFrom(src => src.Path))
            .ForMember(dst => dst.Id,
                opt => opt.Ignore());

        CreateMap<TestCase, SuccessResponse>();
    }
}