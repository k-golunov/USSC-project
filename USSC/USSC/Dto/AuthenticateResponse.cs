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

    public AuthenticateResponse(UsersEntity user, string token)
    {
        Id = user.Id;
        Surname = user.Surname;
        Name = user.Name;
        Patronymic = user.Patronymic;
        Email = user.Email;
        Token = token;
    }
}