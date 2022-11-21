using System.Text.Json.Serialization;

namespace USSC.Entities;

public class User : BaseEntity
{ 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    
    public long ApplicationId { get; set; }
    
    public long TestCaseId { get; set; }
}