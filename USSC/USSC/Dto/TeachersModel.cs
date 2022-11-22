using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace USSC.Dto;

public class TeachersModel
{
    [Key]
    public Guid Id { get; set; }
    public string Teacher { get; set; }
    // [JsonIgnore]
    public TestCaseModel TestCase;
    public Guid TestCaseId;
}