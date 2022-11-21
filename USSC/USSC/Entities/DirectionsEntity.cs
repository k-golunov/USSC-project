using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace USSC.Entities;

public class DirectionsEntity : BaseEntity
{
    public string? Directions { get; set; }
    [JsonIgnore]
    [ForeignKey("TeacherId")]
    public TeachersEntity Teacher { get; set; }

    public Guid TeacherId { get; set; }
}