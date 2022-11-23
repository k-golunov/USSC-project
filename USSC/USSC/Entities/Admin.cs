namespace USSC.Entities;

public class Admin: User
{
    public List<User> Students { get; set; } = new();
}