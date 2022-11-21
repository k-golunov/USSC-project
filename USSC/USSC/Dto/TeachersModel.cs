using System.ComponentModel.DataAnnotations;

namespace USSC.Dto;

public class TeachersModel
{
    [Key]
    public Guid Id { get; set; }
    public string Teacher { get; set; }
    public TestCaseModel TestCase;
    public Guid TestCaseId;
}