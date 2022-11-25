using System.ComponentModel.DataAnnotations;
using USSC.Entities;

namespace USSC.Dto;

public class DirectionsModel
{
    [Key]
    public Guid Id { get; set; }
    public string? Directions { get; set; }
    public string? Path { get; set; }
    public List<TestCaseModel>? TestCase { get; set; } = new();
    public List<PracticesModel>? Practices { get; set; } = new();
    public List<UsersDirectionsfkModel>? Users { get; set; } = new();
}