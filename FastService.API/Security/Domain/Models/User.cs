using System.Text.Json.Serialization;

namespace FastService.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string BirthdayDate { get; set; }
    public string Avatar { get; set; }
    public string Role { get; set; }
        
    [JsonIgnore]
    public string PasswordHash { get; set; }

}

