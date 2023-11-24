namespace FastService.API.Security.Domain.Services.Communication;

public class AuthenticateResponse
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
}