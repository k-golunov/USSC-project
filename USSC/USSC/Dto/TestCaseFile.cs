using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class TestCaseFile
{
    [Key]
    public long Id { get; set; }
    public long PracticesId { get; set; }
    public string? Path { get; set; }
}