using System.ComponentModel.DataAnnotations;

namespace FastService.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public string BirthdayDate { get; set; }
    [Required]
    public string Role { get; set; } 

}