using USSC.Attributes;

namespace USSC.Dto;

public enum Roles
{
    User,
    Tutor, 
    Admin,
}

public class UserDto
{
    [Login]
    public string Login { get; set; }
    [Email]
    public string Email { get; set; }
    public string[] Notifications { get; set; }
    public Roles Role { get; set; }
    public string[] AttachedTutors { get; set; }
    public ApplicationForm Form { get; set; }
}

public class ApplicationForm
{
    public string Name { get; set; }
    public string Phone { get; set; }
    [Email]
    public string Email { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public string Profession { get; set; }
    public int Year { get; set; }
    public string Date { get; set; }
    public string[] Directions { get; set; }
}

public class TestTask
{
    public string Login { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
    // public string Task { get; set; } скорее всего будет храниться другим образом
}