using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USSC.Dto;

public class UsersRequestfkModel
{
    public UserModel Users { get; set; } = new();
    public Guid UserId { get; set; }
    public RequestModel Request { get; set; } = new();
    public Guid RequestId { get; set; }
}