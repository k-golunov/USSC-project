namespace USSC.Entities;

public class TestCaseEntity : BaseEntity
{
    public string? Comment { get; set; }
    public bool Allow { get; set; }
    public string? Path { get; set; }
    public List<UsersEntity>? Users { get; set; } = new();
    public List<TeachersEntity>? Teachers { get; set; } = new();
}