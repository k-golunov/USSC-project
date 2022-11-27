using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace USSC.Dto;

public class UsersDirectionsfkModel
{
    public Guid Id { get; set; }
    public UserModel Users { get; set; } = new();
    public Guid UserId { get; set; }
    public DirectionsModel Directions { get; set; } = new();
    public Guid DirectionsId { get; set; }
    public bool Allow { get; set; }
}