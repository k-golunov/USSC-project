using System.ComponentModel.DataAnnotations.Schema;

namespace USSC.Entities;

public class TestCaseEntity : BaseEntity
{
    public string? Comment { get; set; }
    public bool Allow { get; set; }
    public string? Path { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(("UserId"))] public UsersEntity Users { get; set; } = new();
    [ForeignKey("DirectionId")]
    public List<DirectionsEntity> Directions { get; set; }
    public Guid DirectionId { get; set; }
}