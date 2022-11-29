namespace USSC.Dto;

public class RequestModel
{
    public Guid Id { get; set; }
    public bool Allow { get; set; }
    public DirectionsModel Directions { get; set; }
    public Guid DirectionId { get; set; }
    public List<UserModel> User { get; set; }
}