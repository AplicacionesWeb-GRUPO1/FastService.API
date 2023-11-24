using System.Text.Json.Serialization;

namespace FastService.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }

}

