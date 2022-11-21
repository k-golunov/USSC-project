using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace USSC.Entities;

public class UsersPracticesfkEntity : BaseEntity
{
    [JsonIgnore]
    [ForeignKey("UserId")]
    public UsersEntity? User { get; set; }
    public Guid UserId { get; set; }
    
    [JsonIgnore]
    [ForeignKey("PracticesId")]
    public PracticesEntity? Practices { get; set; }
    public Guid PracticeId { get; set; }
}