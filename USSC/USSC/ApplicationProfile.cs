using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC;

public class ApplicationProfile: Profile
{
    public ApplicationProfile()
    {
        CreateMap<ApplicationModel, ApplicationEntity>()
            .ForMember(dst => dst.Id, 
                opt => opt.Ignore())
            .ForMember(dst => dst.University, 
                opt => opt.MapFrom(src => src.University))
            .ForMember(dst => dst.Faculty, 
                opt => opt.MapFrom(src => src.Faculty))
            .ForMember(dst => dst.Speciality, 
                opt => opt.MapFrom(src => src.Speciality))
            .ForMember(dst => dst.Course, 
                opt => opt.MapFrom(src => src.Course))
            .ForMember(dst => dst.Phone, 
                opt => opt.MapFrom(src => src.Phone))
            .ForMember(dst => dst.Users, 
                opt => opt.MapFrom(src => src.Users))
            ;
        CreateMap<ApplicationEntity, SuccessResponse>();
    }
}