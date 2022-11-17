using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class Application
{
    [Key]
    public long Id { get; set; }
    public long UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? University { get; set; }
    public string? Faculty { get; set; }
    public string? Speciality { get; set; }
    public int Course { get; set; }
    public string? Email { get; set; }
    public string[] Orientation { get; set; }
}