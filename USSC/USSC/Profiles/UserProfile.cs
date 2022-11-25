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
            .ForMember(dst => dst.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dst => dst.TestCase, opt => opt.MapFrom(src => src.TestCase))
            .ForMember(dst => dst.RefreshToken, opt => opt.MapFrom(src => src.RefreshToken))
            .ForMember(dst => dst.Role, opt => opt.MapFrom(src => src.Role))
            .ForMember(dst => dst.Directions, opt => opt.MapFrom(src => src.Directions))
            .ForMember(dst => dst.Profile, opt => opt.MapFrom(src => src.Profile))
            .ForMember(dst => dst.Id, opt => opt.Ignore())
            ;
            
        CreateMap<UsersEntity, AuthenticateResponse>()
            .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email))
            // .ForMember(dst => dst.Surname, opt => opt.MapFrom(src => src.Email))
            // .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Email))
            // .ForMember(dst => dst.Patronymic, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.Token, opt => opt.Ignore())
            ;
    }
}