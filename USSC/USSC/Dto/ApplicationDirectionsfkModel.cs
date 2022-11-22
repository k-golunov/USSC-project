using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class ApplicationDirectionsfkModel
{
    [Key]
    public Guid Id { get; set; }
    public ApplicationModel Application { get; set; }
    public Guid ApplicationId { get; set; }
    public DirectionsModel Directions { get; set; }
    public Guid DirectionsId { get; set; }
}