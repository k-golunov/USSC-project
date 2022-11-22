using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace USSC.Entities;

public class TeachersEntity : BaseEntity
{
    public string? Teacher { get; set; }
    [JsonIgnore]
    [ForeignKey("TestCaseId")]
    public TestCaseEntity TestCase { get; set; }
    public Guid TestCaseId { get; set; } 
    public List<DirectionsEntity> Directions { get; set; } = new();
}