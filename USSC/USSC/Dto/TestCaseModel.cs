using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class TestCaseModel
{
    [Key] public Guid Id { get; set; }
    public string? Comment { get; set; }
    public bool Allow { get; set; }
    public string? Path { get; set; }
    public UserModel Users { get; set; } = new();
    public Guid UserId { get; set; }
    public List<DirectionsModel>? Directions { get; set; } = new();
    public Guid DirectionId { get; set; }
}