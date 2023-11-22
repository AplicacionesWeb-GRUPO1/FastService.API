using System.ComponentModel.DataAnnotations;

namespace FastService.API.Security.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string UserName { get; set; }
    [Required] public string Password { get; set; }
}