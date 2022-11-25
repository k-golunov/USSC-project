using USSC.Entities;

namespace USSC.Dto;

public class AuthenticateResponse
{
    public Guid Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(UsersEntity user, string? toke)
    {
        Id = user.Id;
        Email = user.Email;
    }
}