using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class UsersPracticesfkModel
{
    [Key]
    public Guid Id { get; set; }
    public UserModel User { get; set; }
    public Guid UserId { get; set; }
    public PracticesModel Practices { get; set; }
    public Guid PracticeId { get; set; }
}