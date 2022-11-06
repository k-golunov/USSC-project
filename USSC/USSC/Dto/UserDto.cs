using Microsoft.EntityFrameworkCore;
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

// тестовое добавление загрузки файла
public class TestTaskFile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public IFormFile File { get; set; }
}

public class ModelsContext : DbContext
{
    // public DbSet<UserDto> Users { get; set; }
    // public DbSet<ApplicationForm> ApplicationForms { get; set; }
    // public DbSet<TestTask> TestTasks { get; set; }
    public DbSet<TestTaskFile> Files { get; set; }
    
    public ModelsContext(DbContextOptions<ModelsContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}