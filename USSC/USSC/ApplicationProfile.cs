using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC;

public class ApplicationProfile: Profile
{
    public ApplicationProfile()
    {
        CreateMap<ApplicationModel, Application>()
            .ForMember(dst => dst.Id, 
                opt => opt.Ignore())
            .ForMember(dst => dst.UserId, 
                opt => opt.MapFrom(src => src.UserId))
            .ForMember(dst => dst.University, 
                opt => opt.MapFrom(src => src.University))
            .ForMember(dst => dst.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dst => dst.LastName, 
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dst => dst.Patronymic, 
                opt => opt.MapFrom(src => src.Patronymic))
            .ForMember(dst => dst.Faculty, 
                opt => opt.MapFrom(src => src.Faculty))
            .ForMember(dst => dst.Speciality, 
                opt => opt.MapFrom(src => src.Speciality))
            .ForMember(dst => dst.Course, 
                opt => opt.MapFrom(src => src.Course))
            .ForMember(dst => dst.Email, 
                opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.Orientation, 
                opt => opt.MapFrom(src => src.Orientation))
            ;

        CreateMap<Application, SuccessResponse>();

    }
    
    
    
            
    
}