using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace USSC.Entities;

public class UsersRequestfkEntity 
{
    [ForeignKey("UserId")]
    public UsersEntity Users { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("RequestId")]
    public RequestEntity Request { get; set; }
    public Guid RequestId { get; set; }
}