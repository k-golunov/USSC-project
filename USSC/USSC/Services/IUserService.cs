using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface IUserService: IService<User>
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<AuthenticateResponse> Register(UserModel userModel);
}