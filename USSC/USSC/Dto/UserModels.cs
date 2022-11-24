using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace USSC.Dto;

public class UserModel
{
    [Key]
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    [JsonIgnore] 
    public ApplicationModel Application { get; set; } = new();
    [JsonIgnore] 
    public TestCaseModel TestCase { get; set; } = new();
    [JsonIgnore]
    public Guid ApplicationId { get; set; }
    [JsonIgnore]
    public Guid TestCaseId { get; set; }
}