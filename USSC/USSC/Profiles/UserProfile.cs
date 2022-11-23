using AutoMapper;
using USSC.Dto;
using USSC.Entities;

namespace USSC;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserModel, UsersEntity>()
            .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Surname))
            .ForMember(dst => dst.HashedPassword, opt => opt.MapFrom(src => src.HashedPassword))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dst => dst.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
            .ForMember(dst => dst.ApplicationId, opt => opt.MapFrom(src => src.ApplicationId))
            .ForMember(dst => dst.TestCaseId, opt => opt.MapFrom(src => src.TestCaseId))
            .ForMember(dst => dst.Application, opt => opt.MapFrom(src => src.Application))
            .ForMember(dst => dst.TestCase, opt => opt.MapFrom(src => src.TestCase))
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            ;
            
        CreateMap<UsersEntity, AuthenticateResponse>()
            .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.Patronymic, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.Token, opt => opt.Ignore())
            ;
    }
}