using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace USSC.Entities;

public class UsersEntity : BaseEntity
{
    public string? Surname { get; set; }
    public string? Name { get; set; }
    public string? Patronymic { get; set; }
    public string? Email { get; set; }
    public string? HashedPassword { get; set; }
    [ForeignKey("ApplicationId")]
    public ApplicationEntity? Application { get; set; } 
    public Guid ApplicationId { get; set; } 
    [ForeignKey("TestCaseId")]
    public TestCaseEntity? TestCase { get; set; }
    public Guid TestCaseId { get; set; } 
}