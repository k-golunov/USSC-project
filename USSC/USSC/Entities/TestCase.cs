namespace USSC.Entities;

public class TestCase: BaseEntity
{
    public string Comment { get; set; }
    public bool Allow { get; set; }
    public string Path { get; set; }
}