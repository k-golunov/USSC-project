using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC.Profiles;

public class PracticesProfile : Profile
{
    public PracticesProfile()
    {
        CreateMap<PracticesModel, PracticesEntity>()
            .ForMember(dst => dst.Description, opt => opt.MapFrom(src => src.Descriptions))
            .ForMember(dst => dst.Info, opt => opt.MapFrom(src => src.Info))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));
    }
}