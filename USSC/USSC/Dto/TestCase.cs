using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class TestCase
{
    [Key]
    public long Id { get; set; }
    public string? Comment { get; set; }
    public bool Allow { get; set; }
    public string? Path { get; set; }
}