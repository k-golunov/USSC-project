using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface IUserService: IService<UsersEntity>
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<AuthenticateResponse> Register(UserModel userModel);

    Task<Guid> Update(UserModel entity);
}