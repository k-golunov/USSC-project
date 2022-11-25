using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class PracticesModel
{
    [Key]
    public Guid Id { get; set; }
    public string Descriptions { get; set; }
    public string Info { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public List<DirectionsModel>? Directions { get; set; } = new();
}