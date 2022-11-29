using System.Text.Json.Serialization;

namespace USSC.Dto;

public class RequestModel
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public bool Allow { get; set; }
    [JsonIgnore] public DirectionsModel? Directions { get; set; }
    public Guid DirectionId { get; set; }
    [JsonIgnore] public List<UserModel>? User { get; set; } = new();
}