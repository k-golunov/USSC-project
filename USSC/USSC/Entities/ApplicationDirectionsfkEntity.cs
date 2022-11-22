using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace USSC.Entities;

public class ApplicationDirectionsfkEntity : BaseEntity
{
    [JsonIgnore]
    [ForeignKey("ApplicationId")]
    public ApplicationEntity Application { get; set; }
    public Guid ApplicationId { get; set; }
    
    [JsonIgnore]
    [ForeignKey("DirectionsId")]
    public DirectionsEntity Directions { get; set; }
    public Guid DirectionsId { get; set; }
}