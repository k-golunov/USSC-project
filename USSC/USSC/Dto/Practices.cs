using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class Practices
{
    [Key]
    public long Id { get; set; }
    public string? Descriptions { get; set; }
    public string? Info { get; set; }
    public string? Name { get; set; }
}