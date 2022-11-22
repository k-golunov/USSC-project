using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace USSC.Dto;

public class UserModel
{
    [Key]
    public Guid Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    // [JsonIgnore]
    public ApplicationModel? Application { get; set; }
    // [JsonIgnore]
    public TestCaseModel? TestCase { get; set; }
    public Guid ApplicationId { get; set; }
    public Guid TestCaseId { get; set; }
}