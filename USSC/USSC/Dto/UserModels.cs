using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using USSC.Entities;

namespace USSC.Dto;

public class UserModel
{
    [Key]
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<TestCaseModel> TestCase { get; set; } = new();
    public List<UsersDirectionsfkModel> Directions { get; set; } = new();
    public string? Role { get; set; }
    public string? RefreshToken { get; set; }
    public List<ProfileEntity> Profile { get; set; } = new();

}