using USSC.Entities;

namespace USSC.Dto;

public class AuthenticateResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(UsersEntity user, string token)
    {
        Id = user.Id;
        Email = user.Email;
        Token = token;
    }
}