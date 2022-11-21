using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class DirectionsModel
{
    [Key]
    public Guid Id { get; set; }
    public string Directions { get; set; }
    public TeachersModel Teacher { get; set; }

    public Guid TeacherId { get; set; }
}