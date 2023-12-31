namespace FastService.API.Security.Domain.Services.Communication;

public class UpdateRequest
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string BirthdayDate { get; set; }
    public string Avatar { get; set; }
    public string Role { get; set; }
    public string Password { get; set; }
}