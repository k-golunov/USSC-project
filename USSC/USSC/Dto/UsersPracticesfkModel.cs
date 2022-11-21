using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace USSC.Dto;

public class UsersPracticesfkModel
{
    [Key]
    public Guid Id { get; set; }
    // [JsonIgnore]
    public UserModel? User { get; set; }
    public Guid UserId { get; set; }
    // [JsonIgnore]
    public PracticesModel Practices { get; set; }
    public Guid PracticeId { get; set; }
}