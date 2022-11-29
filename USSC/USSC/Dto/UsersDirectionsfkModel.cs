using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace USSC.Dto;

public class UsersDirectionsfkModel
{
    [JsonIgnore]
    public Guid Id { get; set; }
    [JsonIgnore]
    public UserModel? Users { get; set; } = new();
    public Guid UserId { get; set; }
    [JsonIgnore]
    public DirectionsModel? Directions { get; set; } = new();
    public Guid DirectionsId { get; set; }
    public bool Allow { get; set; }
}