using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class TestCaseModel
{
    [Key]
    public Guid Id { get; set; }
    public string Comment { get; set; }
    public bool Allow { get; set; }
    public string Path { get; set; }
    public List<UserModel> Users { get; set; }= new();
}