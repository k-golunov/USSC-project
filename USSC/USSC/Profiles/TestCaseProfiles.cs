using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Profiles;

public class TestCaseProfiles : Profile
{
    public TestCaseProfiles()
    {
        CreateMap<TestCaseModel, TestCaseEntity>()
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            .ForMember(dst => dst.Allow, opt => opt.MapFrom(src => src.Allow))
            .ForMember(dst => dst.Comment, opt => opt.MapFrom(src => src.Comment))
            .ForMember(dst => dst.Path, opt => opt.MapFrom(src => src.Path))
            .ForMember(dst => dst.Users, opt => opt.MapFrom(src => src.Users))
            .ForAllMembers(x => x.Ignore());   
    }
}