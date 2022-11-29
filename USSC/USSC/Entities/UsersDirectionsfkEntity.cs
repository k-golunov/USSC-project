using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace USSC.Entities;

public class UsersDirectionsfkEntity : BaseEntity
{
    public Guid Id { get; set; }
    public bool Allow { get; set; }
    [ForeignKey("UserId")]
    public UsersEntity? Users { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("DirectionsId")]
    public DirectionsEntity? Directions { get; set; }
    public Guid DirectionsId { get; set; }
}