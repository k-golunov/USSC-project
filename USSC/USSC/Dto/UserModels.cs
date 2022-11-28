using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using USSC.Entities;

namespace USSC.Dto;

public class UserModel
{
    [Key]
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    [JsonIgnore]
    public List<TestCaseModel> TestCase { get; set; } = new();
    [JsonIgnore]
    public List<UsersDirectionsfkModel> Directions { get; set; } = new();
    [JsonIgnore]
    public string? Role { get; set; }
    [JsonIgnore]
    public string? RefreshToken { get; set; }
    [JsonIgnore]
    public List<ProfileEntity> Profile { get; set; } = new();

}