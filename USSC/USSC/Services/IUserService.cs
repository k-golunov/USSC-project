using USSC.Dto;
using USSC.Entities;

namespace USSC.Services;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<AuthenticateResponse> Register(UserModel userModel);
    IEnumerable<User> GetAll();
    User GetById(int id);
}